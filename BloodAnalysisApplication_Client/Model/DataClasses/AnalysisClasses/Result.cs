using System;

namespace BloodAnalysisApplication_Client.Model.DataClasses.AnalysisClasses
{
    public class Result
    {
        public ErythrocyteResult Erythrocytes { get; set; }

        public LeukocyteResult Leukocytes { get; set; }

        public string ResultText { get; set; }

        public Result(ErythrocyteResult _Erythrocytes, 
            LeukocyteResult _Leukocytes, string _ResultText)
        {
            this.Erythrocytes = _Erythrocytes;
            this.Leukocytes = _Leukocytes;
            this.ResultText = _ResultText;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                Result IsEqualResult = (Result)obj;
                return (this.Erythrocytes == IsEqualResult.Erythrocytes) &&
                    (this.Leukocytes == IsEqualResult.Leukocytes) &&
                    (this.ResultText == IsEqualResult.ResultText);
            }
        }

        public override int GetHashCode()
        {
            return this.Erythrocytes.GetHashCode() +
                this.Leukocytes.GetHashCode() + 
                this.ResultText.GetHashCode();
        }
    }
}