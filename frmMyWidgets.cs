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
    public partial class frmMyWidget : Form
    {
        public frmMyWidget()
        {
            InitializeComponent();
        }

        private void btnClock_Click(object sender, EventArgs e)
        {
            var createClockWidget = new frmClockWidget();
            createClockWidget.Show();
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            var createTemporaryNote = new frmTemporaryNote();
            createTemporaryNote.Show();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            var createCalendarWidget = new frmGoogleCalendar1();
            createCalendarWidget.Show();
        }
    }
}
