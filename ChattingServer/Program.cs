using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChattingServer
{
    class Program
    {
        public static ChattingService service;
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(service))
            {
                host.Open();
                Console.WriteLine("Server started ...");
                Console.ReadLine();
            }
        }
    }
}
