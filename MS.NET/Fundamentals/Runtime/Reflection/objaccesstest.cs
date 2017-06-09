using Payroll;
using System;
using System.Reflection;

static class Program
{
	/*
	private static void PrintAsXml(Employee obj)
	{
		Console.WriteLine("<Employee>");
		Console.WriteLine("  <Hours>{0}</Hours>", obj.Hours);
		Console.WriteLine("  <Rate>{0}</Rate>", obj.Rate);
		Console.WriteLine("  <Id>{0}</Id>", obj.Id);
		Console.WriteLine("</Employee>");
		Console.WriteLine();
	}

	private static void PrintAsXml(Interval obj)
	{
		Console.WriteLine("<Interval>");
		Console.WriteLine("  <Minutes>{0}</Minutes>", obj.Minutes);
		Console.WriteLine("  <Seconds>{0}</Seconds>", obj.Seconds);
		Console.WriteLine("  <Time>{0}</Time>", obj.Time);
		Console.WriteLine("</Interval>");
		Console.WriteLine();
	}
	*/

	private static void PrintAsXml(object obj)
	{
		Type t = obj.GetType();
		
		Console.WriteLine("<{0}>", t.Name);
		foreach(PropertyInfo pi in t.GetProperties())
		{
			Console.WriteLine("  <{0}>{1}</{0}>", pi.Name, pi.GetValue(obj, null));
		}
		Console.WriteLine("</{0}>", t.Name);
		Console.WriteLine();
	}

	public static void Main()
	{
		PrintAsXml(new Employee(186, 52));
		PrintAsXml(new Interval(3, 45));
	}
}