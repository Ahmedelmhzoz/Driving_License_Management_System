using BusinessLayer;
using PresentationLayer.Properties;
using Shared;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Local_License {
    public partial class ucLocalLicenseDetails : UserControl {
        public void ResetLicenseInfo() {
            lblLicenseID.Text = "Unknown";
            lblDriverID.Text = "Unknown";
            lblLicenseClass.Text = "Unknown";
            lblReleaseDate.Text = "Unknown";
            lblReleaseReason.Text = "Unknown";
            lblExpiteDate.Text = "Unknown";
            lblIsActive.Text = "Unknown";
            lblIsDetained.Text = "Unknown";
            lblNotes.Text = "No Notes";
            lblAdmin.Text = "Unknown";

            lblIsDetained.ForeColor = Color.DeepSkyBlue;
            lblIsActive.ForeColor = Color.DeepSkyBlue;
            pbVehicle.Image = Resources.question;
            ucPersonDetails.returnToDefault();
        }
        public ucLocalLicenseDetails() {
            InitializeComponent();
        }
        private string _GetIssueReasonText(enIssueReason issueReason) {
            switch (issueReason) {
                case enIssueReason.enFirstTime:
                    return "First Time";
                case enIssueReason.enRenew:
                    return "Renew";
                case enIssueReason.enReplacementForDamaged:
                    return "Replacement for Damaged";
                case enIssueReason.enReplacementForLost:
                    return "Replacement for Lost";
                default:
                    return "Unknown";
            }
        }
        void _changeLblByStatus(LocalLicense license) {
            enLocalLicenseStatus status = license.getLicenseStatus();
            if (status == enLocalLicenseStatus.Suspended) {
                lblIsActive.Text = "Suspended for damage or lost";
                lblIsActive.ForeColor = Color.Red;
            } else if (status == enLocalLicenseStatus.Expired){
                lblIsActive.Text = "Expired";
                lblIsActive.ForeColor = Color.DimGray;
            } else {
                lblIsActive.Text = "Active";
                lblIsActive.ForeColor = Color.SpringGreen;
            }
        }
        void _changeLbLByDenied(LocalLicense license) {
            if (license.isLicenseDenied()) {
                lblIsDetained.Text = "Detained";
                lblIsDetained.ForeColor = Color.Red;
            } else {
                lblIsDetained.Text = "Approved";
                lblIsDetained.ForeColor = Color.SpringGreen;
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
        void _ShowData(LocalLicense license) {
            lblLicenseID.Text = license.LicenseID.ToString();
            lblDriverID.Text = license.DriverID.ToString();
            if (license.licenseInfo == null) return;
            lblLicenseClass.Text = license.licenseInfo.className;
            enLicenseClass licenseClass = (enLicenseClass)license.licenseInfo.LicenseClassID;
            _viewVehicleImage(licenseClass);

            lblReleaseDate.Text = license.IssueDate.ToShortDateString();
            lblReleaseReason.Text = _GetIssueReasonText(license.IssueReason);
            lblExpiteDate.Text = license.ExpirationDate.ToShortDateString();
            _changeLblByStatus(license);
            lblNotes.Text = string.IsNullOrWhiteSpace(license.Notes) ? "No Notes" : license.Notes;
            _changeLbLByDenied(license);

            lblAdmin.Text = license.issuerUserInfo != null ? license.issuerUserInfo.Username : "Unknown";

            Applications licenseBasicApp = license.applicationInfo;

            if (licenseBasicApp == null) { Alert.ShowErrorMessage("Error while geting application"); return; }

            if (licenseBasicApp.personInfo == null) { Alert.ShowErrorMessage("Error while getting person info!"); return; }

            ucPersonDetails.loadData(licenseBasicApp.personInfo);
        }
        public void loadData(LocalLicense license) {
            if (license == null) {
                ResetLicenseInfo();
                return;
            }
            _ShowData(license);
        }
        public void SuspendLicense() {
            lblIsActive.Text = "Suspended for damage or lost";
            lblIsActive.ForeColor = Color.Red;
        }
        public void DenieLicense() {
            lblIsDetained.Text = "Detained";
            lblIsDetained.ForeColor = Color.Red;
        }
        public void approveLicense() {
            lblIsDetained.Text = "Approved";
            lblIsDetained.ForeColor = Color.SpringGreen;
        }
    }
}
