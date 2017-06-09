using System;
using System.Collections.Generic;

static class Program
{
	public static void Main()
	{
		IList<Interval> store = new List<Interval>();
		store.Add(new Interval(6, 41));
		store.Add(new Interval(4, 12));
		store.Add(new Interval(5, 23));
		store.Add(new Interval(7, 34));
		store.Add(new Interval(3, 55));
		store.Add(new Interval(2, 132));
	
		foreach(Interval i in store)
			Console.WriteLine(i);

		Console.WriteLine("Third Interval = {0}", store[2]);
	}
}