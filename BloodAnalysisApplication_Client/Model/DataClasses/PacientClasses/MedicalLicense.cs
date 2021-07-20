using System;

namespace BloodAnalysisApplication_Client.Model.DataClasses.PacientClasses
{
    public class MedicalLicense
    {
        public string LicenseNumber { get; set; }

        public DateTime RegistrateDate { get; set; }

        public MedicalLicense(string _LicenseNumber, DateTime _RegistrateDate)
        {
            this.LicenseNumber = _LicenseNumber;
            this.RegistrateDate = _RegistrateDate;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                MedicalLicense IsEqualMedicalLicenseData = (MedicalLicense)obj;
                return (this.LicenseNumber == IsEqualMedicalLicenseData.LicenseNumber) &&
                    (this.RegistrateDate == IsEqualMedicalLicenseData.RegistrateDate);
            }
        }

        public override int GetHashCode()
        {
            return this.LicenseNumber.GetHashCode() +
                this.RegistrateDate.GetHashCode();
        }
    }
}