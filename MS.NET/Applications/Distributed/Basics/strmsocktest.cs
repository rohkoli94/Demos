using System;
using System.Net;
using System.Net.Sockets;

static class Program
{
	public static void Main()
	{
		//step 1 - create a stream socket bound to wellknown endpoint
		Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		EndPoint local = new IPEndPoint(IPAddress.Any, 2056);
		server.Bind(local);

		//step 2 - switch the above socket to listening mode
		server.Listen(10);

		for(;;)
		{
			//step 3 - accept a client's connection request
			Socket client = server.Accept();

			//step 4 - exchange data with the client
			byte[] buffer = new byte[80];
			int n = client.Receive(buffer);
			for(int i = 0; i < n; ++i)
				buffer[i] = (byte)(buffer[i] ^ '#');
			client.Send(buffer, 0, n, SocketFlags.None);

			//step 5 - close client's connection and go to step 3
			client.Close();
		}
	}
}