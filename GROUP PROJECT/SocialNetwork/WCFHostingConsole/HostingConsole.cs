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
                string address = "net.tcp://" + Dns.GetHostName() + ":8081/SocialNetwork";
                host.AddServiceEndpoint(typeof(ISearchLogic), new NetTcpBinding(), address); 
                host.Open();                
            }
            Console.WriteLine("net.tcp://" + Dns.GetHostName() + ":8081/SocialNetwork");        
            Console.WriteLine("Press any key to stop hosting");
            Console.ReadKey();      
                        
        }
    }
}
