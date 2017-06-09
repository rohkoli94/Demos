using System;

class Interval
{
	private int min;
	private int sec;

	public Interval(int m, int s)
	{
		min = m + s / 60;
		sec = s % 60;
	}

	public int Time
	{
		get
		{
			return 60 * min + sec;
		}
		set
		{
			min = value / 60;
			sec = value % 60;
		}
	}

	public void Print()
	{
		Console.WriteLine("{0}:{1:00}", min, sec);
	}

	public static Interval operator+(Interval lhs, Interval rhs)
	{
		return new Interval(lhs.min + rhs.min, lhs.sec + rhs.sec);
	}

	public static Interval operator*(int lhs, Interval rhs)
	{
		return new Interval(lhs * rhs.min, lhs * rhs.sec);
	}

	public static Interval operator++(Interval val)
	{
		return new Interval(val.min, val.sec + 1);
	}

	public static bool operator<(Interval lhs, Interval rhs)
	{
		return lhs.Time < rhs.Time;
	}

	public static bool operator>(Interval lhs, Interval rhs)
	{
		return lhs.Time > rhs.Time;
	}

	public static implicit operator Interval(double val)
	{
		int m = (int)val;
		int s = (int)(60 * (val - m));

		return new Interval(m, s);
	}

	public static explicit operator double(Interval val)
	{
		return val.min + val.sec / 60.0;
	}
}

static class Program
{
	public static void Main()
	{
		Interval a = new Interval(4, 30);
		a.Print();
		
		Interval b = new Interval(3, 45);
		b.Print();

		Interval c = a + b; //Interval.op_Addition(a, b)
		c.Print();

		Interval d = 3 * c;
		d.Print();

		Interval e = ++d; //d = Interval.op_Increment(d), e = d
		d.Print();
		e.Print();

		Interval f = e++; //f = e, e = Interval.op_Increment(e)
		e.Print();
		f.Print();

		Interval g = 6.25;
		g.Print();

		double h = (double)g;
		Console.WriteLine(h);
	}
}