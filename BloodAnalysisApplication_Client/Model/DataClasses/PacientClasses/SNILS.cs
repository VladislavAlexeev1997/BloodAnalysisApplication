using System;

namespace BloodAnalysisApplication_Client.Model.DataClasses.PacientClasses
{
    public class SNILS
    {
        public string SNILSNumber { get; set; }

        public DateTime RegistrateDate { get; set; }

        public SNILS (string _SNILSNumber, DateTime _RegistrateDate)
        {
            this.SNILSNumber = _SNILSNumber;
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
                SNILS IsEqualSNILSData = (SNILS)obj;
                return (this.SNILSNumber == IsEqualSNILSData.SNILSNumber) &&
                    (this.RegistrateDate == IsEqualSNILSData.RegistrateDate);
            }   
        }

        public override int GetHashCode()
        {
            return this.SNILSNumber.GetHashCode() +
                this.RegistrateDate.GetHashCode();
        }
    }
}