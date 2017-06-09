using System;

class Customer
{
	//auto property
	public string Name {get; set;}
	
	//auto property with initializer
	public double Credit {get; set;} = 5000;
}

static class Program
{
	public static void Main()
	{
		//object initializer
		Customer a = new Customer{Name="Jack", Credit=3000};
		Console.WriteLine($"{a.Name}'s credit is {a.Credit}");

		//implictly typed local (var = Customer)
		var b = new Customer{Name="Jill"};
		Console.WriteLine($"{b.Name}'s credit is {b.Credit}");

		//anonymous type
		var c = new{Id=23, Score=65};
		Console.WriteLine($"Student with ID {c.Id} has scored {c.Score}");

		//reusing anonymous type
		var d = new{Id=c.Id + 9, Score=c.Score - 9};
		Console.WriteLine($"Student with ID {d.Id} has scored {d.Score}");
	}
}