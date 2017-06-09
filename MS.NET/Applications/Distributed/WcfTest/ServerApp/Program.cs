using System;

namespace ServerApp
{
    using System.ServiceModel;

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ShopKeeperService));
            host.AddServiceEndpoint(typeof(Shopping.IShopKeeper), new NetTcpBinding(), "net.tcp://localhost:4011/shopping/shopkeeper");

            host.Open();
            Console.ReadKey(true);
            host.Close();
        }
    }
}
