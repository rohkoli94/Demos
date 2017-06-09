using System;
using System.Net;
using System.Net.Sockets;

static class Program
{
	public static void Main()
	{
		//step 1 - create a datagram socket bound to wellknown endpoint 
		Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
		EndPoint local = new IPEndPoint(IPAddress.Any, 2056);
		server.Bind(local);

		for(;;)
		{
			//step 2 - exchange data with the client
			EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
			byte[] buffer = new byte[80];
			int n = server.ReceiveFrom(buffer, ref remote);
			for(int i = 0; i < n; ++i)
				buffer[i] = (byte)(buffer[i] ^ '#');
			server.SendTo(buffer, 0, n, SocketFlags.None, remote);

			//step 3 - go to step 2
		}
	}
}