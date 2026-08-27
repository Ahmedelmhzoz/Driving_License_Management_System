using BusinessLayer;
using BusinessLayer.License_Applications;
using Global;
using PresentationLayer.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;
using Shared;

namespace PresentationLayer.Local_DL_Appliaction {
    public partial class FrmSelectPersonForApp : Form {
        LocalLicenseApp licenseApplication = null;
        bool personIsFounded = false;

        public FrmSelectPersonForApp() {
            InitializeComponent();
            ucGetPersonWithFilter.OnPersonSelection += _ButtonActivation;
            licenseApplication = new LocalLicenseApp();
        }
        public FrmSelectPersonForApp(LocalLicenseApp appToEdit) {
            InitializeComponent();
            licenseApplication = appToEdit;
        }

        void _fillComboBoxWithLicenseClasses() {
            cbLicenseClasses.DataSource = LicenseClasses.getLicenseClasses();
            cbLicenseClasses.DisplayMember = "ClassName";
            cbLicenseClasses.ValueMember = "LicenseClassID";
        }
        void _putUserNameINlable() {
            User user = User.getUserByID(licenseApplication.createdByUserID);
            lblUser.Text = user.Username;
        }
        void _fillApplicantInfoInCard() {
            Person person = Person.findPerson(licenseApplication.personID);
            ucPersonDetails.loadData(person);
        }
        private void FrmSelectPersonForApp_Load(object sender, EventArgs e) {
            _fillComboBoxWithLicenseClasses();
            if (licenseApplication.currentMode == enAppMode.addApp) {
                lblProcess.Text = "New Local Driving License Application";
                tpPerson.Text = "Find Person";
                ucGetPersonWithFilter.Visible = true;
                ucPersonDetails.Visible = false;
                lblUser.Text = ImportantSessionData.user.Username;
            }
            else {
                lblProcess.Text = "Update Local Driving License Application";
                tpPerson.Text = "Applicant info.";
                btnNext.Visible = false;
                ucGetPersonWithFilter.Visible = false;
                ucPersonDetails.Visible = true;
                _fillApplicantInfoInCard();

                cbLicenseClasses.SelectedValue = licenseApplication.LicenseClassID;
                personIsFounded = true;
                lblSubmit.ForeColor = Color.DimGray;
                btnSubmitApp.Enabled = false;
                lblSubmit.Text = "Update the application";

                btnSubmitApp.BackgroundImage = Resources.editApplication;
                lblAppID.Text = licenseApplication.LicenseAppID.ToString();
                lblDate.Text = licenseApplication.AppDate.ToLongDateString();
                _putUserNameINlable();
            }
            
        }
        void _ButtonActivation(bool IsSelected) {
            btnNext.Enabled = IsSelected;
            personIsFounded = IsSelected;
        }
        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void btnNext_Click(object sender, EventArgs e) {
            tcApplicationManagement.SelectedTab = tpAppInfo;
        }
        private void tcAddUser_SelectedIndexChanged(object sender, EventArgs e) {
            if (tcApplicationManagement.SelectedTab == tpAppInfo && !personIsFounded && licenseApplication.currentMode == enAppMode.addApp) {
                // if he moved to the next tap before selecting a person
                tcApplicationManagement.SelectedTab = tpPerson;
                Helpers.ShowErrorMessage("You cant move to the next tap before you select a person");
            }
            else if (tcApplicationManagement.SelectedTab == tpAppInfo && personIsFounded && licenseApplication.currentMode == enAppMode.addApp) {
                // if he moved to the next tap after selecting a person
                lblAppID.BackColor = Color.Black;
                cbLicenseClasses.SelectedIndex = 0;
                lblDate.Text = DateTime.Now.ToLongDateString();
                lblAppID.Text = "Unknown";
            }
           
        }

        private void cbLicenseClasses_SelectedIndexChanged(object sender, EventArgs e) {
            btnSubmitApp.Enabled = true;
            lblSubmit.ForeColor = Color.White;
        }

        bool _IsSavingWentSuccessfully(enHowDidSavingGo result) {
            bool successfulSaving = false;
            switch (result) {
                case enHowDidSavingGo.enNotAllowedAge:
                    Helpers.ShowErrorMessage("Person age is below the minimum allowed age for this license training course!");
                    break;
                case enHowDidSavingGo.enErrorWhileSavingLicenseApp:
                case enHowDidSavingGo.enErrorWhileSavingOriginalApp:
                    Helpers.ShowErrorMessage("Error happend while saving Local driving license application !");
                    break;
                case enHowDidSavingGo.enSaved:
                    Helpers.SuccessfulMessage("Application saved successfully!");
                    successfulSaving = true;
                    break;
            }
            return successfulSaving;
        }
        void _AppAddedSuccessfully() {
            lblAppID.Text = licenseApplication.LicenseAppID.ToString();
            lblAppID.BackColor = Color.SpringGreen;
            lblSubmit.ForeColor = Color.DimGray;
            btnSubmitApp.Enabled = false;
            licenseApplication = new LocalLicenseApp();
        }
        bool _IsAppNewOfItsClass(int LicenseClassID) {
            int personID = licenseApplication.currentMode == enAppMode.addApp ? ucGetPersonWithFilter.getPersonID() : licenseApplication.personID;
            int activeAppID;
            if ((activeAppID = LocalLicenseApp.DidPersonMakeSameApplication(personID, LicenseClassID)) != -1) {
                // there is active application to this person 
                Helpers.ShowErrorMessage($"Person already has an active application for this class with ApplicationID = {activeAppID}!");
                return false;
            }
            return true;
        }
        private void btnSubmitApp_Click(object sender, EventArgs e) {
            if (!_IsAppNewOfItsClass(Convert.ToInt32(cbLicenseClasses.SelectedValue))) 
                return;
            enAppMode WhatPersonModeWas = licenseApplication.currentMode;
            if (licenseApplication.currentMode == enAppMode.addApp) {
                licenseApplication.AppDate = DateTime.Now;
                licenseApplication.lastStatusDate = DateTime.Now;
                licenseApplication.ApplicaitionTypeID = 1; // new local driving license application
                licenseApplication.lastStatusDate = DateTime.Now;
                AppType ldApp = AppType.getApplicationType(1);
                licenseApplication.paidFees = ldApp.AppTypeFees;
                licenseApplication.createdByUserID = ImportantSessionData.user.userID;
            }
            licenseApplication.LicenseClassID = Convert.ToInt32(cbLicenseClasses.SelectedValue);

            enHowDidSavingGo result = licenseApplication.SaveLicenseApp();
            if (_IsSavingWentSuccessfully(result)) {
                if (WhatPersonModeWas == enAppMode.addApp) {
                    _AppAddedSuccessfully();
                } else {
                    this.Close();
                }
            }
        }
    }
}
