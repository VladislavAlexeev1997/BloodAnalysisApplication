using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BloodAnalysisApplication_Client.Model.DataClasses.PacientClasses;

namespace BloodAnalysisApplication_Client.Model.DataSetting
{
    public class GenderVocabulary
    {
        public List<Gender> Genders { get; }

        private const string VOCABULARY_TABLE = "GENDER";

        public GenderVocabulary()
        {
            Genders = new List<Gender>();
            LoadVocabulary();
        }

        private void LoadVocabulary()
        {
            MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
            if (connection.IsOpenConnection())
            {
                SqlDataReader dataReader = connection.SearchTableForName(VOCABULARY_TABLE);
                while (dataReader.Read())
                {
                    Genders.Add(new Gender(Convert.ToInt32(dataReader.GetValue(0)),
                        Convert.ToString(dataReader.GetValue(1))));
                }
                dataReader.Close();
            }
            connection.CloseConnection();
        }

        public Gender GenderById(int genderID)
        {
            return Genders.Find(find => find.GenderID == genderID);
        }
    }
}