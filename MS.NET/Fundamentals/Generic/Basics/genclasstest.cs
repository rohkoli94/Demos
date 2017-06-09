using System;

class SimpleStack<V>
{
	class Node
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
}

static class Program
{
	public static void Main()
	{
		SimpleStack<string> a = new SimpleStack<string>();
		a.Push("Monday");
		a.Push("Tuesday");
		a.Push("Wednesday");
		a.Push("Thursday");
		a.Push("Friday");

		SimpleStack<string> b = new SimpleStack<string>();
		b.Push("June");
		b.Push("May");
		b.Push("April");
		b.Push("March");

		var c = new SimpleStack<Interval>();
		c.Push(new Interval(6, 51));
		c.Push(new Interval(7, 12));
		c.Push(new Interval(4, 23));
		c.Push(new Interval(5, 34));
		c.Push(new Interval(3, 45));

		var d = new SimpleStack<object>();
		d.Push("Saturday");
		d.Push(new Interval(2, 30));
		d.Push(12.3);

		while(!a.Empty())
			Console.WriteLine(a.Pop());
		Console.WriteLine("-----------------------------");
		while(!b.Empty())
			Console.WriteLine(b.Pop());
		Console.WriteLine("-----------------------------");
		while(!c.Empty())
			Console.WriteLine(c.Pop());
		Console.WriteLine("-----------------------------");
		while(!d.Empty())
			Console.WriteLine(d.Pop());
	}
}