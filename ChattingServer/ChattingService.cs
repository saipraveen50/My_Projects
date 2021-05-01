using ChattingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChattingServer
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class ChattingService : IChattingService
    {
<<<<<<< Updated upstream
        
=======
        /// <summary>
        /// to hold the logged in users
        /// </summary>
        public ConcurrentDictionary<string, ConnectedUser> connectedUsers = new ConcurrentDictionary<string, ConnectedUser>();

        public int Login(string userName)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
>>>>>>> Stashed changes
    }
}
