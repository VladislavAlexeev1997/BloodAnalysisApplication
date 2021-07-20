using System;

namespace BloodAnalysisApplication_Server.Model.DataClasses.UserClasses
{
    public class LaborantData : UserData
    {
        public LaborantData(string identificator, string password, 
            string surname, string name, string patronimic, DateTime birthDate,
            Gender gender, string employeeContractNumber, bool activity) : 
            base(identificator, password)
        {
            Surname = surname;
            Name = name;
            Patronimic = patronimic;
            BirthDate = birthDate;
            Gender = gender;
            EmployeeContractNumber = employeeContractNumber;
            Activity = activity;
        }
        
        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronimic { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public string EmployeeContractNumber { get; set; }

        public bool Activity { get; set; }

        public override UserType GetUserType()
        {
            return UserType.Laborant;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                LaborantData IsEqualLaborant = (LaborantData)obj;
                return base.Equals(obj) && (this.Activity == IsEqualLaborant.Activity) &&
                    (this.Surname == IsEqualLaborant.Surname) &&
                    (this.Name == IsEqualLaborant.Name) &&
                    (this.Patronimic == IsEqualLaborant.Patronimic) &&
                    (this.BirthDate == IsEqualLaborant.BirthDate) &&
                    (this.EmployeeContractNumber == IsEqualLaborant.EmployeeContractNumber) &&
                    (this.Gender.Equals(IsEqualLaborant.Gender));
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + this.Activity.GetHashCode() + this.Surname.GetHashCode() +
                this.Name.GetHashCode() + this.Patronimic.GetHashCode() +
                this.Gender.GetHashCode() + this.BirthDate.GetHashCode() +
                this.EmployeeContractNumber.GetHashCode();
        }

        public string ShortName()
        {
            return this.Surname + " " + this.Name.Substring(0, 1) + ". " +
                this.Patronimic.Substring(0, 1) + ".";
        }

        public string FullName()
        {
            return this.Surname + " " + this.Name + " " + this.Patronimic;
        }
    }
}