using System;

namespace BloodAnalysisApplication_Server.Model.DataClasses.UserClasses
{
    public class UserData
    {
        public UserData(string identificator, string password)
        {
            UserIdentificator = identificator;
            Password = password;
        }

        public string UserIdentificator { get; set; }

        public string Password { get; set; }

        public virtual UserType GetUserType()
        {
            return UserType.Default;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                UserData IsEqualUser = (UserData)obj;
                return (this.UserIdentificator == IsEqualUser.UserIdentificator) &&
                    (this.Password == IsEqualUser.Password);
            }
        }

        public override int GetHashCode()
        {
            return this.UserIdentificator.GetHashCode() + this.Password.GetHashCode();
        }
    }
}