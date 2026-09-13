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
using PresentationLayer.Users;
using Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace PresentationLayer {
    public partial class FrmDashboard : Form {
        public FrmDashboard() {
            InitializeComponent();
        }
        void _UnexpectedError() {
            Helpers.ShowErrorMessage("Unexpected error has happened");
        }
        void _FillLoadCbLics() {
            cbLocalLicStatus.DataSource = Enum.GetValues(typeof(enLocalLicenseStatus));
            cbIntLicStatus.DataSource = Enum.GetValues(typeof(enInternationalLicenseStatus));
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
            }
            catch {
                _UnexpectedError();
            }
        }

       
        private void FrmMainForm_Load(object sender, EventArgs e) {
             lblUsername.Text = ImportantSessionData.user.Username;
            _FillLoadCbLics();
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
    }
}
