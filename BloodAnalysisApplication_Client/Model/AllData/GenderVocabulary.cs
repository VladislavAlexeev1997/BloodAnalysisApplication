using System;
using System.Collections.Generic;

namespace BloodAnalysisApplication_Client.Model.AllData
{
    class GenderVocabulary
    {
        public List<Gender> Genders { get; }

        public GenderVocabulary()
        {
            Genders = new List<Gender>();
            LoadVocabulary();
        }

        private void LoadVocabulary()
        {
            Genders.Add(new Gender(1, "мужской"));
            Genders.Add(new Gender(2, "женский"));
        }

        public Gender GenderById(int genderID)
        {
            return Genders.Find(find => find.GenderID == genderID);
        }
    }
}