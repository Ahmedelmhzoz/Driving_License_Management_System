using BusinessLayer.Dashboard;
using Global;
using PresentationLayer.Detain_license;
using PresentationLayer.International_License;
using PresentationLayer.Licenses_and_drivers;
using PresentationLayer.Local_DL_Appliaction;
using PresentationLayer.Manage_types;
using PresentationLayer.Properties;
using PresentationLayer.Renew_license;
using PresentationLayer.Replacement_app;
using System.Windows.Forms.DataVisualization.Charting;
using PresentationLayer.Users;
using Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
namespace PresentationLayer {
    public partial class FrmDashboard : Form {
        public FrmDashboard() {
            InitializeComponent();
        }
        void _UnexpectedError() {
            Helpers.ShowErrorMessage("Unexpected error has happened");
        }
        void _FillEnumComboBoxes() {
            cbLocalLicStatus.DataSource = Enum.GetValues(typeof(enLocalLicenseStatus));
            cbIntLicStatus.DataSource = Enum.GetValues(typeof(enInternationalLicenseStatus));
            cbAppPeriod.DataSource = Enum.GetValues(typeof(enPeriod));
        }
        void _ViewApplicationTypeImage(enApplicationType applicationType) {
            switch (applicationType) {
                case enApplicationType.NewLocalDrivingLicense:
                    pbApplicationType.Image = Resources.driving_school__1_;
                    break;

                case enApplicationType.RenewDrivingLicense:
                    pbApplicationType.Image = Resources.refresh;
                    break;

                case enApplicationType.ReplaceLostDrivingLicense:
                    pbApplicationType.Image = Resources.loss;
                    break;

                case enApplicationType.ReplaceDamagedDrivingLicense:
                    pbApplicationType.Image = Resources.cut_card;
                    break;

                case enApplicationType.ReleaseDetainedDrivingLicense:
                    pbApplicationType.Image = Resources.validation;
                    break;

                case enApplicationType.NewInternationalLicense:
                    pbApplicationType.Image = Resources.driving_license__7_;
                    break;

                case enApplicationType.RetakeTest:
                    pbApplicationType.Image = Resources.examination;
                    break;
            }
        }
        void _viewVehicleImage(enLicenseClass licenseClass) {
            switch (licenseClass) {
                case enLicenseClass.Ordinary:
                    pbVehicle.Image = Resources.car;
                    break;
                case enLicenseClass.SmallMotorcycle:
                    pbVehicle.Image = Resources.scooter;
                    break;
                case enLicenseClass.HeavyMotorcycle:
                    pbVehicle.Image = Resources.motorbike;
                    break;
                case enLicenseClass.Commercial:
                    pbVehicle.Image = Resources.taxi;
                    break;
                case enLicenseClass.Agricultural:
                    pbVehicle.Image = Resources.vehicle;
                    break;
                case enLicenseClass.SmallMediumBus:
                    pbVehicle.Image = Resources.bus;
                    break;
                case enLicenseClass.TruckHeavyVehicle:
                    pbVehicle.Image = Resources.delivery;
                    break;
            }
        }
        void _fillVehicleTypesComboBox() {
            Dictionary<string, enLicenseClass> vehicleTypes = new Dictionary<string, enLicenseClass>()
            {
                { "Ordinary", enLicenseClass.Ordinary },
                { "Small Motorcycle", enLicenseClass.SmallMotorcycle },
                { "Heavy Motorcycle", enLicenseClass.HeavyMotorcycle },
                { "Commercial", enLicenseClass.Commercial },
                { "Agricultural", enLicenseClass.Agricultural },
                { "Small & Medium Bus", enLicenseClass.SmallMediumBus },
                { "Truck & Heavy Vehicle", enLicenseClass.TruckHeavyVehicle }
            };

            cbVehicleType.DataSource = new BindingSource(vehicleTypes, null);
            cbVehicleType.DisplayMember = "Key";
            cbVehicleType.ValueMember = "Value";
        }
        void _FillCbApplicationsPerType() {
            Dictionary<string, enApplicationType> appTypes = new Dictionary<string, enApplicationType>()
            {
                { "New Local License", enApplicationType.NewLocalDrivingLicense },
                { "Renew License", enApplicationType.RenewDrivingLicense },
                { "Replace Lost License", enApplicationType.ReplaceLostDrivingLicense },
                { "Replace Damaged License", enApplicationType.ReplaceDamagedDrivingLicense },
                { "Release Detained License", enApplicationType.ReleaseDetainedDrivingLicense },
                { "New International License", enApplicationType.NewInternationalLicense },
                { "Retake Test", enApplicationType.RetakeTest }
            };
            cbAppTypes.DataSource = new BindingSource(appTypes, null);
            cbAppTypes.DisplayMember = "Key";
            cbAppTypes.ValueMember = "Value";
        }
        void _RefreshApplicationsCard() {
            KeyValuePair<string, enApplicationType> selectedItem = (KeyValuePair<string, enApplicationType>)cbAppTypes.SelectedItem;
            _ViewApplicationTypeImage(selectedItem.Value);
            try {
                lblAppPerType.Text = Dashboard.getApplicationsForType(selectedItem.Value).ToString();
            }
            catch {
                _UnexpectedError();
            }
        }
        void _RefreshLocalLicesesCard() {
            try {
                lblTotalLocalPerStatus.Text =
                    Dashboard.getLocalLicensesByStatus((enLocalLicenseStatus)cbLocalLicStatus.SelectedItem).ToString();
            }
            catch {
                _UnexpectedError();
            }
        }
        void _RefreshInternationalLicesesCard() {
            try {
                lblTotalIntLicPerStatus.Text =
                    Dashboard.getInternationLincesesByStatus((enInternationalLicenseStatus)cbIntLicStatus.SelectedItem).ToString();
            }
            catch {
                _UnexpectedError();
            }
        }
        void _RefreshLicensesPerViclCard() {
            KeyValuePair<string, enLicenseClass> selectedItem = (KeyValuePair<string, enLicenseClass>)cbVehicleType.SelectedItem;
            _viewVehicleImage(selectedItem.Value);
            try {
                lblTotalLicPerVicl.Text =
                    Dashboard.getLicensesPerVehicle(selectedItem.Value).ToString();
            }
            catch {
                _UnexpectedError();
            }
        }
        void _RefreshAppInPeriod() {
            try {
                lblAppsInPeriod.Text =
                    Dashboard.getApplicationsInPeriod((enPeriod)cbAppPeriod.SelectedItem).ToString();
            }
            catch {
                _UnexpectedError();
            }
        }
        void _RefreshAppStatistics() {
            try {
                Series series = cApplications.Series["Application Types"];
                series.Points.Clear();
                List<KeyValuePair<enApplicationType, int>> records = Dashboard.getAppsPerTypeInPeriod((enPeriod)cbAppPeriod.SelectedItem);
                foreach (KeyValuePair<enApplicationType, int> record in records) {
                    series.Points.AddXY(Utilities.getApplicationTypeName(record.Key), record.Value);
                }
            }
            catch {
                _UnexpectedError();
            }
        }
        void _RefreshLicensesStat() {
            try {
                // Local licnese chart
                Series series = cLocalLicensseStatus.Series["Local license status"];
                series.Points.Clear();

                List<KeyValuePair<string, int>> records = Dashboard.getLocalLicenseStatusDistribution();
                double total = records.Sum(x => x.Value);

                foreach (KeyValuePair<string, int> record in records) {
                    series.Points.AddY(record.Value);
                    DataPoint point = series.Points[series.Points.Count - 1];

                    if (record.Key == "Active") 
                        point.Color = Color.SpringGreen;
                    else if (record.Key == "Suspended")
                        point.Color = Color.Red;
                    else
                        point.Color = Color.Gray;

                    double percentage = (record.Value / total);
                    point.LegendText = $"{record.Key} {percentage:P1}";
                }

                // International license chart
                series = cInternationalLicense.Series["International license status"];
                series.Points.Clear();

                records = Dashboard.getIntLicenseStatusDistribution();
                total = records.Sum(x => x.Value);

                foreach(KeyValuePair<string, int> record in records) {
                    series.Points.AddY(record.Value);
                    DataPoint point = series.Points[series.Points.Count - 1];

                    point.Label = "";
                    if (record.Key == "Active") 
                        point.Color = Color.SpringGreen;
                    else 
                        point.Color = Color.DimGray;

                    double percentage = (record.Value / total);
                    point.LegendText = $"{record.Key} {percentage:P1}";
                }

                // licensed vehicles chart
                series = cLicenseClasses.Series["License classes"];
                series.Points.Clear();

                List<KeyValuePair<enLicenseClass, int>> licenseClassesRecords = Dashboard.getLicensesPerVehicleDistribution();
                total = licenseClassesRecords.Sum(x => x.Value);

                foreach (KeyValuePair<enLicenseClass, int> record in licenseClassesRecords) {
                    series.Points.AddY(record.Value);
                    DataPoint point = series.Points[series.Points.Count - 1];

                    double percentage = (record.Value / total);
                    point.LegendText = $"{Utilities.getLicenseClassName(record.Key)} {percentage:P1}";

                }
            }
            catch {
                _UnexpectedError();
            }
        }

        void _SetPercentageInTestCharts(enTestType testType, double passRate, double failRate) {
            Series series = null;
            switch(testType) {
                case enTestType.Vision: series = cVision.Series["Vision pass rate"]; break;
                case enTestType.Theoretical: series = cTheoretical.Series["Theoretical pass rate"]; break;
                case enTestType.Street: series = cStreet.Series["Street pass rate"]; break;
            }
            series.Points.AddY(passRate);
            int idx = series.Points.Count - 1;
            DataPoint point = series.Points[idx];
            point.LegendText = $"Pass {passRate:P1}";
            point.Color = Color.SpringGreen;

            series.Points.AddY(failRate);
            point = series.Points[idx + 1];
            point.LegendText = $"Fail {failRate:P1}";
            point.Color = Color.Red;
        }
        void _RefreshAppintmentsStat() {
            try {
                AppointmentsStatistics appointmentsStatistics = Dashboard.getAppointmenrsStatistics();
                lblTakenVision.Text = appointmentsStatistics.takenTestsPerType.First(X => X.Key == enTestType.Vision).Value.ToString();
                lblTakenTheoretical.Text = appointmentsStatistics.takenTestsPerType.First(X => X.Key == enTestType.Theoretical).Value.ToString();
                lblTakenStreet.Text = appointmentsStatistics.takenTestsPerType.First(X => X.Key == enTestType.Street).Value.ToString();

                foreach (KeyValuePair<enTestType, (double passRate, double failRate)> record in appointmentsStatistics.PassFailTestRatesPerType) {
                    _SetPercentageInTestCharts(record.Key, record.Value.passRate, record.Value.failRate);
                }

                lblTodayVision.Text = appointmentsStatistics.todayAppointmentsPerType.First(X => X.Key == enTestType.Vision).Value.ToString();
                lblTodayTheoretical.Text = appointmentsStatistics.todayAppointmentsPerType.First(X => X.Key == enTestType.Theoretical).Value.ToString();
                lblTodayStreet.Text = appointmentsStatistics.todayAppointmentsPerType.First(X => X.Key == enTestType.Street).Value.ToString();
            }
            catch {
                _UnexpectedError();
            }
        }

        void _Refresh() {
            try {
                lblPeople.Text = Dashboard.getPeopleNumber().ToString();
                lblUsers.Text = Dashboard.getUsersNumber().ToString();
                lblDrivers.Text = Dashboard.getDriversNumber().ToString();
                lblPendingTests.Text = Dashboard.getPendingTests().ToString();
                lblDetainedLics.Text = Dashboard.getDetainedLicenses().ToString();
                _RefreshApplicationsCard();
                _RefreshLocalLicesesCard();
                _RefreshInternationalLicesesCard();
                _RefreshLicensesPerViclCard();
                _RefreshAppInPeriod();
                _RefreshAppStatistics();
                _RefreshLicensesStat();
                _RefreshAppintmentsStat();
            }
            catch {
                _UnexpectedError();
            }
        }

        private void FrmMainForm_Load(object sender, EventArgs e) {
             lblUsername.Text = ImportantSessionData.user.Username;
            _FillEnumComboBoxes();
             _FillCbApplicationsPerType();
            _fillVehicleTypesComboBox();
            _Refresh();
        }
        private void cbAppTypes_SelectedIndexChanged(object sender, EventArgs e) {
            _RefreshApplicationsCard();
        }
        private void cbLocalLicStatus_SelectedIndexChanged(object sender, EventArgs e) {
            _RefreshLocalLicesesCard();
        }
        private void cbIntLicStatus_SelectedIndexChanged(object sender, EventArgs e) {
            _RefreshInternationalLicesesCard();
        }
        private void cbVehicleType_SelectedIndexChanged(object sender, EventArgs e) {
            _RefreshLicensesPerViclCard();
        }
        private void cbAppPeriod_SelectedIndexChanged_1(object sender, EventArgs e) {
            _RefreshAppInPeriod();
            _RefreshAppStatistics();
        }
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmPeople frm = new FrmPeople();
            frm.ShowDialog();
            _Refresh();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmUsers frm = new FrmUsers();
            frm.ShowDialog();
            _Refresh();

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Hide();
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();

        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmUserDetails frm = new FrmUserDetails(ImportantSessionData.user);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmChangePassword frm = new FrmChangePassword(ImportantSessionData.user);
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmApplicationTypes frm = new FrmApplicationTypes();
            frm.ShowDialog();
            _Refresh();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmTestTypes frm = new FrmTestTypes();
            frm.ShowDialog();
        }

        private void LocalLicense_Click(object sender, EventArgs e) {
            FrmSelectPersonForApp frm = new FrmSelectPersonForApp();
            frm.ShowDialog();
            _Refresh();
        }


        private void localLicenseManagement_Click(object sender, EventArgs e) {
            FrmLocalLicenseAppManagement frm = new FrmLocalLicenseAppManagement();
            frm.ShowDialog();
            _Refresh();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmDrivers frm = new FrmDrivers();
            frm.ShowDialog();
        }

        private void internationalLicense_Click(object sender, EventArgs e) {
            FrmInternationalApplication frm = new FrmInternationalApplication();
            frm.ShowDialog();
            _Refresh();
        }

        private void internationalLicenseManagement_Click(object sender, EventArgs e) {
            FrmInternationalLicensesManagement frm = new FrmInternationalLicensesManagement();
            frm.ShowDialog();
            _Refresh();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmRenewLicense frm  = new FrmRenewLicense();
            frm.ShowDialog();
            _Refresh();
        }

        private void replaceLicenseForDamageOrLosToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmReplacementApp frm = new FrmReplacementApp();
            frm.ShowDialog();
            _Refresh();
        }

        private void detainALicenseToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmDetainLicense frm = new FrmDetainLicense();
            frm.ShowDialog();
            _Refresh();
        }

        private void releaseALicenseToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmReleaseLicense frm = new FrmReleaseLicense();
            frm.ShowDialog();
            _Refresh();
        }

        private void manageDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e) {
            FrmDetainManagement frm = new FrmDetainManagement();
            frm.ShowDialog();
            _Refresh();
        }

 

        private void tbApplicationsStat_Click(object sender, EventArgs e) {

        }

        private void label24_Click(object sender, EventArgs e) {

        }

        private void pictureBox17_Click(object sender, EventArgs e) {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            if (tcStatistics.SelectedTab == tbLicenses) {
                _RefreshLicensesStat();
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e) {

        }

        private void groupBox7_Enter(object sender, EventArgs e) {

        }

        private void panel15_Paint(object sender, PaintEventArgs e) {

        }
    }
}
