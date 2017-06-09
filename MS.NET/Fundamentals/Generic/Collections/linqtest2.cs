using System;
using System.Collections.Generic;
using static System.Linq.Enumerable;

static class Program
{
	private static Interval Add(Interval a, Interval b)
	{
		return new Interval(a.Minutes + b.Minutes, a.Seconds + b.Seconds);
	}

	public static void Main(string[] args)
	{
		int l = args.Length > 0 ? int.Parse(args[0]) : 0;
		double distance = 500;
		var store = new List<Interval>
		{
			new Interval(6, 51),
			new Interval(4, 32),
			new Interval(5, 23),
			new Interval(7, 34),
			new Interval(3, 45)
		};
		var selection = from i in store
				where i.Time > l
				orderby i.Seconds
				select new 
				{
					Duration = i,
					Speed = 3.6 * distance / i.Time 
				};

		foreach(var entry in selection)
			Console.WriteLine($"{entry.Duration}\t{entry.Speed:0.00}");

		Interval total = (from i in store where i.Time > l select i).Aggregate(Add);
		Console.WriteLine($"Total time = {total}");
	}
}