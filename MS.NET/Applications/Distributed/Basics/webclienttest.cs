using System;
using System.Text;
using System.Net;

static class Program
{
	public static void Main()
	{
		WebClient client = new WebClient();
		Console.Write("REQUEST : ");	
		byte[] request = Encoding.ASCII.GetBytes(Console.ReadLine());
		byte[] response = client.UploadData("http://khussain.met.edu/encode.asp", request);
		Console.WriteLine("RESPONSE: {0}", Encoding.ASCII.GetString(response));
	}
}