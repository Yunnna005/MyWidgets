using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyWidgets
{
    public partial class frmTemporaryNote : Form
    {
        public frmTemporaryNote()
        {
            InitializeComponent();
        }

        private void frmTemporaryNote_MouseDown(object sender, MouseEventArgs e)
        {
            Utils.EnableFormDrag(this);
        }

        private void frmTemporaryNote_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void txtTemporaryNoteText_TextChanged(object sender, EventArgs e)
        {
            int lineHeight = txtTemporaryNoteText.Font.Height;
            int visibleLines = txtTemporaryNoteText.Height / lineHeight;

            int currentLine = txtTemporaryNoteText.GetLineFromCharIndex(txtTemporaryNoteText.SelectionStart);

            if (currentLine >= visibleLines)
            {
                txtTemporaryNoteText.Text = txtTemporaryNoteText.Text.Substring(0, txtTemporaryNoteText.Text.Length - 2);
                txtTemporaryNoteText.SelectionStart = txtTemporaryNoteText.Text.Length;
            }
        }
    }
}
