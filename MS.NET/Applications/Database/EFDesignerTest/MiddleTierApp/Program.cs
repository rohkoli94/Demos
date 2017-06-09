using System;

namespace MiddleTierApp
{
    using System.ServiceModel;

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(OrderManagerService));

            host.Open();
            Console.ReadKey(true);
            host.Close();
        }
    }
}
