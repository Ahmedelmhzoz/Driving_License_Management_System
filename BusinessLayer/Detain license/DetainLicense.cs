using DataLinkLayer;
using DataLinkLayer.License_Application_data;
using Microsoft.SqlServer.Server;
using Shared;
using System;
using System.Data;
using System.Net;

namespace BusinessLayer {
    public class DetainLicense {
        public static bool isLicenseDetained(int licenseID) {
            return DetainedLicensesData.IsLicenseDetained(licenseID);
        }
        public static DetainResult detainLicense(DetainDetails detainInputedData) {
            if (isLicenseDetained(detainInputedData.LicenseID))
                return new DetainResult {
                    detainRecordID = -1,
                    result = enDetainResult.AlreadyDetained
                };

            if (detainInputedData.fineFees > 1000 || detainInputedData.fineFees < 1)
                return new DetainResult {
                    detainRecordID = -1,
                    result = enDetainResult.FineOutOfRange
                };

            DetainDTO detainDTO = new DetainDTO(detainInputedData);
            int detainID = DetainedLicensesData.detainLicense(detainDTO);

            return new DetainResult {
                detainRecordID = detainID,
                result = enDetainResult.Success
            };
        }
        public static DetainDetails getDetainDetails(int licenseID) {
            DetainDTO detainDTO = DetainedLicensesData.getDetainDetails(licenseID);
            if (detainDTO == null) return null;
            detainDTO.LicenseID = licenseID;
            DetainDetails detainLicense = new DetainDetails(detainDTO.LicenseID,
                detainDTO.DetainDate, detainDTO.FineFees, detainDTO.Reason, detainDTO.CreatedByUserID, detainDTO.DetainID);
            return detainLicense;
        }
        public static void releaseDetainedLicense(ref ReleaseDetails releaseDetails, int personID) {

            ApplicationDTO releaseApplication = Applications.createAppOfSomeKind(releaseDetails.createdByUserID, personID, enApplicationType.ReleaseDetainedDrivingLicense);
            if (releaseApplication == null) { throw new Exception("Failed to create replacemet new app"); }

            ReleaseDTO releaseDTO = new ReleaseDTO(releaseDetails);
            DetainedLicensesData.releaseLicense(releaseApplication, ref releaseDTO);
            releaseDetails.applicationID = releaseDTO.applicationID;
        }
        public static DataTable getAllDetainedLicenses() {
            return DetainedLicensesData.getAllDetainedLicenses();
        }
        static string _MapEnumToActualText(enDetaintionStatus status) {
            if (status == enDetaintionStatus.Detained) {
                return "Detained";
            } else {
                return "Released";
            }
        }
        public static DataTable getDetentionsByDetaintionStatus(enDetaintionStatus status) {
            return DetainedLicensesData.getByFilter(enDetainFilterBy.DetaintionStatus, _MapEnumToActualText(status));
        }
        public static DataTable getDetentionsByFilter(enDetainFilterBy status, string filterValue) {
            return DetainedLicensesData.getByFilter(status, filterValue);
        }
    }
}
