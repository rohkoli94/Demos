using System;
using System.IO;

static class Program
{
	public static void Main(string[] args)
	{
		using(FileStream stream = new FileStream(args[0], FileMode.Open, FileAccess.ReadWrite))		
		{	
			int n = (int)stream.Length;
			byte[] buffer = new byte[n];
			stream.Read(buffer, 0, n);

			for(int i = 0, j = n - 1; i < j; ++i, j--)
			{	
				byte ib = buffer[i];
				byte jb = buffer[j];
				buffer[i] = jb;
				buffer[j] = ib;	
			}
		
			stream.Position = 0;
			stream.Write(buffer, 0, n);
		}
	}
}