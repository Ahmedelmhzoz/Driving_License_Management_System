using BusinessLayer;
using BusinessLayer.License_Applications;
using PresentationLayer.Properties;
using Shared;
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
using static System.Windows.Forms.DataGrid;

namespace PresentationLayer.Local_DL_Appliaction {
    public partial class FrmAppointments : Form {
        LocalLicenseApp licenseApp = null;
        enTestType testType = enTestType.enVision;
        public FrmAppointments(LocalLicenseApp licenseApp, enTestType testType) {
            InitializeComponent();
            this.licenseApp = licenseApp;
            this.testType = testType;
        }
        void _setTestImageAndLable() {
            if (testType == enTestType.enVision) 
                pbTestType.Image = Resources.vision;
            else if (testType == enTestType.enWritten) 
                pbTestType.Image = Resources.writtenTest;
            else 
                pbTestType.Image = Resources.streets;
            pbTestType.SizeMode = PictureBoxSizeMode.Zoom;
            lblTestType.Text = Utilities.convertTestTypeToString(testType) + " Appointments";
        }
        void _fillDgvWithAppropraitData() {
                dgvAppointments.DataSource = TestAppointments.getAppointmentsForTestType(licenseApp.LicenseAppID, testType);
        }
        private void FrmAppointments_Load(object sender, EventArgs e) {
            _setTestImageAndLable();
            ucLocalDrivingLicenseDetails1.loadData(licenseApp);
            _fillDgvWithAppropraitData();
            lblRecordsNo.Text = dgvAppointments.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
