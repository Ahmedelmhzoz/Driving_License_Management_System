using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Global;
using BusinessLayer;
namespace PresentationLayer {
    public partial class FrmPeople : Form {
        public FrmPeople() {
            InitializeComponent();
        }
        
        void _ReloadData() {
            dgvPeople.DataSource = Person.getAllPeople();
            lblRecordsNo.Text = dgvPeople.Rows.Count.ToString();
        }
        private void FrmPeople_Load(object sender, EventArgs e) {
            cbFilterBy.SelectedIndex = 0;
            dgvPeople.RowTemplate.Height = 60;
            _ReloadData();
            if (dgvPeople.Rows.Count > 0) {
                dgvPeople.Columns["Address"].Visible = false;
                dgvPeople.Columns["ImagePath"].Visible = false;
                dgvPeople.Columns["NationalityCountryID"].Visible = false;
            }
        }

        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbFilterBy.Text == "None") {
                txtSearch.Visible = false;
                _ReloadData();
            } else {
                txtSearch.Visible = true;
                dgvPeople.DataSource = Person.getCurrentSearchResult(txtSearch.Text, cbFilterBy.Text);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) {
            if (txtSearch.Text == "")
                _ReloadData();
            else
                dgvPeople.DataSource = Person.getCurrentSearchResult(txtSearch.Text, cbFilterBy.Text);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e) {
            if (cbFilterBy.Text == "Person ID") {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                    e.Handled = true;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e) {
            Person person = null;
            int ID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            if ((person = Person.findPerson(ID)) != null) {
                FrmPersonDetails frm = new FrmPersonDetails(person);
                frm.ShowDialog();
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e) {
            Person newPerson = new Person();
            FrmAddOrUpdatePerson frm = new FrmAddOrUpdatePerson(newPerson);
            frm.ShowDialog();
            _ReloadData();
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e) {
            int ID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            Person personToEdit = Person.findPerson(ID);
            FrmAddOrUpdatePerson frm = new FrmAddOrUpdatePerson(personToEdit);
            frm.ShowDialog();
            _ReloadData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            int selectedNationalNo = (int)dgvPeople.CurrentRow.Cells[0].Value;
            if (Person.deletePerson(selectedNationalNo)) {
                Helpers.SuccessfulMessage("Person deleted successfully");
            } else {
                Helpers.ShowErrorMessage("this Person is a user now, you cant delete user");
            }
            _ReloadData();
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e) {
            Helpers.ShowGeneralMessage("Will be implemented later on");
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e) {
            Helpers.ShowGeneralMessage("Will be implemented later on");
        }
    }
}
