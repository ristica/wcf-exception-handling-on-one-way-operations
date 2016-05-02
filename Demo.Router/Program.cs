using System;
using System.ServiceModel;
using System.ServiceModel.Routing;

namespace Demo.Router
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ROUTING HOST";

            var host = new ServiceHost(typeof(RoutingService));
            host.Open();

            Console.WriteLine("Service started...");
            Console.WriteLine("Press <Enter> to close the service");
            Console.ReadKey();

            host.Close();
        }
    }
}
