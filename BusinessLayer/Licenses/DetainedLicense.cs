using DataLinkLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Licenses {
    public class DetainedLicense {
        public enum enDatainedLicenseMode { AddNew = 0, Update = 1 }
        public enDatainedLicenseMode Mode = enDatainedLicenseMode.AddNew;
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }        
        public int? ReleasedByUserID { get; set; }      
        public int? ReleaseApplicationID { get; set; }  
        public DetainedLicense() {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.Now;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;
            this.ReleaseDate = null;
            this.ReleasedByUserID = null;
            this.ReleaseApplicationID = null;
            this.Mode = enDatainedLicenseMode.AddNew;
        }

        public DetainedLicense(DetainedLicenseDTO dto) {
            if (dto != null) {
                this.DetainID = dto.DetainID;
                this.LicenseID = dto.LicenseID;
                this.DetainDate = dto.DetainDate;
                this.FineFees = dto.FineFees;
                this.CreatedByUserID = dto.CreatedByUserID;
                this.IsReleased = dto.IsReleased;
                this.ReleaseDate = dto.ReleaseDate;
                this.ReleasedByUserID = dto.ReleasedByUserID;
                this.ReleaseApplicationID = dto.ReleaseApplicationID;

                this.Mode = enDatainedLicenseMode.Update;
            }
        }
        public DetainedLicenseDTO ToDTO() {
            return new DetainedLicenseDTO {
                DetainID = this.DetainID,
                LicenseID = this.LicenseID,
                DetainDate = this.DetainDate,
                FineFees = this.FineFees,
                CreatedByUserID = this.CreatedByUserID,
                IsReleased = this.IsReleased,
                ReleaseDate = this.ReleaseDate,
                ReleasedByUserID = this.ReleasedByUserID,
                ReleaseApplicationID = this.ReleaseApplicationID
            };
        }
        public static bool IsLicenseDetained(int licenseID) {
            return DetainedLicensesData.IsLicenseDetained(licenseID);
        }
    }
}