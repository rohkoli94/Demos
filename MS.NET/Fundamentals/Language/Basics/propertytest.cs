using System;

class Interval
{
	private int min;
	private int sec;

	//property - methods which can be invoked using field access syntax
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

	//indexer - default parameterized property
	public int this[int index]
	{
		get
		{
			return index == 0 ? sec : min;
		}	
	}

	public void Print()
	{
		Console.WriteLine("{0}:{1:00}", min, sec);
	}
}

static class Program
{
	private static double GetSpeed(double distance, Interval duration)
	{
		return 3.6 * distance / duration.Time; //duration.get_Time()	
	}

	public static void Main()
	{
		Interval jack = new Interval();
		jack.Time = 125; //jack.set_Time(125)
		Console.Write("Jack's Interval = ");
		jack.Print();
		Console.WriteLine("Jack's Speed = {0}", GetSpeed(500, jack));

		Interval john = new Interval();
		john.Time = 200;
		Console.Write("John's Interval = ");
		john.Print();
		Console.WriteLine("John's Speed = {0}", GetSpeed(500, john));
		Console.WriteLine("John's Interval has {0} minutes and {1} seconds", john[1], john[0]);
	}
}