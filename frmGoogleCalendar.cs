using Google.Apis.Calendar.v3.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWidgets
{
    public partial class frmGoogleCalendar : Form
    {

        private List<Event> allEvents = new List<Event>();
        public frmGoogleCalendar()
        {
            InitializeComponent();
        }

        private void frmGoogleCalendar_Load(object sender, EventArgs e)
        {
            monthCalendar1.DateSelected += MonthCalendar1_DateSelected;
        }


        private void button1btnLoadEvents_Click(object sender, EventArgs e)
        {
            allEvents = GoogleAPI.GetEvents();
            MessageBox.Show("Events loaded!");
            HighlightEventDays();
        }

        private void MonthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            listBoxEvents.Items.Clear();
            DateTime selectedDate = monthCalendar1.SelectionStart;

            var eventsForDay = allEvents.Where(ev =>
            {
                DateTime? start = ev.Start.DateTime ?? DateTime.Parse(ev.Start.Date);
                return start.Value.Date == selectedDate.Date;
            }).ToList();

            foreach (var ev in eventsForDay)
            {
                string time = ev.Start.DateTime?.ToString("HH:mm") ?? "All Day";
                listBoxEvents.Items.Add($"{time} - {ev.Summary}");
            }
        }

        private void HighlightEventDays()
        {
            // Optional: you can use BoldedDates to highlight days with events
            monthCalendar1.RemoveAllBoldedDates();
            foreach (var ev in allEvents)
            {
                DateTime? start = ev.Start.DateTime ?? DateTime.Parse(ev.Start.Date);
                monthCalendar1.AddBoldedDate(start.Value.Date);
            }
            monthCalendar1.UpdateBoldedDates();
        }


    }
}
