using DataLinkLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static DataLinkLayer.UsersData;

namespace BusinessLayer {
    public enum enUserMode { addUser = 0, updateUser = 1 }
    public class User {
        public enum enUserStatus { enActive = 0, enNotActive = 1, enGeneral = 2 }
        public int userID {  get; set; }
        public int personID { get; set; }
        public bool isActive { get; set; }
        public string password { get; set; }
        public string Username { get; set; }
        public enUserMode currentMode;

        public User() {
            userID = -1;
            personID = -1;
            isActive = false;
            password = "";
            Username = "";
            currentMode = enUserMode.addUser;
        }
        User(int userID, int personID, string username, string password, bool isActive) {
            this.userID = userID;
            this.personID = personID;
            this.Username = username;
            this.password = password;
            this.isActive = isActive;
            currentMode = enUserMode.updateUser;
        }

        public static DataTable getUsers() {
            return UsersData.getAllUsers();
        }

        public static User getUserByUserName(string username) {
            string Password = "";
            int Id = -1, perId = -1;
            bool active = false;
            if (UsersData.findUserByUserName(username,ref Password, ref Id, ref perId, ref active) != false) {
                return new User(Id, perId, username, Password, active);
            }
            return null;
        }
        public static User getUserByID(int userID) {
            string username = "", password = "";
            int personID = -1;
            bool isActive = false;

            if (UsersData.findUserByID(ref username, ref password, userID, ref personID, ref isActive)) {
                return new User(userID, personID, username, password, isActive);
            }
            return null;
        }
        public static bool IsUsernameTaken(string password) {
            return UsersData.isPassOrUsernameTaken(password, false);
        }
        public static bool IsPasswordTaken(string password) { 
            return UsersData.isPassOrUsernameTaken(password, true); 
        }
        public static DataTable getCurrentSearchResult(string currentTxt, string category, enUserStatus status) {
            enSearchCategoryUsers searchMode = enSearchCategoryUsers.enUserID;
            switch (category.Trim()) {
                case "User ID": searchMode = enSearchCategoryUsers.enUserID; break;
                case "Person ID": searchMode = enSearchCategoryUsers.enPersonID; break;
                case "Username": searchMode = enSearchCategoryUsers.enUserName; break;
                case "Full Name": searchMode = enSearchCategoryUsers.enFullName; break;
                default: break;
            }
            string StatusInBitToSearch = "";
            switch (status) {
                case enUserStatus.enActive : StatusInBitToSearch = "1"; break;
                case enUserStatus.enNotActive : StatusInBitToSearch = "0"; break;
                default: StatusInBitToSearch = "";  break;
            }
            return UsersData.searchResultByCategory(currentTxt, searchMode, StatusInBitToSearch);
        }
        public static DataTable selectUsersByState(enUserStatus status) {
            switch (status) {
                case enUserStatus.enActive: return UsersData.getUsersByState(true);
                case enUserStatus.enNotActive: return UsersData.getUsersByState(false);
                default: return UsersData.getAllUsers();
            }
        }
        private int addUser() {
            return UsersData.addAUser(Username, password, personID, isActive);
        }
        private bool updateUser() {
            return updateAUser(userID, Username, password, isActive);
        }
        public bool Save() {
            switch (currentMode) {
                case enUserMode.addUser:
                    int userID = -1;
                    if ((userID = addUser()) != -1) {
                        this.userID = userID;
                        currentMode = enUserMode.updateUser;
                        return true;
                    }
                    return false;
                default:
                    return updateUser();
            }
        }

        public static bool didUserCreateApp(int ID) {
            return UsersData.isUserFree(ID);
        }
        public static bool deleteUser(int ID) {
            return UsersData.deleteAUser(ID);
        }
    }
}
