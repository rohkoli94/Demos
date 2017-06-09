using System;

public class SimpleStack<V>
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

	public class Enumerator
	{
		private Node current;

		internal Enumerator(Node start)
		{
			current = start;
		}

		public bool MoveNext()
		{
			return current != null;
		}

		public V Current
		{
			get
			{
				V value = current.Value;
				current = current.Below;
				return value;
			}
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

	public Enumerator GetEnumerator()
	{
		return new Enumerator(top);
	}
}

static class Program
{
	public static void Main()
	{
		int[] array = {1, 4, 9, 16, 25, 36};
		Console.WriteLine("All integers in array");
		foreach(int i in array)
			Console.WriteLine(i);
		
		SimpleStack<Interval> stack = new SimpleStack<Interval>();
		stack.Push(new Interval(6, 51));
		stack.Push(new Interval(7, 12));
		stack.Push(new Interval(4, 23));
		stack.Push(new Interval(5, 34));
		stack.Push(new Interval(3, 45));
		Console.WriteLine("All Intervals on stack");
		foreach(Interval i in stack)
			Console.WriteLine(i);
	}
}