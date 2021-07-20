using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using BloodAnalysisApplication_Client.Model.DataClasses;
using BloodAnalysisApplication_Client.UserInterface;

namespace BloodAnalysisApplication_Client.Model.ClientListener
{
    public class ClientListener
    {
        public ClientRequestEnum requestListener;

        public Socket serverSocket;

        private Thread clientThread;

        private AutorisationSystemForm ControlForm;

        private const string SERVER_HOST = "localhost";

        private const int SERVER_PORT = 9933;

        private string requestMessage;

        public ClientListener(AutorisationSystemForm controlForm)
        {
            requestListener = ClientRequestEnum.None;
            requestMessage = "";
            ControlForm = controlForm;
            CreateNewServerConnect();
            CreateThread();
        }

        public ClientListener(Socket clientSocket, AutorisationSystemForm controlForm)
        {
            requestListener = ClientRequestEnum.None;
            requestMessage = "";
            ControlForm = controlForm;
            serverSocket = clientSocket;
            CreateThread();
        }

        private void CreateNewServerConnect()
        {
            try
            {
                IPHostEntry IP_HOST = Dns.GetHostEntry(SERVER_HOST);
                IPAddress IP_ADRESS = IP_HOST.AddressList[0];
                IPEndPoint IP_END_POINT = new IPEndPoint(IP_ADRESS, SERVER_PORT);
                serverSocket = new Socket(IP_ADRESS.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Connect(IP_END_POINT);
            }
            catch
            {
                requestListener = ClientRequestEnum.ExceptNone;
            }
        }

        private void CreateThread()
        {
            clientThread = new Thread(ListenerRequester);
            clientThread.IsBackground = true;
            clientThread.Start();
        }

        public void LaborantNamesRepost()
        {
            ListenerReposter("#getlaborantnames");
        }

        public void ConectUserRepost(string userType, string userName, string userPassword)
        {
            ListenerReposter("#connectuser&" + userType + "|" +
                userName + "|" + userPassword);
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
                requestListener = ClientRequestEnum.ExceptNone;
            }
        }

        public List<string> LaborantListRequest()
        {
            List<string> laborantList = new List<string>();
            if (!string.IsNullOrEmpty(requestMessage))
            {
                string[] laborantNames = requestMessage.Split('&')[1].Split('|');
                if (laborantNames.Length > 0)
                {
                    laborantList.AddRange(laborantNames);
                }
            }
            requestMessage = "";
            return laborantList;
        }

        public void UpdateThreadRequest()
        {
            CreateThread();
            requestListener = ClientRequestEnum.None;
        }

        private void ListenerRequester()
        {
            while (serverSocket.Connected)
            {
                byte[] buffer = new byte[8196];
                int bytesRec = serverSocket.Receive(buffer);
                string data = Encoding.UTF8.GetString(buffer, 0, bytesRec);
                if (data.Contains("#enteruser"))
                {
                    requestListener = ClientRequestEnum.EnterUser;
                }
                if (data.Contains("#notenteruser"))
                {
                    requestListener = ClientRequestEnum.NotEnterUser;
                }
                if (data.Contains("#returnlaborantnames"))
                {
                    requestListener = ClientRequestEnum.LaborantNames;
                    requestMessage = data;
                }
                if (data.Contains("#exitlastuser"))
                {
                    requestListener = ClientRequestEnum.ExitLastUser;
                }
                ControlForm.DistributeRequestFunction();
            }
        }

        public void AbortThread()
        {
            clientThread.Abort();
        }
    }

    public enum ClientRequestEnum
    {
        None,
        ExceptNone,
        EnterUser,
        NotEnterUser,
        LaborantNames,
        ExitLastUser
    }
}
