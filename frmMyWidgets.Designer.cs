namespace MyWidgets
{
    partial class frmMyWidget
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
            this.btnClock = new System.Windows.Forms.Button();
            this.btnCalendar = new System.Windows.Forms.Button();
            this.btnMusicPlayer = new System.Windows.Forms.Button();
            this.lblClock = new System.Windows.Forms.Label();
            this.lblCalendar = new System.Windows.Forms.Label();
            this.lblMusicPlayer = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.btnNotes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClock
            // 
            this.btnClock.Location = new System.Drawing.Point(265, 69);
            this.btnClock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClock.Name = "btnClock";
            this.btnClock.Size = new System.Drawing.Size(217, 71);
            this.btnClock.TabIndex = 0;
            this.btnClock.Text = "Clock";
            this.btnClock.UseVisualStyleBackColor = true;
            this.btnClock.Click += new System.EventHandler(this.btnClock_Click);
            // 
            // btnCalendar
            // 
            this.btnCalendar.Location = new System.Drawing.Point(265, 148);
            this.btnCalendar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Size = new System.Drawing.Size(217, 71);
            this.btnCalendar.TabIndex = 1;
            this.btnCalendar.Text = "Calendar";
            this.btnCalendar.UseVisualStyleBackColor = true;
            // 
            // btnMusicPlayer
            // 
            this.btnMusicPlayer.Location = new System.Drawing.Point(265, 226);
            this.btnMusicPlayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMusicPlayer.Name = "btnMusicPlayer";
            this.btnMusicPlayer.Size = new System.Drawing.Size(217, 65);
            this.btnMusicPlayer.TabIndex = 2;
            this.btnMusicPlayer.Text = "Music Player";
            this.btnMusicPlayer.UseVisualStyleBackColor = true;
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.Location = new System.Drawing.Point(119, 97);
            this.lblClock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(47, 17);
            this.lblClock.TabIndex = 3;
            this.lblClock.Text = "Clock";
            // 
            // lblCalendar
            // 
            this.lblCalendar.AutoSize = true;
            this.lblCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalendar.Location = new System.Drawing.Point(119, 176);
            this.lblCalendar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalendar.Name = "lblCalendar";
            this.lblCalendar.Size = new System.Drawing.Size(73, 17);
            this.lblCalendar.TabIndex = 4;
            this.lblCalendar.Text = "Calendar";
            // 
            // lblMusicPlayer
            // 
            this.lblMusicPlayer.AutoSize = true;
            this.lblMusicPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMusicPlayer.Location = new System.Drawing.Point(119, 251);
            this.lblMusicPlayer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMusicPlayer.Name = "lblMusicPlayer";
            this.lblMusicPlayer.Size = new System.Drawing.Size(100, 17);
            this.lblMusicPlayer.TabIndex = 5;
            this.lblMusicPlayer.Text = "Music Player";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(119, 324);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(50, 17);
            this.lblNotes.TabIndex = 7;
            this.lblNotes.Text = "Notes";
            // 
            // btnNotes
            // 
            this.btnNotes.Location = new System.Drawing.Point(265, 299);
            this.btnNotes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNotes.Name = "btnNotes";
            this.btnNotes.Size = new System.Drawing.Size(217, 65);
            this.btnNotes.TabIndex = 6;
            this.btnNotes.Text = "Temporary Note";
            this.btnNotes.UseVisualStyleBackColor = true;
            this.btnNotes.Click += new System.EventHandler(this.btnNotes_Click);
            // 
            // frmMyWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 774);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.btnNotes);
            this.Controls.Add(this.lblMusicPlayer);
            this.Controls.Add(this.lblCalendar);
            this.Controls.Add(this.lblClock);
            this.Controls.Add(this.btnMusicPlayer);
            this.Controls.Add(this.btnCalendar);
            this.Controls.Add(this.btnClock);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMyWidget";
            this.Text = "MyWidgets";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClock;
        private System.Windows.Forms.Button btnCalendar;
        private System.Windows.Forms.Button btnMusicPlayer;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Label lblCalendar;
        private System.Windows.Forms.Label lblMusicPlayer;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Button btnNotes;
    }
}

