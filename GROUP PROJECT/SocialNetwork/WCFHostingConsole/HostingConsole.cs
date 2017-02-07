using SocialNetwork.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFHostingConsole
{
    class HostingConsole
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(SearchLogic)))
            {
                string hostName = Dns.GetHostName();
                string port = "60000";
                string serviceName = "SocialNetwork";

                string address = "net.tcp://" + hostName + ":" + port + "/" + serviceName;

                Console.WriteLine("Host: Launching service on " + hostName);

                Console.WriteLine();

                var endPoint = host.AddServiceEndpoint(typeof(ISearchLogic), new NetTcpBinding(), address);

                host.Open();

                Console.WriteLine("Use this address {0}", address);

                Console.WriteLine();

                Console.WriteLine("Please hit ENTER to terminate SERVICE host....");

                Console.Read();

            }
        }              

    }
}
