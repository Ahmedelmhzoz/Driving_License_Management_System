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
namespace PresentationLayer {
    public partial class FrmPeople : Form {
        public FrmPeople() {
            InitializeComponent();
        }
        
            
        private void FrmPeople_Load(object sender, EventArgs e) {
            cbFilterBy.SelectedIndex = 0;
            dgvPeople.RowTemplate.Height = 60;
            dgvPeople.DataSource = Person.getAllPeople();
            lblRecordsNo.Text = dgvPeople.Rows.Count.ToString();
   
        }

        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbFilterBy.Text == "None") {
                txtSearch.Visible = false;
                dgvPeople.DataSource = Person.getAllPeople();
            } else {
                txtSearch.Visible = true;
            }
                
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) {
            dgvPeople.DataSource = Person.getCurrentSearchResult(txtSearch.Text, cbFilterBy.Text);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) {
            if (cbFilterBy.Text == "Person ID") {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                    e.Handled = true;
                }
            }
        }
    }
}
