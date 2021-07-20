using System.Data.SqlClient;

namespace BloodAnalysisApplication_Server.Model.DataClasses.DataSetting
{
    public class MicrosoftSQLConnection
    {
        private SqlConnection SQLConnection;

        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;
            AttachDbFilename=""|DataDirectory|\Database\SERVER_DATABASE.mdf"";Integrated Security=True";

        public MicrosoftSQLConnection()
        {
            SQLConnection = new SqlConnection(CONNECTION_STRING);
        }

        public bool IsOpenConnection()
        {
            if (SQLConnection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    SQLConnection.Open();
                    return true;
                }
                catch
                {
                    SQLConnection.Close();
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public bool AddTableElement(string tableName, string values)
        {
            string requestText = "INSERT INTO " + tableName + " VALUES (" + values + ");";
            SqlCommand command = new SqlCommand(requestText, SQLConnection);
            return (command.ExecuteNonQuery() == 1);
        }

        public bool UpdateTableElement(string tableName, string setParameters, string term)
        {
            string requestText = "UPDATE " + tableName + " SET " + setParameters + " WHERE " + term + ";";
            SqlCommand command = new SqlCommand(requestText, SQLConnection);
            return (command.ExecuteNonQuery() == 1);
        }

        public bool DeleteTableElement(string tableName, string term)
        {
            string requestText = "DELETE FROM " + tableName + " WHERE " + term + ";";
            SqlCommand command = new SqlCommand(requestText, SQLConnection);
            return (command.ExecuteNonQuery() == 1);
        }

        public SqlDataReader SearchTableForName(string tableName)
        {
            string requestText = "SELECT * FROM " + tableName + ";";
            return new SqlCommand(requestText, SQLConnection).ExecuteReader();
        }

        public SqlDataReader SearchTableElements(string tableName, string columnNames)
        {
            string requestText = "SELECT " + columnNames + " FROM " + tableName + ";";
            return new SqlCommand(requestText, SQLConnection).ExecuteReader();
        }

        public SqlDataReader ComplexQueryElements(string tableName, string columnNames, string term)
        {
            string requestText = "SELECT " + columnNames + " FROM " + tableName + " WHERE " + term + ";";
            return new SqlCommand(requestText, SQLConnection).ExecuteReader();
        }

        public void CloseConnection()
        {
            if (SQLConnection.State != System.Data.ConnectionState.Closed)
            {
                SQLConnection.Close();
            }
        }
    }
}