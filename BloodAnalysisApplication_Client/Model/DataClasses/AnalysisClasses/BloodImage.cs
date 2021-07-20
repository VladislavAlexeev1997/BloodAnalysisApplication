using System;

namespace BloodAnalysisApplication_Client.Model.DataClasses.AnalysisClasses
{
    public class BloodImage
    {
        public string FileName { get; set; }

        public DateTime BloodImageDate { get; set; }

        public BloodImage(string _FileName, DateTime _BloodImageDate)
        {
            this.FileName = _FileName;
            this.BloodImageDate = _BloodImageDate;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                BloodImage IsEqualBloodImage = (BloodImage)obj;
                return (this.FileName == IsEqualBloodImage.FileName) &&
                    (this.BloodImageDate == IsEqualBloodImage.BloodImageDate);
            }
        }

        public override int GetHashCode()
        {
            return this.FileName.GetHashCode() +
                this.BloodImageDate.GetHashCode();
        }
    }
}