using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace BloodAnalysisApplication_Server
{
    class Program
    {
        private const string serverHost = "localhost";
        private const int serverPort = 9933;
        private static Thread serverThread;

        static void Main(string[] args)
        {
            serverThread = new Thread(StartServer);
            serverThread.IsBackground = true;
            serverThread.Start();
            while (true)
                HandlerCommand(Console.ReadLine());
        }

        private static void HandlerCommand(string command)
        {
            command = command.ToLower();
            if (command.Contains("/getclients"))
            {
                int countClients = Server.Server.Clients.Count;
                for (int i = 0; i < countClients; i++)
                {
                    Console.WriteLine("[{0}]: {1} " + Server.Server.Clients[i].AutorisationPositionClient(),
                        i, Server.Server.Clients[i].SocketName);
                }
                if (countClients == 0)
                {
                    Console.WriteLine("В системе не было создано ни одного потока");
                }
            }
        }

        private static void StartServer()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(serverHost);
            IPAddress ipAddress = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, serverPort);
            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipEndPoint);
            socket.Listen(1000);
            Console.WriteLine("Сервер запущен по следующему номеру IP: {0}.", ipEndPoint);
            while (true)
            {
                try
                {
                    Socket clientSocket = socket.Accept();
                    Server.Server.CreateClient(clientSocket);
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Ошибка: {0}", exp.Message);
                }
            }
        }
    }
}
