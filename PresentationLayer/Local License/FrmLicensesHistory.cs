using BusinessLayer;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Licenses {
    public partial class FrmLicensesHistory : Form {
        Person person = null;
        public FrmLicensesHistory(Person person) {
            InitializeComponent();
            this.person = person;
        }

        private void FrmLicensesHistory_Load(object sender, EventArgs e) {
            ucPersonDetails.loadData(person);
            ucDrivingLicenses.loadLicensesHistoryForPerson(person.personID);
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

    }
}
