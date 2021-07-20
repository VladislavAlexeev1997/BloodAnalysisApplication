using System;

namespace BloodAnalysisApplication_Server.Model.DataClasses.UserClasses
{
    public class AdministratorData : UserData
    {
        public AdministratorData(string password) 
            : base("admin", password) { }

        public override UserType GetUserType()
        {
            return UserType.Administrator;
        }
    }
}