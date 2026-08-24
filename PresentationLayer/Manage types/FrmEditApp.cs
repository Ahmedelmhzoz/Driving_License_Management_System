using BusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;
using Global;
namespace PresentationLayer.Manage_types {
    public partial class FrmEditApp : Form {
        AppType appType = null;
        public FrmEditApp(AppType appType) {
            InitializeComponent();
            this.appType = appType;
        }

        private void FrmEditApp_Load(object sender, EventArgs e) {
            lblID.Text = appType.AppTypeID.ToString();
            txtTitle.Text = appType.AppTypeTitle;
            nFees.Value = appType.AppTypeFees;
        }
        bool _AreEveryThingValid() {
            bool isValid = true;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtTitle.Text)) {
                errorProvider1.SetError(txtTitle, "Title is required!");
                isValid = false;
            }
            if (nFees.Value < 1) {
                errorProvider1.SetError(nFees, "Fees is required!");
                isValid = false;
            }
            return isValid;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (!_AreEveryThingValid())
                return;
            decimal oldFee = appType.AppTypeFees;
            appType.AppTypeTitle = txtTitle.Text;
            appType.AppTypeFees = nFees.Value;
            if (appType.Save()) {
                Helpers.SuccessfulMessage("Application type updated successfully!");
                if (oldFee > appType.AppTypeFees) 
                    nFees.BackColor = Color.OrangeRed;
                else if (oldFee < appType.AppTypeFees)
                    nFees.BackColor = Color.SpringGreen;
            }
            else {
                Helpers.ShowErrorMessage("something went wrong");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
