using DataLinkLayer;
using Shared;
using System;

namespace BusinessLayer {
    public class DetainLicense {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public string Reason { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }
        public DetainLicense() {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.Now;
            FineFees = 0;
            Reason = string.Empty;
            CreatedByUserID = -1;

            IsReleased = false;
            ReleaseDate = null;
            ReleasedByUserID = null;
            ReleaseApplicationID = null;
        }
        public static bool isLicenseDetained(int licenseID) {
            return DetainedLicensesData.IsLicenseDetained(licenseID);
        }
        public static DetainResult detainLicense(InputtedDetainDetails detainInputedData) {
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
    }
}
