using System;

partial class Interval : IComparable<Interval>
{
	private int min;
	private int sec;

	partial void OnCreate();

	public Interval(int m, int s)
	{
		min = m + s / 60;
		sec = s % 60;
		OnCreate();
	}

	public int Minutes => min;

	public int Seconds => sec;

	public int Time
	{
		get
		{
			return 60 * min + sec;
		}
	}

	public override string ToString()
	{
		return $"{min}:{sec:00}"; //string.Format("{0}:{1:00}", min, sec)
	}

	public override int GetHashCode()
	{
		return 1000 * Time;
	}

	public override bool Equals(object other)
	{
		if(other is Interval)
		{
			Interval that = (Interval)other;
			return (this.min == that.min) && (this.sec == that.sec);
		}
		
		return false;
	}

	public int CompareTo(Interval that)
	{
		return this.Time - that.Time;
	}
}

