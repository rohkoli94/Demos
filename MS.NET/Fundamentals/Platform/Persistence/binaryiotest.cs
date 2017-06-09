using System;
using System.IO;

static class Program
{
	public static void Main(string[] args)
	{
		if(args.Length > 2)	
		{
			string name = args[0].ToUpper();
			float price = float.Parse(args[1]);	
			short stock = short.Parse(args[2]);

			BinaryWriter writer = new BinaryWriter(
				new FileStream("product.dat", FileMode.Create));
			writer.Write(name);
			writer.Write(price);
			writer.Write(stock);
			writer.Close();
		}
		else
		{
			BinaryReader reader = new BinaryReader(
				new FileStream("product.dat", FileMode.Open));	
			string name = reader.ReadString();
			float price = reader.ReadSingle();
			short stock = reader.ReadInt16();
			reader.Close();

			Console.WriteLine("{0} {1} {2}", name, price, stock);
		}
	}
}