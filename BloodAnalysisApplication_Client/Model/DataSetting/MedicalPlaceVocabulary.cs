using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BloodAnalysisApplication_Client.Model.DataClasses.PacientClasses;

namespace BloodAnalysisApplication_Client.Model.DataSetting
{
    public class MedicalPlaceVocabulary
    {
        public List<MedicalPlace> MedicalPlaces { get; private set; }

        private const string VOCABULARY_TABLE = "MEDICAL_PLACE";

        public MedicalPlaceVocabulary()
        {
            LoadVocabulary();
        }

        private void LoadVocabulary()
        {
            MedicalPlaces = new List<MedicalPlace>();
            MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
            if (connection.IsOpenConnection())
            {
                SqlDataReader dataReader = connection.SearchTableForName(VOCABULARY_TABLE);
                while (dataReader.Read())
                {
                    MedicalPlaces.Add(new MedicalPlace(Convert.ToInt32(dataReader.GetValue(0)),
                        Convert.ToBoolean(dataReader.GetValue(1))));
                }
                dataReader.Close();
            }
            connection.CloseConnection();
        }

        public bool AddNewMedicalPlace(MedicalPlace addPlace)
        {
            bool isAddElement = false;
            if (!SearchMedicalPlace(addPlace))
            {
                MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
                if (connection.IsOpenConnection())
                {
                    string parameters = Convert.ToString(addPlace.PlaceNumber) + ", "
                        + Convert.ToString(addPlace.Attachment);
                    isAddElement = connection.AddTableElement(VOCABULARY_TABLE, parameters);
                }
                connection.CloseConnection();
                LoadVocabulary();
            }
            return isAddElement;
        }

        public bool UpdateMedicalPlaceAttachment(int selectIndex, bool changeAttacment)
        {
            bool isUpdateElement = false;
            int placeNumber = MedicalPlaces[selectIndex].PlaceNumber;
            if (!SearchMedicalPlace(new MedicalPlace(placeNumber, changeAttacment)))
            {
                MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
                if (connection.IsOpenConnection())
                {
                    string parameters = "ATTACHMENT = '" + Convert.ToString(changeAttacment) + "'";
                    string term = "MEDICAL_PLACE_NUM = '" + Convert.ToString(placeNumber) + "'";
                    isUpdateElement = connection.UpdateTableElement(VOCABULARY_TABLE, parameters, term);
                }
                connection.CloseConnection();
                LoadVocabulary();
            }
            return isUpdateElement;
        }

        public bool DeleteMedicalPlace(int selectIndex)
        {
            bool isDeleteElement = false;
            MedicalPlace deletedMedicalPlace = MedicalPlaces[selectIndex];
            MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
            if (connection.IsOpenConnection())
            {
                string searchTerm = "MEDICAL_PLACE_NUM = '" + 
                    Convert.ToString(deletedMedicalPlace.PlaceNumber) + "'";
                SqlDataReader dataPacientReader = 
                    connection.ComplexQueryElements("PACIENT", "MEDICAL_CARD_NUM", searchTerm);
                if (!dataPacientReader.HasRows)
                {
                    string deleteTerm = "MEDICAL_PLACE_NUM = '" + 
                        Convert.ToString(deletedMedicalPlace.PlaceNumber) + "'";
                    isDeleteElement = connection.DeleteTableElement(VOCABULARY_TABLE, deleteTerm);
                }
                dataPacientReader.Close();
            }
            connection.CloseConnection();
            LoadVocabulary();
            return isDeleteElement;
        }

        public MedicalPlace MedicalPlaceByNumber(int medicalPlaceNumber)
        {
            return MedicalPlaces.Find(find => find.PlaceNumber == medicalPlaceNumber);
        }

        private bool SearchMedicalPlace(MedicalPlace searchPlace)
        {
            return MedicalPlaces.Contains(searchPlace);
        }
    }
}