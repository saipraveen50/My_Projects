using ChattingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChattingServer
{
    public class ConnectedClient
    {
        public IClientContracts connection;
        public string UserName { get; set; }

    }
}
