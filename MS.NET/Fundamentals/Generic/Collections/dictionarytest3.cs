using System;
using System.Collections.Generic;

static class Program
{
	public static void Main()
	{
		IDictionary<string, Interval> store = new SortedDictionary<string, Interval>();
		store.Add("monday", new Interval(6, 41));
		store.Add("tuesday", new Interval(4, 12));
		store.Add("wednesday", new Interval(5, 23));
		store.Add("thursday", new Interval(7, 34));
		store.Add("friday", new Interval(3, 55));
	
		foreach(var entry in store)
			Console.WriteLine("{0, -12}{1, 8}", entry.Key, entry.Value);
		
		Console.Write("Key: ");
		string key = Console.ReadLine();
		Interval value;
		if(store.TryGetValue(key, out value))
		{
			Console.WriteLine("Value = {0}", value);
		}
		else
		{
			Console.WriteLine("No such key!");
		}
	}
}