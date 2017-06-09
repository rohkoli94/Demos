using System;
using System.Collections;
using System.Collections.Generic;

public class SimpleStack<V> : IEnumerable<V>
{
	internal class Node
	{
		internal V Value;
		internal Node Below;

		internal Node(V value, Node below)
		{
			Value = value;
			Below = below;
		}
	}

	private Node top;

	public void Push(V value)	
	{
		top = new Node(value, top);
	}

	public V Pop()
	{
		V value = top.Value;
		top = top.Below;

		return value;
	}

	public bool Empty()
	{
		return top == null;
	}

	public IEnumerator<V> GetEnumerator()
	{
		for(Node n = top; n != null; n = n.Below)
			yield return n.Value;
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

static class Program
{
	//delegate bool Filter<V>(V value);

	//private static void Print<V>(IEnumerable<V> source, string caption, Filter<V> check)
	private static void Print<V>(this IEnumerable<V> source, string caption, Func<V, bool> check)
	{
		Console.Write("{0}:", caption);

		foreach(V value in source)
		{
			if(check(value))
				Console.Write(" {0}", value);
		}

		Console.WriteLine();
	}

	public static void Main()
	{
		int[] array = {1, 4, 9, 16, 25, 36};
		array.Print("All integers in array", n => true);
		array.Print("Odd integers in array", n => (n % 2) == 1);

		SimpleStack<Interval> stack = new SimpleStack<Interval>();
		stack.Push(new Interval(6, 51));
		stack.Push(new Interval(7, 12));
		stack.Push(new Interval(4, 23));
		stack.Push(new Interval(5, 34));
		stack.Push(new Interval(3, 45));
		stack.Print("All Intervals on stack", i => true);
		stack.Print("Big Intervals on stack", i => i.Time > 300);
	}
}