using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWidgets
{
    public partial class frmGoogleCalendar1 : Form
    {
        private List<Event> allEvents = new List<Event>();
        private DateTime currentMonth;
        private Dictionary<DateTime, List<Event>> eventsByDate;
        private List<DayPanel> dayPanels = new List<DayPanel>();
        public frmGoogleCalendar1()
        {
            InitializeComponent();
            pnlHeader.Paint += PnlHeader_Paint;

            eventsByDate = new Dictionary<DateTime, List<Event>>(); 

            lblMonthYear.Text = DateTime.Now.ToString("MMMM yyyy");
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            currentMonth = DateTime.Today; 
            CreateCalendarGrid();
            UpdateCalendarDisplay();
            LoadEventsAsync();
        }

        //Display Calendar month and year at the Header Panel
        private void UpdateCalendarDisplay()
        {
            lblMonthYear.Text = currentMonth.ToString("MMMM yyyy");

            DateTime firstDayOfMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;
            int daysInMonth = DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month);

            DateTime previousMonth = firstDayOfMonth.AddDays(-startDayOfWeek);

            for (int i = 0; i < dayPanels.Count; i++)
            {
                DateTime date = previousMonth.AddDays(i);
                dayPanels[i].Date = date;
                dayPanels[i].IsCurrentMonth = date.Month == currentMonth.Month;
                dayPanels[i].IsToday = date.Date == DateTime.Today;

                if (eventsByDate.ContainsKey(date.Date))
                {
                    dayPanels[i].EventCount = eventsByDate[date.Date].Count;
                    dayPanels[i].HasEvents = true;
                }
                else
                {
                    dayPanels[i].EventCount = 0;
                    dayPanels[i].HasEvents = false;
                }

                dayPanels[i].Invalidate();
            }
        }

        private void DisplayEventsForDate(DateTime date)
        {
            lblSelectedDate.Text = date.ToString("dddd, MMMM d");
            flpEventList.Controls.Clear();

            if (!eventsByDate.ContainsKey(date.Date) || eventsByDate[date.Date].Count == 0)
            {
                Label noEvents = new Label
                {
                    Text = "No events scheduled",
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.FromArgb(95, 99, 104),
                    AutoSize = false,
                    Size = new Size(flpEventList.Width - 10, 50),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Padding = new Padding(5)
                };
                flpEventList.Controls.Add(noEvents);
                return;
            }

            var sortedEvents = eventsByDate[date.Date].OrderBy(e => e.Start.DateTime ?? DateTime.Parse(e.Start.Date)).ToList();

            foreach (var ev in sortedEvents)
            {
                EventCard card = new EventCard
                {
                    EventTitle = ev.Summary ?? "No Title",
                    EventTime = GetEventTimeString(ev),
                    EventLocation = ev.Location ?? "",
                    EventDescription = ev.Description ?? "",
                    Width = flpEventList.Width - 15,
                    Height = 50,
                    Margin = new Padding(0, 0, 0, 10),
                    
                };

                flpEventList.Controls.Add(card);
            }
        }


        private string GetEventTimeString(Event ev)
        {
            if (ev.Start.DateTime.HasValue && ev.End.DateTime.HasValue)
            {
                return $"{ev.Start.DateTime.Value:HH:mm} - {ev.End.DateTime.Value:HH:mm}";
            }
            return "All Day";
        }

        private void CreateCalendarGrid()
        {
            // Day headers
            string[] dayNames = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            int leftPadding = 10;      
            int topPadding = 30;        
            int headerHeight = 25;      
            int cellSpacing = 2;        

            int cellWidth = (pnlCalendar.Width - leftPadding * 2 - (7 - 1) * cellSpacing) / 7;
            int cellHeight = (pnlCalendar.Height - topPadding - headerHeight - (6 - 1) * cellSpacing) / 6;

            // Create day headers
            for (int i = 0; i < 7; i++)
            {
                Label dayHeader = new Label
                {
                    Text = dayNames[i],
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.FromArgb(95, 99, 104),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(leftPadding + i * (cellWidth + cellSpacing), topPadding),
                    Size = new Size(cellWidth, headerHeight),
                    BackColor = Color.Transparent
                };
                pnlCalendar.Controls.Add(dayHeader);
            }

            // Create day panels
            for (int week = 0; week < 6; week++)
            {
                for (int day = 0; day < 7; day++)
                {
                    DayPanel dayPanel = new DayPanel
                    {
                        Location = new Point(leftPadding + day * (cellWidth + cellSpacing), topPadding + headerHeight + week * (cellHeight + cellSpacing)),
                        Size = new Size(cellWidth, cellHeight),
                        BackColor = Color.White,
                        BorderStyle = BorderStyle.FixedSingle,
                        Cursor = Cursors.Hand
                    };

                    dayPanel.Click += DayPanel_Click;
                    dayPanels.Add(dayPanel);
                    pnlCalendar.Controls.Add(dayPanel);
                }
            }
        }


        private async void LoadEventsAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                await Task.Run(() =>
                {
                    allEvents = GoogleAPI.GetEvents();
                });

                ProcessEvents();
                UpdateCalendarDisplay();

                this.Invoke((MethodInvoker)delegate
                {
                    ShowNotification("Events loaded successfully!", Color.FromArgb(52, 168, 83));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading events: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ProcessEvents()
        {
            eventsByDate.Clear();
            foreach (var ev in allEvents)
            {
                DateTime? startDate = ev.Start.DateTime ??
                    (DateTime.TryParse(ev.Start.Date, out var date) ? date : (DateTime?)null);

                if (startDate.HasValue)
                {
                    var dateKey = startDate.Value.Date;
                    if (!eventsByDate.ContainsKey(dateKey))
                    {
                        eventsByDate[dateKey] = new List<Event>();
                    }
                    eventsByDate[dateKey].Add(ev);
                }
            }
        }

        private void ShowNotification(string message, Color color)
        {
            Label notification = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.White,
                BackColor = color,
                AutoSize = false,
                Size = new Size(300, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(this.Width - 320, 20)
            };

            this.Controls.Add(notification);
            notification.BringToFront();

            Timer timer = new Timer { Interval = 2000 };
            timer.Tick += (s, e) =>
            {
                this.Controls.Remove(notification);
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void PnlHeader_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(218, 220, 224), 1))
            {
                e.Graphics.DrawLine(pen, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
            }
        }
        #region OnClick Events
        private void btnToday_Click(object sender, EventArgs e)
        {
            currentMonth = DateTime.Today;
            UpdateCalendarDisplay();
            DisplayEventsForDate(DateTime.Today);
        }

        private void btnPrevMonth_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(-1);
            UpdateCalendarDisplay();
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(1);
            UpdateCalendarDisplay();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEventsAsync();
        }

        private void DayPanel_Click(object sender, EventArgs e)
        {
            DayPanel clickedPanel = sender as DayPanel;
            if (clickedPanel == null) return;

            // Highlight selected day
            foreach (var panel in dayPanels)
            {
                panel.IsSelected = false;
                panel.Invalidate();
            }
            clickedPanel.IsSelected = true;
            clickedPanel.Invalidate();

            DisplayEventsForDate(clickedPanel.Date);
        }

        #endregion

        private void pnlHeader_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
