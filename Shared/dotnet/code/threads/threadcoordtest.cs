using System;

static class Program
{
	private static int value = 0;
	
	private static void Consume()
	{
		Console.WriteLine("Consumer ready...");

		Console.WriteLine("Processed value = {0}", value * value);
	}

	private static void Produce()
	{
		Console.WriteLine("Producer ready...");

		int result = Worker.DoWork();

		value = result;

	}

	public static void Main()
	{
		Produce();
	
		Consume();
	}
}	