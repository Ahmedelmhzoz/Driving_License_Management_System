using DataLinkLayer;
using DataLinkLayer.License_Application_data;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public static List<KeyValuePair<string, int>> getLocalLicenseStatusDistribution() {
            return LocalLicensesData.getLicensesPerStatus();
        }
        public static List<KeyValuePair<string, int>> getIntLicenseStatusDistribution() {
            return InternationalLicenseData.getLicensesPerStatus();
        }
        public static List<KeyValuePair<enLicenseClass, int>> getLicensesPerVehicleDistribution() {
            return LocalLicensesData.getLicensesPerVehicles();
        }
        public static AppointmentsStatistics getAppointmenrsStatistics() {
            return TestAppointmentsData.getAppintmentsStatistics();
        }
        public static RevenueStatistics GetRevenueStatistics() {
            RevenueStatistics revenueStatistics = RevenueData.GetRevenueStatistics();
            decimal totalApplicationsFees = revenueStatistics.totalRevPerApp.Sum(TypeFees => TypeFees.Value);
            revenueStatistics.totalRevPerProcess.Add(enFinancialProceesType.Applications, (totalApplicationsFees, 0d));

            decimal totalTestsFees = revenueStatistics.totalRevPerTest.Sum(TestFees => TestFees.Value);

            revenueStatistics.totalRevPerProcess.Add(enFinancialProceesType.Tests, (totalTestsFees, 0d));

            decimal totalGeneralRevenue = revenueStatistics.totalRevPerProcess.Sum(processFees => processFees.Value.amount);

            foreach (enFinancialProceesType proceesType in Enum.GetValues(typeof(enFinancialProceesType))) {
                var processInfo = revenueStatistics.totalRevPerProcess[proceesType];
                processInfo.percentage = (double)totalGeneralRevenue == 0 ? 0 : (double)revenueStatistics.totalRevPerProcess[proceesType].amount /  (double)totalGeneralRevenue;
                revenueStatistics.totalRevPerProcess[proceesType] = processInfo;
            }

            return revenueStatistics;
        }
    } 
}
