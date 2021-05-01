using ChattingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Collections.Concurrent;

namespace ChattingServer
{
    /// <summary>
    /// Class for login and logout operations
    /// </summary>
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class ChattingService : IChattingService
    {
        /// <summary>
        /// to hold the logged in users
        /// </summary>
        public ConcurrentDictionary<string, ConnectedUser> connectedUsers = new ConcurrentDictionary<string, ConnectedUser>();

        public int Login(string userName)
        {
            // this is to check if same username logged in again 
            foreach (var client in connectedUsers)
            {
                if (client.Key.ToLower() == userName.ToLower())
                {
                    return 1;
                }
            }
            var userConnection = OperationContext.Current.GetCallbackChannel<IClientContracts>();
            ConnectedUser newUser = new ConnectedUser();
            newUser.connection = userConnection;
            newUser.UserName = userName;

            connectedUsers.TryAdd(userName, newUser);
            return 0;

        }

        public void Logout()
        {

        }

        public void SendMessage(string message, string userName)
        {
            foreach (var users in connectedUsers)
            {
                if (users.Key.ToLower() != userName.ToLower())
                {
                    users.Value.connection.GetMessage(message, userName);
                }
            }
        }
    }
}
