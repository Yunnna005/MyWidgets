namespace MyWidgets
{
    partial class frmGoogleCalendar1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlCalendar = new System.Windows.Forms.Panel();
            this.pnlSide = new System.Windows.Forms.Panel();
            this.flpEventList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlEventDetails = new System.Windows.Forms.Panel();
            this.lblEventsHeader = new System.Windows.Forms.Label();
            this.lblSelectedDate = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.btnPrevMonth = new System.Windows.Forms.Button();
            this.lblMonthYear = new System.Windows.Forms.Label();
            this.pnlSide.SuspendLayout();
            this.pnlEventDetails.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCalendar
            // 
            this.pnlCalendar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCalendar.Location = new System.Drawing.Point(0, 46);
            this.pnlCalendar.Name = "pnlCalendar";
            this.pnlCalendar.Padding = new System.Windows.Forms.Padding(20);
            this.pnlCalendar.Size = new System.Drawing.Size(532, 409);
            this.pnlCalendar.TabIndex = 5;
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.White;
            this.pnlSide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlSide.Controls.Add(this.flpEventList);
            this.pnlSide.Controls.Add(this.pnlEventDetails);
            this.pnlSide.Controls.Add(this.lblSelectedDate);
            this.pnlSide.Controls.Add(this.panel4);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlSide.Location = new System.Drawing.Point(532, 46);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(281, 409);
            this.pnlSide.TabIndex = 4;
            // 
            // flpEventList
            // 
            this.flpEventList.AutoScroll = true;
            this.flpEventList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flpEventList.Location = new System.Drawing.Point(15, 104);
            this.flpEventList.Name = "flpEventList";
            this.flpEventList.Size = new System.Drawing.Size(253, 288);
            this.flpEventList.TabIndex = 4;
            // 
            // pnlEventDetails
            // 
            this.pnlEventDetails.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlEventDetails.Controls.Add(this.lblEventsHeader);
            this.pnlEventDetails.Location = new System.Drawing.Point(13, 52);
            this.pnlEventDetails.Name = "pnlEventDetails";
            this.pnlEventDetails.Size = new System.Drawing.Size(256, 34);
            this.pnlEventDetails.TabIndex = 3;
            // 
            // lblEventsHeader
            // 
            this.lblEventsHeader.AutoSize = true;
            this.lblEventsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventsHeader.ForeColor = System.Drawing.Color.White;
            this.lblEventsHeader.Location = new System.Drawing.Point(101, 8);
            this.lblEventsHeader.Name = "lblEventsHeader";
            this.lblEventsHeader.Size = new System.Drawing.Size(54, 16);
            this.lblEventsHeader.TabIndex = 0;
            this.lblEventsHeader.Text = "Events";
            // 
            // lblSelectedDate
            // 
            this.lblSelectedDate.AutoSize = true;
            this.lblSelectedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedDate.Location = new System.Drawing.Point(17, 11);
            this.lblSelectedDate.Name = "lblSelectedDate";
            this.lblSelectedDate.Size = new System.Drawing.Size(86, 16);
            this.lblSelectedDate.TabIndex = 2;
            this.lblSelectedDate.Text = "Select a date";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Location = new System.Drawing.Point(495, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(275, 463);
            this.panel4.TabIndex = 1;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Controls.Add(this.btnToday);
            this.pnlHeader.Controls.Add(this.btnNextMonth);
            this.pnlHeader.Controls.Add(this.btnPrevMonth);
            this.pnlHeader.Controls.Add(this.lblMonthYear);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(813, 46);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnlHeader_MouseDoubleClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Location = new System.Drawing.Point(454, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(99, 32);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnToday
            // 
            this.btnToday.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnToday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToday.FlatAppearance.BorderSize = 0;
            this.btnToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToday.ForeColor = System.Drawing.Color.Black;
            this.btnToday.Location = new System.Drawing.Point(369, 7);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(79, 32);
            this.btnToday.TabIndex = 3;
            this.btnToday.Text = "TODAY";
            this.btnToday.UseVisualStyleBackColor = false;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextMonth.Location = new System.Drawing.Point(323, 6);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(40, 33);
            this.btnNextMonth.TabIndex = 2;
            this.btnNextMonth.Text = ">\r\n";
            this.btnNextMonth.UseVisualStyleBackColor = true;
            this.btnNextMonth.Click += new System.EventHandler(this.btnNextMonth_Click);
            // 
            // btnPrevMonth
            // 
            this.btnPrevMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevMonth.Location = new System.Drawing.Point(277, 6);
            this.btnPrevMonth.Name = "btnPrevMonth";
            this.btnPrevMonth.Size = new System.Drawing.Size(40, 33);
            this.btnPrevMonth.TabIndex = 1;
            this.btnPrevMonth.Text = "<\r\n";
            this.btnPrevMonth.UseVisualStyleBackColor = true;
            this.btnPrevMonth.Click += new System.EventHandler(this.btnPrevMonth_Click);
            // 
            // lblMonthYear
            // 
            this.lblMonthYear.AutoSize = true;
            this.lblMonthYear.BackColor = System.Drawing.Color.Transparent;
            this.lblMonthYear.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthYear.Location = new System.Drawing.Point(1, 1);
            this.lblMonthYear.Name = "lblMonthYear";
            this.lblMonthYear.Size = new System.Drawing.Size(137, 32);
            this.lblMonthYear.TabIndex = 0;
            this.lblMonthYear.Text = "Month Year";
            // 
            // frmGoogleCalendar1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 455);
            this.Controls.Add(this.pnlCalendar);
            this.Controls.Add(this.pnlSide);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGoogleCalendar1";
            this.Text = "frmGoogleCalendar1";
            this.pnlSide.ResumeLayout(false);
            this.pnlSide.PerformLayout();
            this.pnlEventDetails.ResumeLayout(false);
            this.pnlEventDetails.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCalendar;
        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblMonthYear;
        private System.Windows.Forms.Button btnPrevMonth;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblSelectedDate;
        private System.Windows.Forms.Panel pnlEventDetails;
        private System.Windows.Forms.Label lblEventsHeader;
        private System.Windows.Forms.FlowLayoutPanel flpEventList;
    }
}