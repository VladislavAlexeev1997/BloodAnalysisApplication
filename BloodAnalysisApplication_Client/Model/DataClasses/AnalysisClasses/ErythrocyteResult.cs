using System;

namespace BloodAnalysisApplication_Client.Model.DataClasses.AnalysisClasses
{
    public class ErythrocyteResult
    {
        public int CellCount { get; set; }

        public string FileName { get; set; }

        public ErythrocyteResult(int _CellCount, string _FileName)
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
                ErythrocyteResult IsEqualErythrocyteResult = (ErythrocyteResult)obj;
                return (this.CellCount == IsEqualErythrocyteResult.CellCount) &&
                    (this.FileName == IsEqualErythrocyteResult.FileName);
            }
        }

        public override int GetHashCode()
        {
            return this.CellCount.GetHashCode() +
                this.FileName.GetHashCode();
        }
    }
}