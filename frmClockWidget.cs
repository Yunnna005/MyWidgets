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
    public partial class frmClockWidget : Form
    {
        public frmClockWidget()
        {
            InitializeComponent();
        }

        private void ClockWidget_Load(object sender, EventArgs e)
        {
            tmrClockWidgetTimer.Start();
            this.Size = new Size(507, 191);
        }

        private void clockWidgetTimer_Tick(object sender, EventArgs e)
        {
            lblClockTime.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void frmClockWidget_MouseDown(object sender, MouseEventArgs e)
        {
            Utils.EnableFormDragForm(this);
        }

        private void frmClockWidget_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
