using DataLinkLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLinkLayer.License_Application_data;
using Shared;

namespace BusinessLayer {
    public class TestType {
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }
        public TestType() {
            TestTypeID = -1;
            TestTypeTitle = "";
            TestTypeDescription = "";
            TestTypeFees = 0.0m;
        }
        TestType(TestTypeDTO dto) {
            this.TestTypeID = dto.TestTypeID; 
            this.TestTypeTitle = dto.TestTypeTitle;
            this.TestTypeDescription = dto.description;
            this.TestTypeFees = dto.TestTypeFees;
        }

        private TestType(int testTypeID, string testTypeTitle, string testTypeDescription, decimal testTypeFees) {
            this.TestTypeID = testTypeID;
            this.TestTypeTitle = testTypeTitle;
            this.TestTypeDescription = testTypeDescription;
            this.TestTypeFees = testTypeFees;
        }

        public static DataTable getAllTestTypes() {
            return AppAndTestTypes.GetAllTestTypes();
        }
        public static TestType getTestType(int id) {
            string title = "";
            string description = "";
            decimal fees = 0.0m;

            if (AppAndTestTypes.GetTestTypeInfoByID(id, ref title, ref description, ref fees)) {
                return new TestType(id, title, description, fees);
            }
            return null;
        }

        public bool Save() {
            return AppAndTestTypes.UpdateTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
        }
        public static TestType getTestTypeDetails(enTestType testType) {
            TestTypeDTO dto = AppAndTestTypes.getTestType(testType);
            if (dto != null) 
                return new TestType(dto);
            return null;
        }
    }
}
