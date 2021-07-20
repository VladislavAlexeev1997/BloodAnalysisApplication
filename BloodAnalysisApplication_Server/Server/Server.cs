using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace BloodAnalysisApplication_Server.Server
{
    public static class Server
    {
        public static List<Client> Clients = new List<Client>();
        
        public static void CreateClient(Socket handle)
        {
            try
            {
                Client newClient = new Client(handle);
                Clients.Add(newClient);
                Console.WriteLine("Создан новый поток клиента: {0}", handle.RemoteEndPoint);
            }
            catch (Exception exp) { Console.WriteLine("Ошибка создания потока клиента: {0}.", exp.Message); }
        }

        public static void ExitClient(Client client)
        {
            try
            {
                Console.WriteLine("Поток клиента {0} был окончен.", client.SocketName);
                client.End();
                Clients.Remove(client);
            }
            catch (Exception exp) { Console.WriteLine("Error with exit client: {0}.", exp.Message); }
        }
    }
}