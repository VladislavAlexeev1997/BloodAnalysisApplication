using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BloodAnalysisApplication_Client.Model.DataClasses;
using BloodAnalysisApplication_Client.Model.DataClasses.AnalysisClasses;

namespace BloodAnalysisApplication_Client.Model.DataSetting
{
    public class AnalysisCatalog
    {
        public List<Analysis> AnalysisCatalogData { get; private set; }

        private const string ANALYSIS_TABLE = "ANALYSIS";

        private const string BLOOD_IMAGE_TABLE = "BLOOD_IMAGES";

        private const string RESULT_TABLE = "ANALYSIS_RESULTS";

        private const string ERYTHROCYTES_TABLE = "FINDED_ERYTHROCYTES";

        private const string LEUKOCYTES_TABLE = "FINDED_LEUKOCYTES";

        public AnalysisCatalog()
        {
            LoadCatalog();
        }

        private void LoadCatalog()
        {
            AnalysisCatalogData = new List<Analysis>();
            MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
            if (connection.IsOpenConnection())
            {
                SqlDataReader dataReader = connection.SearchTableForName(ANALYSIS_TABLE);
                while (dataReader.Read())
                {
                    string analysisNumber = Convert.ToString(dataReader.GetValue(0));
                    AnalysisCatalogData.Add(new Analysis(analysisNumber,
                        Convert.ToString(dataReader.GetValue(1)),
                        Convert.ToDateTime(dataReader.GetValue(3)),
                        AnalysisBloodImage(analysisNumber),
                        Convert.ToInt32(dataReader.GetValue(2)),
                        AnalysisResult(analysisNumber)));
                }
                dataReader.Close();
            }
            connection.CloseConnection();
        }

        private BloodImage AnalysisBloodImage(string analysisNumber)
        {
            BloodImage selectBloodImage = null;
            MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
            if (connection.IsOpenConnection())
            {
                string columns = "FILE_NAME, BLOOD_IMAGE_DATE";
                string term = "ANALYSIS_NUMBER = N'" + analysisNumber + "'";
                SqlDataReader dataReader =
                    connection.ComplexQueryElements(BLOOD_IMAGE_TABLE, columns, term);
                if (dataReader.Read())
                {
                    selectBloodImage = new BloodImage(Convert.ToString(dataReader.GetValue(0)),
                        Convert.ToDateTime(dataReader.GetValue(1)));
                }
                dataReader.Close();
            }
            connection.CloseConnection();
            return selectBloodImage;
        }

        private Result AnalysisResult(string analysisNumber)
        {
            Result selectResult = null;
            MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
            if (connection.IsOpenConnection())
            {
                string resultColumns = "ANALYSIS_RESULT_TEXT";
                string term = "ANALYSIS_NUMBER = N'" + analysisNumber + "'";
                SqlDataReader resultDataReader =
                    connection.ComplexQueryElements(RESULT_TABLE, resultColumns, term);
                if (resultDataReader.Read())
                {
                    ErythrocyteResult erythrocytes = null;
                    LeukocyteResult leukocytes = null;
                    MicrosoftSQLConnection resultConnection = new MicrosoftSQLConnection();
                    if (resultConnection.IsOpenConnection())
                    {
                        string erythrocyteColumns = "ERYTHROCYTE_COUNT, ERYTHROCYTE_IMAGE_NAME";
                        SqlDataReader erythrocyteDataReader =
                            resultConnection.ComplexQueryElements(ERYTHROCYTES_TABLE, erythrocyteColumns, term);
                        if (erythrocyteDataReader.Read())
                        {
                            erythrocytes = new ErythrocyteResult(
                                Convert.ToInt32(erythrocyteDataReader.GetValue(0)),
                                Convert.ToString(erythrocyteDataReader.GetValue(1)));
                        }
                        erythrocyteDataReader.Close();
                        string leukocyteColumns = "LEUKOCYTE_COUNT, LEUKOCYTE_IMAGE_NAME";
                        SqlDataReader leukocyteDataReader =
                            resultConnection.ComplexQueryElements(LEUKOCYTES_TABLE, leukocyteColumns, term);
                        if (leukocyteDataReader.Read())
                        {
                            leukocytes = new LeukocyteResult(
                                Convert.ToInt32(leukocyteDataReader.GetValue(0)),
                                Convert.ToString(leukocyteDataReader.GetValue(1)));
                        }
                        leukocyteDataReader.Close();
                    }
                    resultConnection.CloseConnection();
                    selectResult = new Result(erythrocytes, leukocytes,
                        Convert.ToString(resultDataReader.GetValue(0)));
                }
                resultDataReader.Close();
            }
            connection.CloseConnection();
            return selectResult;
        }

        public bool AddNewAnalysis(Analysis addAnalysis)
        {
            bool isAddElement = false;
            MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
            if (connection.IsOpenConnection())
            {
                string analysisParameters = "N'" + addAnalysis.AnalysisNumber + "', N'" +
                    addAnalysis.MedicalCardNumber + "', " + 
                    Convert.ToString(addAnalysis.EmployeeNumber) + ", '" +
                    addAnalysis.AnalysisData.ToString("MM.dd.yyyy") + "'";
                string bloodImageParameters = "N'" + addAnalysis.AnalysisNumber + "', N'" + 
                    addAnalysis.BloodImage.FileName + "', '" +
                    addAnalysis.BloodImage.BloodImageDate.ToString("MM.dd.yyyy") + "'";
                string resultParameters = "N'" + addAnalysis.AnalysisNumber + "', N'" +
                    addAnalysis.AnalysisResult.ResultText + "'";
                string erythrocyteParameters = "N'" + addAnalysis.AnalysisNumber + "', " +
                    Convert.ToString(addAnalysis.AnalysisResult.Erythrocytes.CellCount) + ", N'" +
                    addAnalysis.AnalysisResult.Erythrocytes.FileName + "'";
                string leukocyteParameters = "N'" + addAnalysis.AnalysisNumber + "', " +
                    Convert.ToString(addAnalysis.AnalysisResult.Leukocytes.CellCount) + ", N'" +
                    addAnalysis.AnalysisResult.Leukocytes.FileName + "'";
                isAddElement = connection.AddTableElement(ANALYSIS_TABLE, analysisParameters) &&
                    connection.AddTableElement(BLOOD_IMAGE_TABLE, bloodImageParameters) &&
                    connection.AddTableElement(RESULT_TABLE, resultParameters) &&
                    connection.AddTableElement(ERYTHROCYTES_TABLE, erythrocyteParameters) &&
                    connection.AddTableElement(LEUKOCYTES_TABLE, leukocyteParameters);
            }
            connection.CloseConnection();
            LoadCatalog();
            return isAddElement;
        }

        public bool DeleteAnalysis(int selectIndex)
        {
            bool isDeleteElement = false;
            Analysis deletedAnalysis = AnalysisCatalogData[selectIndex];
            MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
            if (connection.IsOpenConnection())
            {
                string deleteTerm = "ANALYSIS_NUMBER = N'" +
                    deletedAnalysis.AnalysisNumber + "'";
                isDeleteElement = connection.DeleteTableElement(ERYTHROCYTES_TABLE, deleteTerm) &&
                    connection.DeleteTableElement(LEUKOCYTES_TABLE, deleteTerm) &&
                    connection.DeleteTableElement(BLOOD_IMAGE_TABLE, deleteTerm) &&
                    connection.DeleteTableElement(RESULT_TABLE, deleteTerm) &&
                    connection.DeleteTableElement(ANALYSIS_TABLE, deleteTerm);
            }
            connection.CloseConnection();
            LoadCatalog();
            return isDeleteElement;
        }
        
        public Analysis AnalysisByIndex(int selectIndex)
        {
            return AnalysisCatalogData[selectIndex];
        }

        public Laborant AnalysisLaborant(int selectIndex)
        {
            Laborant selectLaborant = null;
            MicrosoftSQLConnection connection = new MicrosoftSQLConnection();
            if (connection.IsOpenConnection())
            {
                Analysis selectAnalysis = AnalysisByIndex(selectIndex);
                string columns = "SURNAME, NAME, PATRONIMIC";
                string term = "LABORANT_ID = " + Convert.ToString(selectAnalysis.EmployeeNumber);
                SqlDataReader dataReader = connection.ComplexQueryElements("LABORANT", columns, term);
                if (dataReader.Read())
                {
                    selectLaborant = new Laborant(Convert.ToString(dataReader.GetValue(0)),
                        Convert.ToString(dataReader.GetValue(1)), 
                        Convert.ToString(dataReader.GetValue(2)));
                }
                dataReader.Close();
            }
            connection.CloseConnection();
            return selectLaborant;
        }
    }
}