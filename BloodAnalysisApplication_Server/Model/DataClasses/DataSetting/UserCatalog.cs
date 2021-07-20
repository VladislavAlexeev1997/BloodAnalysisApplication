using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BloodAnalysisApplication_Server.Model.DataClasses.UserClasses;

namespace BloodAnalysisApplication_Server.Model.DataClasses.DataSetting
{
    public class UserCatalog
    {
        private List<UserData> Users;

        private readonly GenderVocabulary Genders;

        private const string USER_TABLE = "SYS_USER";

        private const string ADMINISTRATOR_TABLE = "ADMINISTRATOR";

        private const string LABORANT_TABLE = "LABORANT";

        public UserCatalog()
        {
            Genders = new GenderVocabulary();
            Users = new List<UserData>();
            LoadCatalog();
        }

        private void LoadCatalog()
        {
            Users = new List<UserData>();
            MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
            if (connection.IsOpenConnection())
            {
                SqlDataReader administratorDataReader = connection.SearchTableElements(
                    "SYS_USER INNER JOIN ADMINISTRATOR ON SYS_USER.SYS_USER_ID = ADMINISTRATOR.ADMIN_ID",
                    "SYS_USER.SYS_USER_ID, SYS_USER.PASSWORD");
                while (administratorDataReader.Read())
                {
                    Users.Add(new AdministratorData(
                        Convert.ToString(administratorDataReader.GetValue(1))));
                }
                administratorDataReader.Close();
                SqlDataReader laborantDataReader = connection.SearchTableElements(
                    "SYS_USER INNER JOIN LABORANT ON SYS_USER.SYS_USER_ID = LABORANT.LABORANT_ID",
                    "SYS_USER.SYS_USER_ID, SYS_USER.PASSWORD, LABORANT.SURNAME, LABORANT.NAME, " +
                        "LABORANT.PATRONIMIC, LABORANT.BIRTH_DATE, LABORANT.GENDER_ID, " +
                        "LABORANT.CONTRACT_NUMBER, LABORANT.ACTIVITY");
                while (laborantDataReader.Read())
                {
                    Users.Add(new LaborantData(
                        Convert.ToString(laborantDataReader.GetValue(0)),
                        Convert.ToString(laborantDataReader.GetValue(1)),
                        Convert.ToString(laborantDataReader.GetValue(2)),
                        Convert.ToString(laborantDataReader.GetValue(3)),
                        Convert.ToString(laborantDataReader.GetValue(4)),
                        Convert.ToDateTime(laborantDataReader.GetValue(5)),
                        Genders.GenderById(Convert.ToInt32(laborantDataReader.GetValue(6))),
                        Convert.ToString(laborantDataReader.GetValue(7)),
                        Convert.ToBoolean(laborantDataReader.GetValue(8))));
                }
                laborantDataReader.Close();
            }
            connection.CloseConnection();
        }

        public UserData SearchEnterUser(UserType userType, 
            int userIndex, string userPassword)
        {
            List<UserData> UsersToType = UserTypeCatalog(userType);
            if (userIndex < 0)
            {
                userIndex = 0;
            }
            if (UsersToType[userIndex].Password == userPassword)
            {
                return UsersToType[userIndex];
            }
            else
            {
                return null;
            }
        }

        public List<UserData> UserTypeCatalog(UserType userType)
        {
            List<UserData> UsersToType =
                Users.FindAll(find => find.GetUserType() == userType);
            return UsersToType;
        }
    }
}