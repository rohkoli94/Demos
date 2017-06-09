using System;

namespace ServerApp
{
    using System.ServiceModel;

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(CartService));

            host.Open();
            Console.ReadKey(true);
            host.Close();
        }
    }
}
