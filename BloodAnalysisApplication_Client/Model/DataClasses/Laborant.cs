using System;

namespace BloodAnalysisApplication_Client.Model.DataClasses
{
    public class Laborant
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronimic { get; set; }

        public Laborant(string _Surname, string _Name, string _Patronimic)
        {
            this.Surname = _Surname;
            this.Name = _Name;
            this.Patronimic = _Patronimic;
        }

        public string ShortLaborantName()
        {
            return this.Surname + " " + this.Name.Substring(0, 1) + ". " +
                this.Patronimic.Substring(0, 1) + ".";
        }

        public string FullLaborantName()
        {
            return this.Surname + " " + this.Name + " " +
                this.Patronimic;
        }
    }
}