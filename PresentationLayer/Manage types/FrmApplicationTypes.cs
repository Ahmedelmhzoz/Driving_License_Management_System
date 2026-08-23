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
    public partial class FrmApplicationTypes : Form {
        public FrmApplicationTypes() {
            InitializeComponent();
        }

        private void FrmApplicationTypes_Load(object sender, EventArgs e) {
            dgvAppTypes.RowTemplate.Height = 80;
            dgvAppTypes.DataSource = AppType.getApplicationTypes();
        }

        private void showDetials_Click(object sender, EventArgs e) {
            int ID = (int)dgvAppTypes.CurrentRow.Cells[0].Value;
            AppType appType = AppType.getApplicationType(ID);
            FrmEditApp frm = new FrmEditApp(appType);
            frm.ShowDialog();
            dgvAppTypes.DataSource = AppType.getApplicationTypes();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
