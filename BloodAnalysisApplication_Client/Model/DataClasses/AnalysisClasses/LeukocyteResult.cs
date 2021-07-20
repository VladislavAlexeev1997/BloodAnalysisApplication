using System;

namespace BloodAnalysisApplication_Client.Model.DataClasses.AnalysisClasses
{
    public class LeukocyteResult
    {
        public int CellCount { get; set; }

        public string FileName { get; set; }

        public LeukocyteResult(int _CellCount, string _FileName)
        {
            this.CellCount = _CellCount;
            this.FileName = _FileName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                LeukocyteResult IsEqualLeukocyteResult = (LeukocyteResult)obj;
                return (this.CellCount == IsEqualLeukocyteResult.CellCount) &&
                    (this.FileName == IsEqualLeukocyteResult.FileName);
            }
        }

        public override int GetHashCode()
        {
            return this.CellCount.GetHashCode() +
                this.FileName.GetHashCode();
        }
    }
}