using System;

static class PrintItem
{
	private static string text;

	public static void Write(string value)
	{
		text = value;
	}

	public static string Read()
	{
		return text;
	}
}

static class Printer
{
	public static void Print(int copies)
	{
		for(int i = 1; i <= copies; ++i)
		{
			Console.WriteLine("{0}:{1}", i, PrintItem.Read());
			Worker.DoWork(i);
		}
	}
}

static class Program
{
	public static void Main()
	{
		PrintItem.Write("Monday");
		Printer.Print(5);

		PrintItem.Write("Tuesday");
		Printer.Print(5);
	}
}