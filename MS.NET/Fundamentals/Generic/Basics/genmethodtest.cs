using System;

static class Program
{
	private static T Select<T>(int selector, T first, T second)
	{
		if(selector < 0)
			return first;
		return second;
	}

	public static void Main(string[] args)
	{
		int s = args.Length > 0 ? int.Parse(args[0]) : 0;

		string ss = Select(s, "Monday", "Tuesday");
		Console.WriteLine("Selected string = {0}", ss);

		double sd = Select(s, 7.25, 2.75);
		Console.WriteLine("Selected double = {0}", sd);

		int si = Select(s, 123456, 0xabcdef);
		Console.WriteLine("Selected int = {0}", si);
	}
}