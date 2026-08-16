using DataLinkLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataLinkLayer.DataAccess;

namespace BusinessLayer
{
    public class Person {
        enum enPersonMode { addPerson = 0, updatePerson = 1 }
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
        enPersonMode currentMode;
        public Person() {
            personID = -1;
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
            currentMode = enPersonMode.addPerson;
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
    }
}
