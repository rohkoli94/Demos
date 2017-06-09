using System;

namespace Helpers
{
	public static unsafe class StringHelper
	{
		public static int HashOf(string text)
		{
			int hash = 0;
			int count = text.Length;

			fixed(char* buffer = text)
			{
				for(int i = 0; i < count; ++i)
					hash = buffer[i] + (hash << 6) + (hash << 16) - hash;	
			}

			return hash;
		}

		public static string ReverseOf(string text)
		{
			int count = text.Length;
			char[] reversed = new char[count];
			
			fixed(char* obuf = text, rbuf = reversed)
			{
				for(int i = 0; i < count; ++i)
					rbuf[i] = obuf[count - i - 1];
			}

			return new string(reversed);
		}
	}

	public static unsafe class ArrayHelper
	{
		public static double SumOf(double[] values)
		{
			double sum = 0;
			int count = values.Length;

			fixed(double* buffer = values)
			{
				for(int i = 0; i < count; ++i)
					sum += buffer[i];
			}

			return sum;
		}

		public static void SquareAll(double[] values)
		{
			int count = values.Length;

			fixed(double* buffer = values)
			{
				for(int i = 0; i < count; ++i)
					buffer[i] *= buffer[i];
			}

		}
	}
}

static class Test
{
	public static void Main()
	{
		string text = "monday";
		Console.WriteLine("Original string   : {0}", text);
		Console.WriteLine("Hash of string    : {0:x}", Helpers.StringHelper.HashOf(text));
		Console.WriteLine("Reverse of string : {0:x}", Helpers.StringHelper.ReverseOf(text));

		double[] list = {1.2, 2.3, 3.4, 4.5, 5.6, 6.7};
		Console.WriteLine("Sum of values: {0}", Helpers.ArrayHelper.SumOf(list));
		Helpers.ArrayHelper.SquareAll(list);
		Console.WriteLine("Sum of squares: {0}", Helpers.ArrayHelper.SumOf(list));
	}
}



