using System;
using BloodAnalysisApplication_Client.Model.AllData;

namespace BloodAnalysisApplication_Client.Model.LaborantData
{
    public class Laborant
    {
        public Laborant(string identificator, string password,
            string surname, string name, string patronimic, DateTime birthDate,
            Gender gender, string employeeContractNumber, bool activity)
        {
            UserIdentificator = identificator;
            Password = password;
            Surname = surname;
            Name = name;
            Patronimic = patronimic;
            BirthDate = birthDate;
            Gender = gender;
            EmployeeContractNumber = employeeContractNumber;
            Activity = activity;
        }

        public string UserIdentificator { get; set; }

        public string Password { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronimic { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public string EmployeeContractNumber { get; set; }

        public bool Activity { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                Laborant IsEqualLaborant = (Laborant)obj;
                return (this.UserIdentificator == IsEqualLaborant.UserIdentificator) && 
                    (this.Password == IsEqualLaborant.Password) && 
                    (this.Activity == IsEqualLaborant.Activity) &&
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
            return this.UserIdentificator.GetHashCode() + this.Password.GetHashCode() + 
                this.Activity.GetHashCode() + this.Surname.GetHashCode() +
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