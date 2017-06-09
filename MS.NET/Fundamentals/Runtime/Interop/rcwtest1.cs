using QuadEq;
using System;

static class Program
{
	public static void Main()
	{
		Console.Write("Perimeter: ");
		double perim = double.Parse(Console.ReadLine());		
		Console.Write("Area     : ");
		double area = double.Parse(Console.ReadLine());		
		double a = 1, b = -perim / 2, c = area;
		
		//instantiating a COM imported class activates the corresponding
		//COM object and returns its runtime callable wrapper which handles
		//forwarding of managed calls to that COM object 
		QuadraticEquationClass eqn = new QuadraticEquationClass();

		if(eqn.HasRealRoots(a, b, c) != 0)
		{
			double r1, r2;

			eqn.Solve(a, b, c, out r1, out r2);

			Console.WriteLine("Dimensions: {0}, {1}", r1, r2);
		}
		else
			Console.WriteLine("No such rectangle!");

	}
}