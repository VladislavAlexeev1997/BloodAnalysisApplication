using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using BloodAnalysisApplication_Client.UserInterface;
using BloodAnalysisApplication_Client.Model.LaborantData;

namespace BloodAnalysisApplication_Client.Model.ClientListener
{
    public class AdministratorListener
    {
        public AdministratorRequestEnum requestListener;

        private Socket serverSocket;

        private Thread administratorThread;

        private AdministrateWorkForm ControlForm;

        private AddEditEmployeeDataForm AddEditForm;

        private string requestMessage;

        public AdministratorListener(Socket clientSocket, AdministrateWorkForm controlForm)
        {
            requestListener = AdministratorRequestEnum.None;
            requestMessage = "";
            serverSocket = clientSocket;
            ControlForm = controlForm;
            AddEditForm = null;
            CreateThread();
        }

        private void CreateThread()
        {
            administratorThread = new Thread(ListenerRequester);
            administratorThread.IsBackground = true;
            administratorThread.Start();
        }

        public void EmployeeListRepost()
        {
            ListenerReposter("#getemployees&");
        }

        public void AddEmployeeData(Laborant newEmployeeData, AddEditEmployeeDataForm AddForm)
        {
            string command = "#addemployee&";
            command += newEmployeeData.Surname + "|" +
                newEmployeeData.Name + "|" + newEmployeeData.Patronimic + "|" +
                newEmployeeData.BirthDate.ToString("MM.dd.yyyy") + "|" +
                newEmployeeData.Gender.GenderID.ToString() + "|" +
                newEmployeeData.EmployeeContractNumber + "|" +
                newEmployeeData.Password + "|" +
                (Convert.ToInt32(newEmployeeData.Activity)).ToString();
            AddEditForm = AddForm;
            ListenerReposter(command);
        }

        public void EditEmployeeData(Laborant employeeData, AddEditEmployeeDataForm EditForm)
        {
            string command = "#editemployee&";
            command += employeeData.UserIdentificator + "|" + employeeData.Surname + "|" +
                employeeData.Name + "|" + employeeData.Patronimic + "|" +
                employeeData.BirthDate.ToString("MM.dd.yyyy") + "|" +
                employeeData.Gender.GenderID.ToString() + "|" +
                employeeData.EmployeeContractNumber + "|" +
                employeeData.Password + "|" +
                (Convert.ToInt32(employeeData.Activity)).ToString();
            AddEditForm = EditForm;
            ListenerReposter(command);
        }

        public void AdministratorExitRepost()
        {
            ListenerReposter("#exituser");
        }

        private void ListenerReposter(string data)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                int bytesSent = serverSocket.Send(buffer);
            }
            catch
            {
                requestListener = AdministratorRequestEnum.ExceptNone;
            }
        }

        public List<Laborant> LaborantListRequest()
        {
            List<Laborant> laborants = new LaborantVocabulary(requestMessage).Laborants;
            requestMessage = "";
            return laborants;
        }

        public ClientListener AdministratorExitRequest(AutorisationSystemForm startForm)
        {
            return new ClientListener(serverSocket, startForm);
        }

        private void ListenerRequester()
        {
            while (serverSocket.Connected)
            {
                byte[] buffer = new byte[8196];
                int bytesRec = serverSocket.Receive(buffer);
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);
                if (data.Contains("#returnemployees"))
                {
                    requestListener = AdministratorRequestEnum.EmployeeList;
                    requestMessage = data;
                    ControlForm.DistributeRequestFunction();
                }
                if (data.Contains("#addsucsess"))
                {
                    requestListener = AdministratorRequestEnum.AddSucsess;
                    AddEditForm.DistributeRequestFunction();
                }
                if (data.Contains("#editsucsess"))
                {
                    requestListener = AdministratorRequestEnum.EditSucsess;
                    AddEditForm.DistributeRequestFunction();
                }
                if (data.Contains("#addcancel"))
                {
                    requestListener = AdministratorRequestEnum.AddCancel;
                    AddEditForm.DistributeRequestFunction();
                }
                if (data.Contains("#editcancel"))
                {
                    requestListener = AdministratorRequestEnum.EditCancel;
                    AddEditForm.DistributeRequestFunction();
                }
            }
        }

        public void AbortThread()
        {
            administratorThread.Abort();
        }
    }

    public enum AdministratorRequestEnum
    {
        None,
        ExceptNone,
        EmployeeList,
        AddSucsess,
        EditSucsess,
        AddCancel,
        EditCancel
    }
}
