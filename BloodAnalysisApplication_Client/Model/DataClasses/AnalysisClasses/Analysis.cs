using System;

namespace BloodAnalysisApplication_Client.Model.DataClasses.AnalysisClasses
{
    public class Analysis
    {
        public string AnalysisNumber { get; set; }

        public string MedicalCardNumber { get; set; }

        public DateTime AnalysisData { get; set; }

        public BloodImage BloodImage { get; set; }

        public int EmployeeNumber { get; set; }

        public Result AnalysisResult { get; set; }

        public Analysis(string _AnalysisNumber, string _MedicalCardNumber,
            DateTime _AnalysisData, BloodImage _BloodImage,
            int _EmployeeNumber, Result _AnalysisResult)
        {
            this.AnalysisNumber = _AnalysisNumber;
            this.MedicalCardNumber = _MedicalCardNumber;
            this.AnalysisData = _AnalysisData;
            this.BloodImage = _BloodImage;
            this.EmployeeNumber = _EmployeeNumber;
            this.AnalysisResult = _AnalysisResult;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                Analysis IsEqualAnalysis = (Analysis)obj;
                return (this.AnalysisNumber == IsEqualAnalysis.AnalysisNumber) &&
                    (this.MedicalCardNumber == IsEqualAnalysis.MedicalCardNumber) &&
                    (this.AnalysisData == IsEqualAnalysis.AnalysisData) &&
                    (this.BloodImage == IsEqualAnalysis.BloodImage) &&
                    (this.EmployeeNumber == IsEqualAnalysis.EmployeeNumber) &&
                    (this.AnalysisResult == IsEqualAnalysis.AnalysisResult);
            }
        }

        public override int GetHashCode()
        {
            return this.AnalysisNumber.GetHashCode() +
                this.MedicalCardNumber.GetHashCode() +
                this.AnalysisData.GetHashCode() +
                this.BloodImage.GetHashCode() +
                this.EmployeeNumber.GetHashCode() +
                this.AnalysisResult.GetHashCode();
        }
    }
}