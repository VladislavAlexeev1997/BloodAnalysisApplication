using System;
using System.Net.Sockets;
using BloodAnalysisApplication_Server.Model.DataClasses.UserClasses;

namespace BloodAnalysisApplication_Server.Server
{
    public class Laborant : AutorisationUser
    {
        public Laborant(LaborantData data) : base(data) { }

        public override AutorisationType AutorisationUserType()
        {
            return AutorisationType.Laborant;
        }

        public override void UserHandleCommand(Socket handler, string command)
        {
            throw new NotImplementedException();
        }
    }
}