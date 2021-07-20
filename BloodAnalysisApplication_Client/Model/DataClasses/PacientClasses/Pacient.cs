using System;

namespace BloodAnalysisApplication_Client.Model.DataClasses.PacientClasses
{
    public class Pacient
    {
        public string MedicalCardNumber { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronimic { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public MedicalPlace AttachmentPlace { get; set; }

        public Gender Gender { get; set; }

        public SNILS SNILS { get; set; }

        public MedicalLicense MedicalLicense { get; set; }

        public Pacient(string _MedicalCardNumber, string _Surname, string _Name,
            string _Patronimic, DateTime _BirthDate, string _PhoneNumber, MedicalPlace _AttachmentPlace,
            Gender _Gender,  SNILS _SNILS, MedicalLicense _MedicalLicense)
        {
            this.MedicalCardNumber = _MedicalCardNumber;
            this.Surname = _Surname;
            this.Name = _Name;
            this.Patronimic = _Patronimic;
            this.BirthDate = _BirthDate;
            this.PhoneNumber = _PhoneNumber;
            this.AttachmentPlace = _AttachmentPlace;
            this.Gender = _Gender;
            this.SNILS = _SNILS;
            this.MedicalLicense = _MedicalLicense;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                Pacient IsEqualPacient = (Pacient)obj;
                return (this.MedicalCardNumber == IsEqualPacient.MedicalCardNumber) &&
                    (this.Surname == IsEqualPacient.Surname) &&
                    (this.Name == IsEqualPacient.Name) &&
                    (this.Patronimic == IsEqualPacient.Patronimic) &&
                    (this.BirthDate == IsEqualPacient.BirthDate) &&
                    (this.PhoneNumber == IsEqualPacient.PhoneNumber) &&
                    (this.AttachmentPlace == IsEqualPacient.AttachmentPlace)  &&
                    (this.Gender == IsEqualPacient.Gender) &&
                    (this.SNILS == IsEqualPacient.SNILS) &&
                    (this.MedicalLicense == IsEqualPacient.MedicalLicense);
            }
        }

        public override int GetHashCode()
        {
            return this.MedicalCardNumber.GetHashCode() + this.Surname.GetHashCode() +
                this.Name.GetHashCode() + this.Patronimic.GetHashCode() +
                this.Gender.GetHashCode() + this.BirthDate.GetHashCode() +
                this.PhoneNumber.GetHashCode() + this.AttachmentPlace.GetHashCode() +
                this.SNILS.GetHashCode() + this.MedicalLicense.GetHashCode();
        }

        public string ShortPacientName()
        {
            return this.Surname + " " + this.Name.Substring(0, 1) + ". " + 
                this.Patronimic.Substring(0, 1) + ".";
        }

        public string FullPacientName()
        {
            return this.Surname + " " + this.Name + " " + this.Patronimic;
        }
    }
}