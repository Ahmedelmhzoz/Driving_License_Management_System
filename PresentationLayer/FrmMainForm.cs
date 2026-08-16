using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer {
    public partial class FrmMainForm : Form {
        public FrmMainForm() {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmPeople frm = new FrmPeople();
            frm.ShowDialog();
        }
    }
}
