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
    public partial class FrmEditTest : Form {
        TestType testType = null;

        public FrmEditTest(TestType testType) {
            InitializeComponent();
            this.testType = testType;
        }

        private void FrmEditTest_Load(object sender, EventArgs e) {
            lblID.Text = testType.TestTypeID.ToString();
            txtTitle.Text = testType.TestTypeTitle;
            txtDescription.Text = testType.TestTypeDescription;
            nFees.Value = testType.TestTypeFees;
        }

        bool _AreEveryThingValid() {
            bool isValid = true;
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtTitle.Text)) {
                errorProvider1.SetError(txtTitle, "Title is required!");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text)) {
                errorProvider1.SetError(txtDescription, "Description is required!");
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

            decimal oldFee = testType.TestTypeFees;

            testType.TestTypeTitle = txtTitle.Text;
            testType.TestTypeDescription = txtDescription.Text;
            testType.TestTypeFees = nFees.Value;

            if (testType.Save()) {
                Helpers.SuccessfulMessage("Test type updated successfully!");

                if (oldFee > testType.TestTypeFees)
                    nFees.BackColor = Color.OrangeRed;
                else if (oldFee < testType.TestTypeFees)
                    nFees.BackColor = Color.SpringGreen;
            }
            else {
                Helpers.ShowErrorMessage("Something went wrong");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
