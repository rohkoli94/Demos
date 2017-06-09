using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

class ClientHandler : MarshalByRefObject
{
	public ClientHandler()
	{
		Console.WriteLine("ClientHandler initialized in app-domain<{0}>", AppDomain.CurrentDomain.FriendlyName);
	}

	public void Communicate(Stream connection)
	{
		byte[] buffer = new byte[80];
		int n = connection.Read(buffer, 0, buffer.Length);

		for(int i = 0; i < n; ++i)
			buffer[i] = (byte)(buffer[i] ^ '#');

		connection.Write(buffer, 0, n);
	}

	~ClientHandler()
	{
		Console.WriteLine("ClientHandler finalized in app-domain<{0}>", AppDomain.CurrentDomain.FriendlyName);
	}
}

static class Program
{
	public static void Main()
	{
		TcpListener listener = new TcpListener(IPAddress.Any, 2056);
		listener.Start();

		//Service(listener);
		for(int i = 1; i <= 3; ++i)
		{
			Thread servant = new Thread(delegate(){Service(listener);});
			servant.Name = "st" + i;
			servant.Start();
		}
	}

	private static void Service(TcpListener server)
	{
		for(;;)
		{
			TcpClient client = server.AcceptTcpClient();
			client.ReceiveTimeout = 60000;
			
			NetworkStream stream = client.GetStream();
			//ClientHandler handler = new ClientHandler();
			AppDomain clientDom = AppDomain.CreateDomain(Thread.CurrentThread.Name);
			ClientHandler handler = (ClientHandler)clientDom.CreateInstanceAndUnwrap("tcplistenertest", "ClientHandler");
			try
			{
				handler.Communicate(stream);
			}
			catch(Exception ex)
			{
				Console.WriteLine("Communication failure: {0}", ex.Message);
			}
			AppDomain.Unload(clientDom);
			stream.Close();

			client.Close();
		}
	}
}