using BusinessLayer;
using Shared;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace PresentationLayer {
    public partial class FrmPeopleManagement : Form {
        public FrmPeopleManagement() {
            InitializeComponent();
        }

        private void _ApplyGridFormatting() {
            foreach (DataGridViewRow row in dgvPeople.Rows) {
                if (row.Cells["Email"].Value == null || row.Cells["Email"].Value.ToString() == string.Empty) {
                    row.Cells["Email"].Value = "There is no email";
                    row.Cells["Email"].Style.ForeColor = Color.Red;
                    row.Cells["Email"].Style.BackColor = Color.Pink;
                }
            }
            dgvPeople.Columns["ImagePath"].Visible = false;
            dgvPeople.Columns["Address"].Visible = false;
            dgvPeople.Columns["NationalityCountryID"].Visible = false;
        }
        private void _ReloadData() {

            dgvPeople.DataSource = Person.getCurrentSearchResult(txtSearch.Text, cbFilterBy.Text);
            lblRecordsNo.Text = dgvPeople.Rows.Count.ToString();
            _ApplyGridFormatting();
        }
        private void FrmPeople_Load(object sender, EventArgs e) {
            cbFilterBy.SelectedIndex = 0;
            dgvPeople.RowTemplate.Height = 60;
            _ReloadData();
        }

        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbFilterBy.Text == "None") 
                txtSearch.Visible = false;
            else 
                txtSearch.Visible = true;
            txtSearch.Text = string.Empty;
            _ReloadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) {
            _ReloadData();
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
                Alert.SuccessfulMessage("Person deleted successfully");
            } else {
                Alert.ShowErrorMessage("this Person is a user now, you cant delete user");
            }
            _ReloadData();
        }
    }
}
