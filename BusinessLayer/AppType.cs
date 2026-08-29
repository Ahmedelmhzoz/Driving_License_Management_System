using DataLinkLayer;
using DataLinkLayer.License_Application_data;
using Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer {
    public class AppType {
        public int AppTypeID { get; set; }
        public string AppTypeTitle { get; set; }
        public decimal AppTypeFees { get; set; }
        public AppType() {
            AppTypeID = -1;
            AppTypeFees = 0.0m;
            AppTypeTitle = "";
        }
        AppType(int AppTypeID, string AppTypeTitle, decimal AppTypeFees) {
            this.AppTypeID = AppTypeID;
            this.AppTypeTitle = AppTypeTitle;
            this.AppTypeFees = AppTypeFees;
        }
        public static DataTable getApplicationTypes() {
            return AppAndTestTypes.GetAllApplicationTypes();
        }
        public static AppType getApplicationType(int id) {
            string appType = "";
            decimal fees = 0.0m;
            if (AppAndTestTypes.GetApplicationTypeInfoByID(id, ref appType, ref fees)) {
                return new AppType(id, appType, fees);
            }
            return null;
        }
        public static AppType getApplicationType(enApplicationType appType) {
            return getApplicationType((int)appType);
        }
        public bool Save() {
            return AppAndTestTypes.UpdateApplicationType(AppTypeID, AppTypeTitle, AppTypeFees);
        }
    }
}
