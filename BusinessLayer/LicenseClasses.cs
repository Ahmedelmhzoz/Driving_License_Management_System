using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLinkLayer;
using DataLinkLayer.License_Application_data;

namespace BusinessLayer {
    public class LicenseClasses {
        public int LicenseClassID { get; set; }
        public string className { get; set; }
        public byte minimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal classFees { get; set; }
        public LicenseClasses() {
            LicenseClassID = -1;
            className = "";
            minimumAllowedAge = 0;
            DefaultValidityLength = 0;
            classFees = 0.0m;
        }
        public LicenseClasses(LicenseClassDTO dto) {
            this.LicenseClassID = dto.LicenseClassID;
            this.className = dto.className;
            this.minimumAllowedAge = dto.minimumAllowedAge;
            this.DefaultValidityLength = dto.DefaultValidityLength;
            this.classFees = dto.classFees;
        }
        public static DataTable getLicenseClasses() {
            return LicenseClassesData.getAllLicenseClasses();
        }
        public LicenseClassDTO _ToDTO() {
            return new LicenseClassDTO {
                LicenseClassID = this.LicenseClassID,
                className = this.className,
                minimumAllowedAge = this.minimumAllowedAge,
                DefaultValidityLength = this.DefaultValidityLength,
                classFees = this.classFees
            };
        }

        public static LicenseClasses getLicenseClassByID(int id) {
            LicenseClassDTO DTO = LicenseClassesData.GetLicenseClassByID(id);
            return new LicenseClasses(DTO);
        }

    }
}
