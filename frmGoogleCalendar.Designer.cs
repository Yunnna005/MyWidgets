namespace MyWidgets
{
    partial class frmGoogleCalendar
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.btnLoadEvents = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(245, 138);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.ItemHeight = 16;
            this.listBoxEvents.Location = new System.Drawing.Point(92, 145);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(120, 84);
            this.listBoxEvents.TabIndex = 1;
            // 
            // btnLoadEvents
            // 
            this.btnLoadEvents.Location = new System.Drawing.Point(552, 182);
            this.btnLoadEvents.Name = "btnLoadEvents";
            this.btnLoadEvents.Size = new System.Drawing.Size(148, 46);
            this.btnLoadEvents.TabIndex = 2;
            this.btnLoadEvents.Text = "Load Events";
            this.btnLoadEvents.UseVisualStyleBackColor = true;
            this.btnLoadEvents.Click += new System.EventHandler(this.button1btnLoadEvents_Click);
            // 
            // frmGoogleCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoadEvents);
            this.Controls.Add(this.listBoxEvents);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "frmGoogleCalendar";
            this.Text = "frmGoogleCalendar";
            this.Load += new System.EventHandler(this.frmGoogleCalendar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.Button btnLoadEvents;
    }
}