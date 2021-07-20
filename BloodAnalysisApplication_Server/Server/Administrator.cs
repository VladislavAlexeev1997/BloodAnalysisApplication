using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using BloodAnalysisApplication_Server.Model.DataClasses.DataSetting;
using BloodAnalysisApplication_Server.Model.DataClasses.UserClasses;

namespace BloodAnalysisApplication_Server.Server
{
    public class Administrator : AutorisationUser
    {
        public Administrator(AdministratorData data) 
            : base(data) { }

        public override AutorisationType AutorisationUserType()
        {
            return AutorisationType.Administrator;
        }

        public override void UserHandleCommand(Socket handler, string command)
        {
            if (command.Contains("#getemployees"))
            {
                GetEmployeesSystem(handler);
            }
            else if(command.Contains("#addemployee"))
            {
                AddEmployeeData(handler, command);
            }
            else if (command.Contains("#editemployee"))
            {
                EditEmployeeData(handler, command);
            }
        }

        private void GetEmployeesSystem(Socket handler)
        {
            UserCatalog users = new UserCatalog();
            List<UserData> laborants = users.UserTypeCatalog(UserType.Laborant);
            string returndata = "#returnemployees&";
            for (int count = 0; count < laborants.Count; count++)
            {
                LaborantData selectLaborant = (LaborantData)laborants[count];
                returndata += selectLaborant.UserIdentificator + "|" +
                    selectLaborant.Password + "|" + selectLaborant.Surname + "|" +
                    selectLaborant.Name + "|" + selectLaborant.Patronimic + "|" +
                    selectLaborant.BirthDate.ToString("dd.MM.yyyy") + "|" +
                    selectLaborant.Gender.GenderID.ToString() + "|" +
                    selectLaborant.EmployeeContractNumber + "|" +
                    selectLaborant.Activity.ToString();
                if (count < laborants.Count - 1)
                {
                    returndata += "~";
                }
            }
            Send(handler, returndata);
        }

        private void AddEmployeeData(Socket handler, string command)
        {
            string returndata = "#add";
            string[] employeeData = command.Split('&')[1].Split('|');
            UserCatalog users = new UserCatalog();
            List<UserData> laborants = users.UserTypeCatalog(UserType.Laborant);
            string userParameters = "N'laborant" + (laborants.Count + 1).ToString() + "', N'" + employeeData[6] + "'";
            string employeeParameters = "N'laborant" + (laborants.Count + 1).ToString() + "', N'" +
                employeeData[0] + "', N'" + employeeData[1] + "', N'" + employeeData[2] + "', '" +
                employeeData[3] + "', " + employeeData[4] + ", N'" + employeeData[5] + "', " +
                employeeData[7];
            MicrosoftSQLConnection databaseConnection = new MicrosoftSQLConnection();
            if(databaseConnection.IsOpenConnection())
            {
                if(databaseConnection.AddTableElement("SYS_USER", userParameters))
                {
                    databaseConnection.AddTableElement("LABORANT", employeeParameters);
                    returndata += "sucsess&";
                }
                else
                {
                    returndata += "cancel&";
                }
            }
            else
            {
                returndata += "cancel&";
            }
            databaseConnection.CloseConnection();
            Send(handler, returndata);
        }

        private void EditEmployeeData(Socket handler, string command)
        {
            string returndata = "#edit";
            string[] employeeData = command.Split('&')[1].Split('|');
            string userParameters = "PASSWORD = N'" + employeeData[7] + "'";
            string employeeParameters = "SURNAME = N'" + employeeData[1] + "', " +
                "NAME = N'" + employeeData[2] + "', " +
                "PATRONIMIC = N'" + employeeData[3] + "', " +
                "BIRTH_DATE = '" + employeeData[4] + "', " +
                "GENDER_ID = " + employeeData[5] + ", " +
                "CONTRACT_NUMBER = N'" + employeeData[6] + "', " +
                "ACTIVITY = " + employeeData[8];
            MicrosoftSQLConnection databaseConnection = new MicrosoftSQLConnection();
            if (databaseConnection.IsOpenConnection())
            {
                databaseConnection.UpdateTableElement("SYS_USER", 
                    userParameters, "SYS_USER_ID = '" + employeeData[0] + "'");
                databaseConnection.UpdateTableElement("LABORANT", 
                    employeeParameters, "LABORANT_ID = '" + employeeData[0] + "'");
                returndata += "sucsess&";
            }
            else
            {
                returndata += "cancel&";
            }
            databaseConnection.CloseConnection();
            Send(handler, returndata);
        }

        private void Send(Socket handler, string command)
        {
            try
            {
                int bytesSent = handler.Send(Encoding.UTF8.GetBytes(command));
                if (bytesSent > 0) Console.WriteLine("Запрос пользователя {0} обработан успешно", 
                    Data.UserIdentificator);
            }
            catch (Exception exp)
            {
                Console.WriteLine("Ошибка отправки ответа в клиентскую часть: {0}.", exp.Message);
            }
        }
    }
}