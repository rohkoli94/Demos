using System;

interface IStackReader<out V>
{
	V Pop();
	bool Empty();
}

interface IStackWriter<in V>
{
	void Push(V value);
}

class SimpleStack<V> : IStackReader<V>, IStackWriter<V>
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

	public void Copy(IStackWriter<V> target)
	{
		for(Node n = top; n != null; n = n.Below)
			target.Push(n.Value);
	}
}

class FiniteStack<V> : IStackReader<V>, IStackWriter<V>
{
	private V[] values;
	private int count;

	public FiniteStack(int size)
	{
		values = new V[size];
	}

	public void Push(V value)
	{
		values[count++] = value;
	}

	public V Pop()
	{
		return values[--count];
	}

	public bool Empty()
	{
		return count == 0;
	}
}

static class Program
{
	private static void PrintStack(IStackReader<object> stack)
	{
		for(int i = 0; !stack.Empty(); ++i)
		{
			if(i > 0) Console.Write(", ");
			Console.Write(stack.Pop());
		}

		Console.WriteLine();
	}

	public static void Main()
	{
		SimpleStack<string> a = new SimpleStack<string>();
		a.Push("Monday");
		a.Push("Tuesday");
		a.Push("Wednesday");
		a.Push("Thursday");
		a.Push("Friday");

		FiniteStack<string> b = new FiniteStack<string>(16);
		b.Push("June");
		b.Push("May");
		b.Push("April");
		b.Push("March");
		a.Copy(b);

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
		c.Copy(d);
		
		PrintStack(a);
		PrintStack(b);
		PrintStack(c);
		PrintStack(d);
	}
}