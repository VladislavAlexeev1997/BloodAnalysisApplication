using System;
using System.Collections.Generic;
using BloodAnalysisApplication_Client.Model.AllData;

namespace BloodAnalysisApplication_Client.Model.LaborantData
{
    public class LaborantVocabulary
    {
        public List<Laborant> Laborants { get; private set; }

        private readonly GenderVocabulary Genders;

        public LaborantVocabulary(string requestData)
        {
            Genders = new GenderVocabulary();
            LoadCatalog(requestData);
        }

        private void LoadCatalog(string data)
        {
            Laborants = new List<Laborant>();
            string[] laborantData = data.Split('&')[1].Split('~');
            int laborantCount = laborantData.Length;
            for (int index = 0; index < laborantCount; index++)
            {
                string[] laborantElements = laborantData[index].Split('|');
                Laborants.Add(new Laborant(laborantElements[0], laborantElements[1],
                    laborantElements[2], laborantElements[3], laborantElements[4],
                    Convert.ToDateTime(laborantElements[5]),
                    Genders.GenderById(Convert.ToInt32(laborantElements[6])),
                    laborantElements[7], Convert.ToBoolean(laborantElements[8])));
            }
        }
    }
}