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
using static BusinessLayer.Person;

namespace PresentationLayer.Users {
    public partial class ucGetPersonWithFilter : UserControl {
        public ucGetPersonWithFilter() {
            InitializeComponent();
        }
        public event Action<bool> OnPersonSelection;
        DataTable currentSearchResult = null;
        int currentIDX = 0;
        private void ucGetPersonWithFilter_Load(object sender, EventArgs e) {
            cbFilterBy.SelectedIndex = 0;
        }
        Person convertDtRecordToObject(int idx) {
            Person person = null;
            int selectedID = (int)currentSearchResult.Rows[currentIDX]["PersonID"];
            if ((person = Person.findPerson(selectedID)) != null) {
                return person;
            }
            return null;
        }
        void _ViewTheCurrentPerson() {
            Person person = convertDtRecordToObject(currentIDX);
            ucPersonViewer.loadData(person);
        }
        private void btnNextPerson_Click(object sender, EventArgs e) {
            currentIDX = (currentIDX + 1) % currentSearchResult.Rows.Count;
            _ViewTheCurrentPerson();
        }
        bool _isTxtSearchFilled() {
            bool isValid = true;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtSearch.Text)) {
                errorProvider1.SetError(txtSearch, "Please search for a person in the system");
                isValid = false;
            }
            return isValid;
        }

        public void ReloadPersons() {
            if (currentSearchResult.Rows.Count < 1) {
                _NoResultScreen(false);
                return;
            }
            if (currentSearchResult.Rows.Count == 1) {
                btnNextPerson.Enabled = false;
                lblNext.ForeColor = Color.DimGray;
            }
            _ViewTheCurrentPerson();
        }

        public void currentPersonBecameAUser() {
            if (currentSearchResult != null) {
                currentSearchResult.Rows.RemoveAt(currentIDX);
                currentIDX = 0;
                lblRecordsNo.Text = currentSearchResult.Rows.Count.ToString();
                
            }
        }
        public void _ShowSearchResults() {
            currentSearchResult = Person.getCurrentSearchResult(txtSearch.Text, cbFilterBy.Text, true);// will get only persons who aren't linked to users 
            lblRecordsNo.Text = currentSearchResult.Rows.Count.ToString();
            if (currentSearchResult.Rows.Count == 0) {
                _NoResultScreen(true);
                return;
            }
            // if he came here, then for sure there is more than one person resulted by the search
            currentIDX = 0;
            if (currentSearchResult.Rows.Count == 1) {
                btnNextPerson.Enabled = false;
                lblNext.ForeColor = Color.DimGray;
            }
            else {
                btnNextPerson.Enabled = true;
                lblNext.ForeColor = Color.White;
            }
            _ViewTheCurrentPerson();
            OnPersonSelection?.Invoke(true);
        }
        
        void _NoResultScreen(bool withMessage = true) {
            ucPersonViewer.returnToDefault();
            if (withMessage) 
                Helpers.ShowErrorMessage($"There is no result have {cbFilterBy.Text} = {txtSearch.Text}");
            btnNextPerson.Enabled = false;
            lblNext.ForeColor = Color.DimGray;
            OnPersonSelection?.Invoke(false);
        }
        private void btnSearch_Click(object sender, EventArgs e) {
            if (!_isTxtSearchFilled()) 
                return;
            _ShowSearchResults();
        }

        public bool thereIsPersonSelected() {
            return currentSearchResult != null && currentSearchResult.Rows.Count > 0;
        }
        public int getPersonID() {
            return ucPersonViewer.returnPersonID();
        }

        public bool thereIsSomthingInTxtSearch() {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text)) {
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e) {
            Person newPerson = new Person();
            FrmAddOrUpdatePerson frm = new FrmAddOrUpdatePerson(newPerson);
            frm.ShowDialog();
        }
    }
}
