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

        private void btnNextPerson_Click(object sender, EventArgs e) {
            currentIDX = (currentIDX + 1) % currentSearchResult.Rows.Count;
            _ViewTheNextPerson();
        }

        Person convertDtRecordToObject(int idx) {
            Person person = null;
            int selectedID = (int)currentSearchResult.Rows[currentIDX]["PersonID"];
            if ((person = Person.findPerson(selectedID)) != null) {
                return person;
            }
            return null;
        }
        void _ViewTheNextPerson() {
            Person person = convertDtRecordToObject(currentIDX);
            ucPersonViewer.loadData(person);
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
        public void refrechResult() {
            currentSearchResult = Person.getCurrentSearchResult(txtSearch.Text, cbFilterBy.Text, true);// will get only persons who aren't linked to users 
            lblRecordsNo.Text = currentSearchResult.Rows.Count.ToString();
            if (currentSearchResult.Rows.Count == 0) {
                _NoResultScreen();
                return;
            }
            currentIDX = 0;
            if (currentSearchResult.Rows.Count == 1) {
                btnNextPerson.Enabled = false;
                lblNext.ForeColor = Color.DimGray;
            }
            else {
                btnNextPerson.Enabled = true;
                lblNext.ForeColor = Color.White;
            }
            _ViewTheNextPerson();
            OnPersonSelection?.Invoke(true);
        }
        
        void _NoResultScreen() {
            ucPersonViewer.returnToDefault();
            Helpers.ShowErrorMessage($"There is no result have {cbFilterBy.Text} = {txtSearch.Text}");
            btnNextPerson.Enabled = false;
            lblNext.ForeColor = Color.DimGray;
            OnPersonSelection?.Invoke(false);
        }
        private void btnSearch_Click(object sender, EventArgs e) {
            if (!_isTxtSearchFilled()) 
                return;
            refrechResult();
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
    }
}
