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
    public partial class EventCard : UserControl
    {
        private Label lblTime;
        private Label lblTitle;
        private Label lblLocation;
        private Panel colorStrip;

        public EventCard()
        {
            InitializeCard();
        }

        public string EventTime
        {
            get => lblTime.Text;
            set
            {
                if (lblTime != null)
                    lblTime.Text = value;
            }
        }

        public string EventTitle
        {
            get => lblTitle?.Text ?? string.Empty;
            set
            {
                if (lblTitle != null)
                {
                    lblTitle.Text = value;
                }
            }
        }

        public string EventLocation
        {
            get => lblLocation?.Text ?? string.Empty;
            set
            {
                if (lblLocation != null)
                {
                    lblLocation.Text = value;
                }
            }
        }

        public string EventDescription { get; set; }
        private void InitializeCard()
        {
            this.Height = 80;
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.None;
            this.Padding = new Padding(0);

            // Color strip on the left
            colorStrip = new Panel
            {
                Width = 4,
                Dock = DockStyle.Left,
                BackColor = Color.FromArgb(66, 133, 244)
            };

            // Container for text
            Panel textPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10, 8, 10, 8),
                BackColor = Color.White
            };

            lblTime = new Label
            {
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(95, 99, 104),
                Location = new Point(10, 8),
                AutoSize = true
            };

            lblTitle = new Label
            {
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(32, 33, 36),
                Location = new Point(10, 28),
                AutoSize = false,
                Width = 260,
                Height = 20
            };

            lblLocation = new Label
            {
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(95, 99, 104),
                Location = new Point(10, 50),
                AutoSize = false,
                Width = 260,
                Height = 18
            };

            textPanel.Controls.AddRange(new Control[] { lblTime, lblTitle, lblLocation });
            this.Controls.Add(textPanel);
            this.Controls.Add(colorStrip);

            // Hover effect
            this.MouseEnter += (s, e) =>
            {
                this.BackColor = Color.FromArgb(248, 249, 250);
                textPanel.BackColor = Color.FromArgb(248, 249, 250);
            };

            this.MouseLeave += (s, e) =>
            {
                this.BackColor = Color.White;
                textPanel.BackColor = Color.White;
            };

            // Apply hover to all child controls
            foreach (Control control in textPanel.Controls)
            {
                control.MouseEnter += (s, e) =>
                {
                    this.BackColor = Color.FromArgb(248, 249, 250);
                    textPanel.BackColor = Color.FromArgb(248, 249, 250);
                };

                control.MouseLeave += (s, e) =>
                {
                    this.BackColor = Color.White;
                    textPanel.BackColor = Color.White;
                };
            }

            // Click to show details
            this.Click += ShowEventDetails;
            textPanel.Click += ShowEventDetails;
            foreach (Control control in textPanel.Controls)
            {
                control.Click += ShowEventDetails;
            }
        }

        private void ShowEventDetails(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EventDescription))
            {
                MessageBox.Show($"{EventTitle}\n\n{EventDescription}", "Event Details",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw subtle border
            using (Pen pen = new Pen(Color.FromArgb(218, 220, 224), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    
}
}
