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

namespace PresentationLayer.Tests_and_appointments {
    public partial class FrmTestDetails : Form {
        TestResult testResult = null;
        public FrmTestDetails(TestResult testResult) {
            InitializeComponent();
            this.testResult = testResult;
        }

        private void FrmTestDetails_Load(object sender, EventArgs e) {
            lblTestID.Text = testResult.TestID.ToString();

            lblTestTitle.Text = testResult.TestTypeTitle;

            lblApplicantName.Text = testResult.ApplicantName;

            lblUsername.Text = testResult.TesterUsername;

            lblAttemptNumber.Text = testResult.attemptNumber.ToString();

            lblResult.Text = testResult.TestResultValue ? "Passed" : "Failed";

            lblResult.ForeColor =
                testResult.TestResultValue ? Color.SpringGreen : Color.Red;

            txtNotes.Text = testResult.Notes;
        }
    }
}
