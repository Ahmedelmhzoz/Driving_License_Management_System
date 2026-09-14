using DataLinkLayer;
using DataLinkLayer.License_Application_data;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dashboard {
    public static class Dashboard {
        public static int getPeopleNumber() {
            return PeopleData.getPeopleNumber();
        }
        public static int getUsersNumber() {
            return UsersData.getUsersNumber();
        }
        public static int getDriversNumber() {
            return clsDriverData.getDriversNumber();
        }
        public static int getApplicationsForType(enApplicationType applicationType) {
            return ApplicationsData.getApplicationsNumByType(applicationType);
        }
        public static int getLocalLicensesByStatus(enLocalLicenseStatus status) {
            return LocalLicensesData.getLicensesNumByStatus(status);
        }
        public static int getInternationLincesesByStatus(enInternationalLicenseStatus status) {
            return InternationalLicenseData.getLicensesNumByStatus(status);
        }
        public static int getLicensesPerVehicle(enLicenseClass licenseClass) {
            return LocalLicensesData.getLicensesNumByLicenseClass(licenseClass);
        }
        public static int getPendingTests() {
            return TestAppointmentsData.getPendingAppointmentsNum();
        }
        public static int getDetainedLicenses() {
            return DetainedLicensesData.getDetainedLicensesNum();
        }
        public static int getApplicationsInPeriod(enPeriod period) {
            return ApplicationsData.getApplicationsNumInPeriod(period);
        }
        public static List<KeyValuePair<enApplicationType, int>> getAppsPerTypeInPeriod(enPeriod period)  {
            return ApplicationsData.getAppsPerTypeInPeriod(period);
        }

    } 
}
