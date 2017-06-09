using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

static class Program
{
	public static void Main(string[] args)
	{
		string host = args.Length > 0 ? args[0] : "localhost";
		UdpClient client = new UdpClient();
		client.Connect(host, 2056);

		Console.Write("REQUEST : ");
		string text = Console.ReadLine();
		byte[] request = Encoding.ASCII.GetBytes(text);
		client.Send(request, request.Length);
		IPEndPoint remote = null;
		byte[] response = client.Receive(ref remote);
		Console.WriteLine("RESPONSE: {0}", Encoding.ASCII.GetString(response));

		client.Close();
	}
}