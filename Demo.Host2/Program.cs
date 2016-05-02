using System;
using System.ServiceModel;
using Demo.Services.New;

namespace Demo.Host2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "HOST 2";

            var host = new ServiceHost(typeof(DemoManager2));
            host.Open();

            Console.WriteLine("Service started...");
            Console.WriteLine("Press <Enter> to close the service");
            Console.ReadKey();

            host.Close();
        }
    }
}
