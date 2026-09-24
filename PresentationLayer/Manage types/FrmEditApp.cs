using BusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;
using Shared;
namespace PresentationLayer.Manage_types {
    public partial class FrmEditApp : Form {
        ApplicationType appType = null;
        public FrmEditApp(ApplicationType appType) {
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
            appType.AppTypeFees = nFees.Value;
            if (appType.Save()) {
                Alert.SuccessfulMessage("Application type updated successfully!");
                if (oldFee > appType.AppTypeFees) 
                    nFees.BackColor = Color.OrangeRed;
                else if (oldFee < appType.AppTypeFees)
                    nFees.BackColor = Color.SpringGreen;
            }
            else {
                Alert.ShowErrorMessage("something went wrong");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
