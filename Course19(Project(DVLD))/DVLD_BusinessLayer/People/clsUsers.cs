using DVLD_DataAccesLayer.People;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsUsers
    {
        public int UserID { set; get; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        enum enMode { AddNew = 0, Update = 1};

        enMode Mode = enMode.AddNew;

        public clsUsers()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;
            this.Mode = enMode.AddNew;
        }

        private clsUsers(int userID, int personID, string userName, string password, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            Mode = enMode.Update;
        }

        static public clsUsers FindUser(int UserID)
        {
            string username = "", password = "";
            int personid = -1;
            bool isActive = false;

            if(UsersDataAccess.FindUser(UserID, ref personid ,ref username, ref password, ref isActive)) 
            {
                return new clsUsers(UserID, personid, username, password, isActive);
            }
            return null;
        }

        static public clsUsers FindUser(string Username)
        {
            string  password = "";
            int personid = -1, UserID = -1;
            bool isActive = false;

            if (UsersDataAccess.FindUser(ref UserID, ref personid, Username, ref password, ref isActive))
            {
                return new clsUsers(UserID, personid, Username, password, isActive);
            }
            return null;
        }

        static public DataTable ListAllUsers()
        {
            return(UsersDataAccess.ListAllUsers());
        }
   
        private bool AddNewUser()
        {
            if (!clsPerson.IsPersonExist(this.PersonID))
            {
                return false;
            }

             this.UserID = UsersDataAccess.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);
            return (this.UserID != -1);
        }
        
        private bool Update()
        {
            return (UsersDataAccess.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive));
        }

        static public bool DeleteUser(int UserID)
        {
            return(UsersDataAccess.DeleteUser(UserID));
        }


        static public bool isExists(int UserID)
        {
            return (UsersDataAccess.isExists(UserID));
        }

        static public bool isExists(string Username)
        {
            return (UsersDataAccess.isExists(Username));
        }

        static public bool isUserExistsForPersonID(int PersonID)
        {
            return (UsersDataAccess.isExistsByPersonID(PersonID));
        }
        public bool Save()
        {
            switch(this.Mode)
            {
                case enMode.AddNew:
                    if (AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return Update(); 
            }
            return false;
        }

        public string GetUserImage()
        {
            clsPerson Person1 = clsPerson.FindPersonByID(this.PersonID);
            return Person1.ImagePath;
        }

        public string GetName()
        {
            clsPerson Person1 = clsPerson.FindPersonByID(this.PersonID);
            return Person1.FirstName + " " + Person1.SecondName;
        }
    
    
    }


}
