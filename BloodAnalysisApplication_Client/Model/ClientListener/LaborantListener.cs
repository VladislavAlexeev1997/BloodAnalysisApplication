using System.Text;
using System.Net.Sockets;
using System.Threading;
using BloodAnalysisApplication_Client.Model.DataClasses;
using BloodAnalysisApplication_Client.UserInterface;

namespace BloodAnalysisApplication_Client.Model.ClientListener
{
    public class LaborantListener
    {
        public LaborantRequestEnum requestListener;

        private Socket serverSocket;

        private Thread laborantThread;

        private Laborant LaborantData;

        private string requestMessage;

        public LaborantListener(Socket clientSocket, Laborant data)
        {
            serverSocket = clientSocket;
            requestListener = LaborantRequestEnum.None;
            requestMessage = "";
            LaborantData = data;
            CreateThread();
        }

        private void CreateThread()
        {
            laborantThread = new Thread(ListenerRequester);
            laborantThread.IsBackground = true;
            laborantThread.Start();
        }
        public void LaborantExitRepost()
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
                requestListener = LaborantRequestEnum.ExceptNone;
            }
        }

        public ClientListener LaboratExitRequest(AutorisationSystemForm startForm)
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
            }
        }

        public void AbortThread()
        {
            laborantThread.Abort();
        }

        public string FullLaborantName()
        {
            return LaborantData.FullLaborantName();
        }

        public string ShortLaborantName()
        {
            return LaborantData.ShortLaborantName();
        }
    }

    public enum LaborantRequestEnum
    {
        None,
        ExceptNone
    }
}
