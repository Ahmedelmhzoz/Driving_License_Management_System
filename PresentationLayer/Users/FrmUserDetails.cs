using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace PresentationLayer.Users {
    public partial class FrmUserDetails : Form {
        User currentUser = null;
        public FrmUserDetails(User user) {
            InitializeComponent();
            currentUser = user;
        }

        private void FrmUserDetails_Load(object sender, EventArgs e) {
            ucUserInformations1.loadData(currentUser);
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
