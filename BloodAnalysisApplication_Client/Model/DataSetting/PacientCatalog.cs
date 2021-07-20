using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BloodAnalysisApplication_Client.Model.DataClasses.PacientClasses;

namespace BloodAnalysisApplication_Client.Model.DataSetting
{
    public class PacientCatalog
    {
        public List<Pacient> Pacients { get; private set; }

        private readonly GenderVocabulary Genders;

        private readonly MedicalPlaceVocabulary MedicalPlaces;

        private const string PACIENT_TABLE = "PACIENT";

        private const string MEDICAL_LICENSE_TABLE = "MEDICAL_LICENSE";

        private const string SNILS_TABLE = "SNILS";

        public PacientCatalog()
        {
            Genders = new GenderVocabulary();
            MedicalPlaces = new MedicalPlaceVocabulary();
            LoadCatalog();
        }

        private void LoadCatalog()
        {
            Pacients = new List<Pacient>();
            MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
            if (connection.IsOpenConnection())
            {
                SqlDataReader dataReader = connection.SearchTableForName(PACIENT_TABLE);
                while (dataReader.Read())
                {
                    string medicalCardNumber = Convert.ToString(dataReader.GetValue(0));
                    Pacients.Add(new Pacient(medicalCardNumber,
                        Convert.ToString(dataReader.GetValue(1)),
                        Convert.ToString(dataReader.GetValue(2)),
                        Convert.ToString(dataReader.GetValue(3)),
                        Convert.ToDateTime(dataReader.GetValue(5)),
                        Convert.ToString(dataReader.GetValue(6)), 
                        MedicalPlaces.MedicalPlaceByNumber(Convert.ToInt32(dataReader.GetValue(7))),
                        Genders.GenderById(Convert.ToInt32(dataReader.GetValue(4))),
                        PacientSNILS(medicalCardNumber), PacientLicense(medicalCardNumber)));
                }
                dataReader.Close();
            }
            connection.CloseConnection();
        }

        private SNILS PacientSNILS(string medicalCardNumber)
        {
            SNILS selectSNILS = null;
            MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
            if (connection.IsOpenConnection())
            {
                string columns = "SNILS_NUM, SNILS_REGISTRATE_DATE";
                string term = "MEDICAL_CARD_NUM = N'" + medicalCardNumber + "'";
                SqlDataReader dataReader = 
                    connection.ComplexQueryElements(SNILS_TABLE, columns, term);
                if (dataReader.Read())
                {
                    selectSNILS = new SNILS(Convert.ToString(dataReader.GetValue(0)),
                        Convert.ToDateTime(dataReader.GetValue(1)));
                }
                dataReader.Close();
            }
            connection.CloseConnection();
            return selectSNILS;
        }

        private MedicalLicense PacientLicense(string medicalCardNumber)
        {
            MedicalLicense selectMedLicense = null;
            MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
            if (connection.IsOpenConnection())
            {
                string columns = "MEDICAL_LICENSE_NUM, REGISTRATE_DATE";
                string term = "MEDICAL_CARD_NUM = N'" + medicalCardNumber + "'";
                SqlDataReader dataReader =
                    connection.ComplexQueryElements(MEDICAL_LICENSE_TABLE, columns, term);
                if (dataReader.Read())
                {
                    selectMedLicense = new MedicalLicense(Convert.ToString(dataReader.GetValue(0)),
                        Convert.ToDateTime(dataReader.GetValue(1)));
                }
                dataReader.Close();
            }
            connection.CloseConnection();
            return selectMedLicense;
        }

        public bool AddNewPacient(Pacient addPacient)
        {
            bool isAddElement = false;
            if (!SearchPacient(addPacient))
            {
                MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
                if (connection.IsOpenConnection())
                {
                    if (!SearchPacientSNILS(addPacient.SNILS.SNILSNumber) &&
                        !SearchPacientLicense(addPacient.MedicalLicense.LicenseNumber))
                    {
                        string pacientParameters = "N'" + addPacient.MedicalCardNumber + "', N'" +
                            addPacient.Surname + "', N'" + addPacient.Name + "', N'" + 
                            addPacient.Patronimic + "', " + Convert.ToString(addPacient.Gender.GenderID) + ", '" + 
                            addPacient.BirthDate.ToString("MM.dd.yyyy") + "', N'" + addPacient.PhoneNumber + "', " +
                            Convert.ToString(addPacient.AttachmentPlace.PlaceNumber);
                        string licenseParameters = "N'" + addPacient.MedicalLicense.LicenseNumber + "', N'" + 
                            addPacient.MedicalCardNumber + "', '" +
                            addPacient.MedicalLicense.RegistrateDate.ToString("MM.dd.yyyy") + "'";
                        string SNILSParameters = "N'" + addPacient.SNILS.SNILSNumber + "', N'" + 
                            addPacient.MedicalCardNumber + "', '" +
                            addPacient.SNILS.RegistrateDate.ToString("MM.dd.yyyy") + "'";
                        isAddElement = connection.AddTableElement(PACIENT_TABLE, pacientParameters) &&
                            connection.AddTableElement(MEDICAL_LICENSE_TABLE, licenseParameters) &&
                            connection.AddTableElement(SNILS_TABLE, SNILSParameters);
                    }
                }
                connection.CloseConnection();
                LoadCatalog();
            }
            return isAddElement;
        }

        public bool UpdatePacientData(string medicalCardNumber, Pacient changePacient)
        {
            bool isUpdateElement = false;
            if (!SearchPacient(changePacient))
            {
                MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
                if (connection.IsOpenConnection())
                {
                    string pacientParameters = "SURNAME = N'" + changePacient.Surname + "', " +
                        "NAME = N'" + changePacient.Name + "', " + 
                        "PATRONIMIC = N'" + changePacient.Patronimic + "', " +
                        "GENDER_ID = " + Convert.ToString(changePacient.Gender.GenderID) + ", " +
                        "BIRTH_DATE = '" + changePacient.BirthDate.ToString("MM.dd.yyyy") + "', " +
                        "PHONE_NUMBER = N'" + changePacient.PhoneNumber + "', " +
                        "MEDICAL_PLACE_NUM = " + Convert.ToString(changePacient.AttachmentPlace.PlaceNumber);
                    string licenseParameters = "MEDICAL_LICENSE_NUM = N'" + 
                        changePacient.MedicalLicense.LicenseNumber + "', " +
                        "REGISTRATE_DATE = '" + changePacient.MedicalLicense.RegistrateDate.ToString("MM.dd.yyyy") + "'";
                    string SNILSParameters = "SNILS_NUM = N'" + changePacient.SNILS.SNILSNumber + "', " +
                        "SNILS_REGISTRATE_DATE = '" + changePacient.SNILS.RegistrateDate.ToString("MM.dd.yyyy") + "'";
                    string term = "MEDICAL_CARD_NUM = N'" + medicalCardNumber + "'";
                    isUpdateElement = connection.UpdateTableElement(PACIENT_TABLE, pacientParameters, term) &&
                        connection.UpdateTableElement(MEDICAL_LICENSE_TABLE, licenseParameters, term) &&
                        connection.UpdateTableElement(SNILS_TABLE, SNILSParameters, term);
                }
                connection.CloseConnection();
                LoadCatalog();
            }
            return isUpdateElement;
        }

        public bool DeletePacient(int selectIndex)
        {
            bool isDeleteElement = false;
            Pacient deletedPacient = Pacients[selectIndex];
            MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
            if (connection.IsOpenConnection())
            {
                string searchTerm = "MEDICAL_CARD_NUM = N'" +
                    deletedPacient.MedicalCardNumber + "'";
                SqlDataReader dataPacientReader =
                    connection.ComplexQueryElements("ANALYSIS", "ANALYSIS_NUMBER", searchTerm);
                bool isHasRows = dataPacientReader.HasRows;
                dataPacientReader.Close();
                if (!isHasRows)
                {
                    string deleteTerm = "MEDICAL_CARD_NUM = N'" +
                        deletedPacient.MedicalCardNumber + "'";
                    isDeleteElement = connection.DeleteTableElement(MEDICAL_LICENSE_TABLE, deleteTerm) &&
                        connection.DeleteTableElement(SNILS_TABLE, deleteTerm) &&
                        connection.DeleteTableElement(PACIENT_TABLE, deleteTerm);
                }
            }
            connection.CloseConnection();
            LoadCatalog();
            return isDeleteElement;
        }

        public Pacient PacientByIndex(int selectIndex)
        {
            return Pacients[selectIndex];
        }

        public Pacient PacientByMedicalCard(string medicalCardNumber)
        {
            return Pacients.Find(find => find.MedicalCardNumber == medicalCardNumber);
        }

        private bool SearchPacient(Pacient searchPacient)
        {
            return Pacients.Contains(searchPacient);
        }

        private bool SearchPacientSNILS(string SNILSNumber)
        {
            bool isSearchSNILS = false;
            MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
            if (connection.IsOpenConnection())
            {
                string term = "SNILS_NUM = N'" + SNILSNumber + "'";
                SqlDataReader dataReader =
                    connection.ComplexQueryElements(SNILS_TABLE, "*", term);
                isSearchSNILS = dataReader.HasRows;
                dataReader.Close();
            }
            connection.CloseConnection();
            return isSearchSNILS;
        }

        private bool SearchPacientLicense(string medicalLicenseNumber)
        {
            bool isSearchLicense = false;
            MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
            if (connection.IsOpenConnection())
            {
                string term = "MEDICAL_LICENSE_NUM = N'" + medicalLicenseNumber + "'";
                SqlDataReader dataReader =
                    connection.ComplexQueryElements(MEDICAL_LICENSE_TABLE, "*", term);
                isSearchLicense = dataReader.HasRows;
                dataReader.Close();
            }
            connection.CloseConnection();
            return isSearchLicense;
        }
    }
}