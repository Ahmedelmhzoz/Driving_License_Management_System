using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared {
    public static class Utilities {
        public static string _ConverStatusEnumToString(enApplicationStatus status) {
            switch (status) {
                case enApplicationStatus.enNew: return "New";
                case enApplicationStatus.enCanceled: return "Canceled";
                case enApplicationStatus.enCompleted: return "Completed";
                default: return "Unknown";
            }
        }
        public static int convertTestTypeToID(enTestType testType) {
            switch (testType) {
                case enTestType.Vision: return 1;
                case enTestType.Theoretical: return 2;
                case enTestType.Street: return 3;
                default: return 1;
            }
        }
        public static string convertTestTypeToString(enTestType testType) {
            switch (testType) {
                case enTestType.Vision: return "Vision Test";
                case enTestType.Theoretical: return "Written Test";
                case enTestType.Street: return "Street Test";
                default: return "Vision Test";
            }
        }
        public static DateTime? returnStartPoint(enPeriod period) {
            switch (period) {
                case enPeriod.Day: return DateTime.Today;
                case enPeriod.Week: return DateTime.Today.AddDays(-6);
                case enPeriod.Month: return new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                case enPeriod.Year: return new DateTime(DateTime.Today.Year, 1, 1);
                default: return null;
            }
        }
        public static string getApplicationTypeName(enApplicationType applicationType) {
            switch (applicationType) {
                case enApplicationType.NewLocalDrivingLicense:
                    return "New Local License";

                case enApplicationType.RenewDrivingLicense:
                    return "Renew License";

                case enApplicationType.ReplaceLostDrivingLicense:
                    return "Replace Lost License";

                case enApplicationType.ReplaceDamagedDrivingLicense:
                    return "Replace Damaged License";

                case enApplicationType.ReleaseDetainedDrivingLicense:
                    return "Release Detained License";

                case enApplicationType.NewInternationalLicense:
                    return "New International License";

                case enApplicationType.RetakeTest:
                    return "Retake Test";

                default:
                    return "Unknown";
            }
        }
        public static string getLicenseClassName(enLicenseClass licenseClass) {
            switch (licenseClass) {
                case enLicenseClass.SmallMotorcycle:
                    return "Small Motorcycle";

                case enLicenseClass.HeavyMotorcycle:
                    return "Heavy Motorcycle";

                case enLicenseClass.Ordinary:
                    return "Ordinary";

                case enLicenseClass.Commercial:
                    return "Commercial";

                case enLicenseClass.Agricultural:
                    return "Agricultural";

                case enLicenseClass.SmallMediumBus:
                    return "Small & Medium Bus";

                case enLicenseClass.TruckHeavyVehicle:
                    return "Truck & Heavy Vehicle";

                default:
                    return "Unknown";
            }
        }
    }
}