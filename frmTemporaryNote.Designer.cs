namespace MyWidgets
{
    partial class frmTemporaryNote
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
            this.txtTemporaryNoteText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTemporaryNoteText
            // 
            this.txtTemporaryNoteText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTemporaryNoteText.Location = new System.Drawing.Point(24, 23);
            this.txtTemporaryNoteText.Multiline = true;
            this.txtTemporaryNoteText.Name = "txtTemporaryNoteText";
            this.txtTemporaryNoteText.Size = new System.Drawing.Size(487, 408);
            this.txtTemporaryNoteText.TabIndex = 0;
            this.txtTemporaryNoteText.Text = "Start your note...";
            this.txtTemporaryNoteText.TextChanged += new System.EventHandler(this.txtTemporaryNoteText_TextChanged);
            // 
            // frmTemporaryNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 449);
            this.Controls.Add(this.txtTemporaryNoteText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTemporaryNote";
            this.Text = "Temporary Note";
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.frmTemporaryNote_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmTemporaryNote_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTemporaryNoteText;
    }
}