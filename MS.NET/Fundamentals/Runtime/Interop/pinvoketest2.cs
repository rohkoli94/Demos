using System;
using System.Text;
using System.Runtime.InteropServices;

static class Program
{
	[DllImport(@"legacy\x86\hashenc", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Unicode)]
	private extern static int HashOfString(string str);
	
	[DllImport(@"legacy\x86\hashenc", CallingConvention=CallingConvention.StdCall, CharSet=CharSet.Ansi)]
	private extern static int EncodeBuffer(StringBuilder buf, int sz);

	public static void Main()
	{
		Console.Write("Orignal string: ");
		string str = Console.ReadLine();
		Console.WriteLine("Hash of string: {0:X}", HashOfString(str));		
		
		StringBuilder buf = new StringBuilder(str);
		EncodeBuffer(buf, buf.Length);
		Console.WriteLine("Encoded string: {0}", buf.ToString());
	}
}