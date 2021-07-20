using System;
using System.Net.Sockets;
using BloodAnalysisApplication_Server.Model.DataClasses.UserClasses;

namespace BloodAnalysisApplication_Server.Server
{
    public class AutorisationUser
    {
        public AutorisationUser(UserData data)
        {
            Data = data;
        }

        public UserData Data { get; }

        public virtual AutorisationType AutorisationUserType()
        {
            return AutorisationType.NonAutorisation;
        }

        public virtual void UserHandleCommand(Socket handler, string command) { }

        public void ExitUser(Socket handler)
        {
            Console.WriteLine("Пользователь {0} под клиентом {1} вышел из системы", 
                Data.UserIdentificator, handler.RemoteEndPoint);
        }
    }
}