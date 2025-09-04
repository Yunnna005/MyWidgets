namespace MyWidgets
{
    partial class frmMusicPlayer
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
            this.lblCurrentMusicTitle = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblCurrentMusicTitle
            // 
            this.lblCurrentMusicTitle.AutoSize = true;
            this.lblCurrentMusicTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentMusicTitle.Location = new System.Drawing.Point(319, 146);
            this.lblCurrentMusicTitle.Name = "lblCurrentMusicTitle";
            this.lblCurrentMusicTitle.Size = new System.Drawing.Size(147, 29);
            this.lblCurrentMusicTitle.TabIndex = 0;
            this.lblCurrentMusicTitle.Text = "Music Name";
            this.lblCurrentMusicTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMusicPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCurrentMusicTitle);
            this.Name = "frmMusicPlayer";
            this.Text = "frmMusicPlayer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCurrentMusicTitle;
        private System.Windows.Forms.Timer timer1;
    }
}