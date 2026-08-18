using DataLinkLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static DataLinkLayer.DataAccess;

namespace BusinessLayer {
    public enum enPersonMode { addPerson = 0, updatePerson = 1 }
    public class Person {
        public int personID { get; set; }
        public string NationalNo { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string thirdName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string imagePath { get; set; }
        public string Address { get; set; }
        public int NationalityCountryID { get; set; }

        public enPersonMode currentMode;
        public Person() {
            personID = -1;
            NationalityCountryID = -1;
            NationalNo = "";
            firstName = "";
            secondName = "";
            thirdName = "";
            lastName = "";
            gender = "";
            dateOfBirth = DateTime.Now;
            country = "";
            phone = "";
            email = "";
            imagePath = "";
            currentMode = enPersonMode.addPerson;
        }
        Person(PersonDTO dto, enPersonMode mode) {
            this.personID = dto.personID;
            this.NationalNo = dto.NationalNo;
            this.firstName = dto.firstName;
            this.secondName = dto.secondName;
            this.thirdName = dto.thirdName;
            this.lastName = dto.lastName;
            this.gender = dto.gender;
            this.dateOfBirth = dto.dateOfBirth;
            this.country = dto.country;
            this.phone = dto.phone;
            this.email = dto.email;
            this.imagePath = dto.imagePath;
            this.Address = dto.Address;
            this.NationalityCountryID = dto.NationalityCountryID;
            currentMode = mode;
        }
        PersonDTO toDTO() {
            return new PersonDTO {
                personID = this.personID,
                NationalNo = this.NationalNo,
                firstName = this.firstName,
                secondName = this.secondName,
                thirdName = this.thirdName,
                lastName = this.lastName,
                gender = this.gender,
                dateOfBirth = this.dateOfBirth,
                country = this.country,
                phone = this.phone,
                email = this.email,
                imagePath = this.imagePath,
                Address = this.Address,
                NationalityCountryID = this.NationalityCountryID
            };
        }

        public static DataTable getAllPeople() {
            return DataAccess.getPeople();
        }
        
        public static DataTable getCurrentSearchResult(string currentTxt, string category) {
            enSearchCategory searchMode = enSearchCategory.enPersonID;
            switch (category) {
                case "Person ID": searchMode = enSearchCategory.enPersonID; break;
                case "National No.": searchMode = enSearchCategory.enNationalNo; break;
                case "First Name": searchMode = enSearchCategory.enFirst; break;
                case "Second Name": searchMode = enSearchCategory.enSecond; break;
                case "Third Name": searchMode = enSearchCategory.enThird; break;
                case "Last Name": searchMode = enSearchCategory.enLast; break;
                case "Nationality": searchMode = enSearchCategory.enNationality; break;
                case "Gender": searchMode = enSearchCategory.enGender; break;
                case "Phone": searchMode = enSearchCategory.enPhone; break;
                case "Email": searchMode = enSearchCategory.enEmail; break;
                default: break;
            }
            return DataAccess.searchResultByCategory(searchMode, currentTxt);
        }

        public static Person findPerson(string NationalNum) {
            PersonDTO person = null;
            if ((person = DataAccess.getPerson(NationalNum)) != null) {
                Person originalPerson = new Person(person, enPersonMode.updatePerson);
                return originalPerson;
            }
            else {
                return null;
            }
        }

        public int addPerson() {
            PersonDTO personToAdd = toDTO();
            return addAPerson(personToAdd);
        }
        public bool updatePerson() {
            PersonDTO personToAdd = toDTO();
            return updateAPerson(personToAdd);
        }
        public bool Save() {
            switch (currentMode) {
                case enPersonMode.addPerson:
                    int personID;
                    if ((personID = addPerson()) != -1) {
                        this.personID = personID;
                        currentMode = enPersonMode.updatePerson;
                        return true;
                    }
                    return false;
                default :
                    return updatePerson();
            }
        }
        public static bool isNationalNumExists(string natNo) {
            return DataAccess.IsNationalExists(natNo);
        }
        public static bool deletePerson(int personID) {
            if (DataAccess.isUserExistsForPerson(personID)) {
                return false;
            }
            return deleteAPerson(personID);
        }
    }
    public class County { 
        public int countyID;
        public string countryName;
        public County() {
            countyID = -1;
            countryName = "";
        }
        public static DataTable getCountries() {
            return DataAccess.getAllCountries();
        }


    }
}
