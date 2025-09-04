using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWidgets
{
    internal class DayPanel : Panel
    {
        public DateTime Date { get; set; }
        public bool IsCurrentMonth { get; set; }
        public bool IsToday { get; set; }
        public bool IsSelected { get; set; }
        public bool HasEvents { get; set; }
        public int EventCount { get; set; }

        private readonly Color todayColor = Color.FromArgb(66, 133, 244);
        private readonly Color selectedColor = Color.FromArgb(232, 240, 254);
        private readonly Color eventIndicatorColor = Color.FromArgb(52, 168, 83);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Background
            if (IsSelected)
            {
                this.BackColor = selectedColor;
            }
            else if (!IsCurrentMonth)
            {
                this.BackColor = Color.FromArgb(248, 249, 250);
            }
            else
            {
                this.BackColor = Color.White;
            }

            // Day number
            string dayText = Date.Day.ToString();
            Font dayFont = IsToday ? new Font("Segoe UI", 12, FontStyle.Bold) : new Font("Segoe UI", 11);
            Color textColor = IsCurrentMonth ? Color.FromArgb(32, 33, 36) : Color.FromArgb(154, 160, 166);

            if (IsToday)
            {
                // Draw circle for today
                using (Brush brush = new SolidBrush(todayColor))
                {
                    g.FillEllipse(brush, 5, 5, 30, 30);
                }
                textColor = Color.White;
            }

            using (Brush textBrush = new SolidBrush(textColor))
            {
                SizeF textSize = g.MeasureString(dayText, dayFont);
                float x = IsToday ? 20 - textSize.Width / 2 : 8;
                float y = IsToday ? 20 - textSize.Height / 2 : 5;
                g.DrawString(dayText, dayFont, textBrush, x, y);
            }

            // Event indicators
            if (HasEvents && EventCount > 0)
            {
                int maxDots = Math.Min(EventCount, 3);
                int dotSize = 6;
                int spacing = 10;
                int startX = (this.Width - (maxDots * spacing - spacing + dotSize)) / 2;

                using (Brush eventBrush = new SolidBrush(eventIndicatorColor))
                {
                    for (int i = 0; i < maxDots; i++)
                    {
                        g.FillEllipse(eventBrush, startX + i * spacing, this.Height - 15, dotSize, dotSize);
                    }
                }

                // Event count badge
                if (EventCount > 1)
                {
                    string countText = EventCount.ToString();
                    Font countFont = new Font("Segoe UI", 8, FontStyle.Bold);
                    using (Brush countBrush = new SolidBrush(Color.FromArgb(234, 67, 53)))
                    {
                        SizeF countSize = g.MeasureString(countText, countFont);
                        g.FillEllipse(countBrush, this.Width - 25, 5, 20, 20);
                    }
                    using (Brush whiteBrush = new SolidBrush(Color.White))
                    {
                        g.DrawString(countText, countFont, whiteBrush, this.Width - 20, 8);
                    }
                }
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!IsSelected && IsCurrentMonth)
            {
                this.BackColor = Color.FromArgb(248, 249, 250);
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (!IsSelected)
            {
                this.BackColor = IsCurrentMonth ? Color.White : Color.FromArgb(248, 249, 250);
            }
        }
    }
}
