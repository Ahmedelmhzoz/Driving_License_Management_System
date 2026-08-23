using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Manage_types {
    public partial class FrmTestTypes : Form {
        public FrmTestTypes() {
            InitializeComponent();
        }

        private void FrmTestTypes_Load(object sender, EventArgs e) {
            dgvTestTypes.RowTemplate.Height = 80;
            dgvTestTypes.DataSource = TestType.getAllTestTypes();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            int ID = (int)dgvTestTypes.CurrentRow.Cells[0].Value;
            TestType testType = TestType.getTestType(ID);
            FrmEditTest frm = new FrmEditTest(testType);
            frm.ShowDialog();
            dgvTestTypes.DataSource = TestType.getAllTestTypes();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
