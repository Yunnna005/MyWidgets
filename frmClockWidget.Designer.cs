namespace MyWidgets
{
    partial class frmClockWidget
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
            this.components = new System.ComponentModel.Container();
            this.lblClockTime = new System.Windows.Forms.Label();
            this.tmrClockWidgetTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblClockTime
            // 
            this.lblClockTime.AutoSize = true;
            this.lblClockTime.Font = new System.Drawing.Font("Lucida Handwriting", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClockTime.Location = new System.Drawing.Point(107, 58);
            this.lblClockTime.Name = "lblClockTime";
            this.lblClockTime.Size = new System.Drawing.Size(290, 70);
            this.lblClockTime.TabIndex = 0;
            this.lblClockTime.Text = "00:00:00";
            // 
            // tmrClockWidgetTimer
            // 
            this.tmrClockWidgetTimer.Tick += new System.EventHandler(this.clockWidgetTimer_Tick);
            // 
            // frmClockWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 191);
            this.Controls.Add(this.lblClockTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmClockWidget";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "ClockWidget";
            this.Load += new System.EventHandler(this.ClockWidget_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmClockWidget_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmClockWidget_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClockTime;
        private System.Windows.Forms.Timer tmrClockWidgetTimer;
    }
}