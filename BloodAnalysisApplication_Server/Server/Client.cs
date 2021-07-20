using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using BloodAnalysisApplication_Server.Model.DataClasses.DataSetting;
using BloodAnalysisApplication_Server.Model.DataClasses.UserClasses;

namespace BloodAnalysisApplication_Server.Server
{
    public class Client
    {
        private Socket handler;

        private Thread clientThread;

        private AutorisationUser User;

        public Client(Socket socket)
        {
            handler = socket;
            clientThread = new Thread(StartClientListener);
            clientThread.IsBackground = true;
            clientThread.Start();
            User = new AutorisationUser(new UserData("", ""));
        }

        public string SocketName
        {
            get
            {
                return handler.RemoteEndPoint.ToString();
            }
        }

        public string AutorisationPositionClient()
        {
            if (User.AutorisationUserType() == AutorisationType.NonAutorisation)
            {
                return "не вошел в систему";
            }
            else
            {
                string message = "вошел в систему под идентификатором ";
                message += User.Data.UserIdentificator;
                return message;
            }
        }

        private void StartClientListener()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    int bytesRec = handler.Receive(buffer);
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);
                    HandleCommand(data);
                }
                catch
                {
                    Server.ExitClient(this);
                    return;
                }
            }
        }

        private void HandleCommand(string data)
        {
            if (data.Contains("#connectuser"))
            {
                DoEnterUser(data);
            }
            else if (data.Contains("#getlaborantnames"))
            {
                GetLaborantNames();
            }
            else if (data.Contains("#exituser"))
            {
                ExitUser();
            }
            else
            {
                User.UserHandleCommand(handler, data);
            }
        }

        private void DoEnterUser(string command)
        {
            string[] enterParameters = command.Split('&')[1].Split('|');
            UserCatalog users = new UserCatalog();
            UserData searchUser = users.SearchEnterUser((UserType)Convert.ToInt32(enterParameters[0]),
                Convert.ToInt32(enterParameters[1]), enterParameters[2]);
            if (searchUser != null)
            {
                if (searchUser.GetUserType() == UserType.Administrator)
                {
                    User = new Administrator((AdministratorData)searchUser);
                }
                else
                {
                    User = new Laborant((LaborantData)searchUser);
                }
                Console.WriteLine("Клиент {0} зашел в систему в виде пользователя: {1}", 
                    handler.RemoteEndPoint, searchUser.UserIdentificator);
                Send("#enteruser");
            }
            else
            {
                Send("#notenteruser");
            }
        }

        private void GetLaborantNames()
        {
            UserCatalog users = new UserCatalog();
            List<UserData> laborants = users.UserTypeCatalog(UserType.Laborant);
            string returndata = "#returnlaborantnames&";
            for (int count = 0; count < laborants.Count; count++)
            {
                if (((LaborantData)laborants[count]).Activity)
                {
                    returndata += ((LaborantData)laborants[count]).FullName();
                    if (count < laborants.Count - 1)
                    {
                        returndata += "|";
                    }
                }
            }
            Send(returndata);
        }

        private void ExitUser()
        {
            User.ExitUser(handler);
            User = new AutorisationUser(new UserData("", ""));
            Send("#exitlastuser");
        }

        private void Send(string command)
        {
            try
            {
                int bytesSent = handler.Send(Encoding.UTF8.GetBytes(command));
                if (bytesSent > 0) Console.WriteLine("Ответ клиентской части отправлен успешно");
            }
            catch (Exception exp)
            {
                Console.WriteLine("Ошибка отправки ответа в клиентскую часть: {0}.", exp.Message);
                Server.ExitClient(this);
            }
        }

        public void End()
        {
            try
            {
                handler.Close();
                try
                {
                    clientThread.Abort();
                }
                catch { }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Ошибка окончания потока клиента: {0}.", exp.Message);
            }
        }
    }
}