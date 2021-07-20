using System;

namespace BloodAnalysisApplication_Client.Model.DataClasses.PacientClasses
{
    public class Gender
    {
        public int GenderID { get; set; }

        public string GenderName { get; set; }

        public Gender(int _GenderID, string _GenderName)
        {
            this.GenderID = _GenderID;
            this.GenderName = _GenderName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                Gender IsEqualGender = (Gender)obj;
                return (this.GenderID == IsEqualGender.GenderID) &&
                    (this.GenderName == IsEqualGender.GenderName);
            }
        }

        public override int GetHashCode()
        {
            return this.GenderID.GetHashCode() +
                this.GenderName.GetHashCode();
        }

        public string ShortGenderName()
        {
            return this.GenderName.Substring(0, 1).ToUpper();
        }
    }
}