using DataLinkLayer;
using Shared;
using System;
using System.Data;

namespace BusinessLayer {
    public class Driver {
        public int driverID { get; set; }
        public int createdByUserID { get; set; }
        public DateTime creationDate { get; set; }
        public int personID { get; set; }
        private Person _personInfo = null;
        public Person personInfo {
            get {
                if (_personInfo == null) {
                    _personInfo = Person.findPerson(personID);
                }
                return _personInfo;
            }
        }
        public Driver() {
            this.driverID = -1;
            this.personID = -1;
            this.createdByUserID = -1;
            this.creationDate = DateTime.Now;
        }
        Driver(DriverDTO dto) {
            this.driverID = dto.driverID;
            this.personID = dto.personID;
            this.createdByUserID = dto.createdByUserID;
            this.creationDate = dto.creationDate;
        }
        public static DataTable GetAllDrivers() {
            return clsDriverData.GetAllDrivers();
        }
        public DriverDTO ToDTO() {
            return new DriverDTO {
                driverID = this.driverID,
                personID = this.personID,
                createdByUserID = this.createdByUserID,
                creationDate = this.creationDate
            };
        }
        public static bool isPersonAlreadyDriver(int personID) {
            return clsDriverData.isPesonAlreadyDriver(personID);
        }
        private bool _AddNewDriver() {
            this.driverID = clsDriverData.AddNewDriver(this.ToDTO());
            return (this.driverID != -1);
        }
        public static Driver findDriverByPersonID(int personID) {
            DriverDTO dto = clsDriverData.findDriverByPersonID(personID);
            if (dto == null) return null;
            return new Driver(dto);
        }
        public bool Save() {
            return _AddNewDriver();
        }
        public static DataTable GetDriversByFilter(enDriverFilterColumn filterColumn, string filterValue) {
            return clsDriverData.GetDriversByFilter(filterColumn, filterValue);
        }
        public static Driver findDriverByID(int driverID) {
            DriverDTO dto = clsDriverData.FindDriverByID(driverID);
            if (dto == null) return null;
            return new Driver(dto);
        }
    }
}
