using DataLinkLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static DataLinkLayer.PeopleData;

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
        public string FullName {
            get {
                if (string.IsNullOrWhiteSpace(thirdName)) {
                    return $"{firstName} {secondName} {lastName}";
                }

                return $"{firstName} {secondName} {thirdName} {lastName}";
            }
        }

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
            return PeopleData.getPeople();
        }

        static enSearchCategory _ConvertCategoryToEnum(string category) {
            switch (category) {
                case "Person ID": return enSearchCategory.enPersonID;
                case "National No.": return enSearchCategory.enNationalNo; 
                case "First Name": return enSearchCategory.enFirst; 
                case "Second Name": return enSearchCategory.enSecond; 
                case "Third Name": return enSearchCategory.enThird; 
                case "Last Name": return enSearchCategory.enLast; 
                case "Nationality": return enSearchCategory.enNationality; 
                case "Gender": return enSearchCategory.enGender; 
                case "Phone": return enSearchCategory.enPhone; 
                case "Email": return enSearchCategory.enEmail; 
                default: return enSearchCategory.enPersonID;
            }
        }
        
        public static DataTable getCurrentSearchResult(string currentTxt, string category, bool withoutLinkedPersons = false) {
            // withoutLinkedPersons if true filters the people result to only persons who arent linked to user
            enSearchCategory searchMode = _ConvertCategoryToEnum(category);

            return PeopleData.searchResultByCategory(searchMode, currentTxt, withoutLinkedPersons);
        }
        public static Person findPerson(int PersonID) {
            PersonDTO person = null;
            if ((person = PeopleData.getPerson(PersonID)) != null) {
                Person originalPerson = new Person(person, enPersonMode.updatePerson);
                return originalPerson;
            }
            else {
                return null;
            }
        }

        private int addPerson() {
            PersonDTO personToAdd = toDTO();
            return addAPerson(personToAdd);
        }
        private bool updatePerson() {
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
            return PeopleData.IsNationalExists(natNo);
        }
        public static bool deletePerson(int personID) {
            if (UsersData.isUserExistsForPerson(personID)) {
                return false;
            }
            return deleteAPerson(personID);
        }
    }
   
}
