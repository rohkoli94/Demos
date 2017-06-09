using System;

class Resource : IDisposable
{
	private string id;

	public string Id => id;

	static Resource()
	{
		#if TESTING
		Console.WriteLine("Resource class initialized.");
		#endif
	}

	internal Resource(string name)
	{
		id = name;

		#if TESTING
		Console.WriteLine("{0} resource acquired.", name);
		#endif
	}

	public void Consume(int action)
	{
		if(id != null)
			Console.WriteLine("{0} resource consumed for action<{1}>", id, action);
	}

	public void Dispose()
	{
		#if TESTING
		Console.WriteLine("{0} resource released(disposed).", id);
		#endif	

		id = null;
		GC.SuppressFinalize(this);
	}

	~Resource()
	{
		#if TESTING
		Console.WriteLine("{0} resource released(finalized).", id);
		#endif
	}
}

static class Program
{
	private static void Run()
	{
		Resource b = new Resource("Second");
		b.Consume(2);
	}

	private static void Run(string action)
	{
		/*
		Resource d = new Resource("Fourth");
		try
		{
			d.Consume(int.Parse(action));
		}
		finally
		{
			d.Dispose();
		}
		*/

		using(Resource d = new Resource("Fourth"))
		{
			d.Consume(int.Parse(action));
		}
		
	}

	public static void Main(string[] args)
	{
		Resource a = new Resource("First");	
		a.Consume(1);

		Run();
		
		Console.WriteLine("Before GC, {0} resource is in generation {1}", a.Id, GC.GetGeneration(a));
		GC.Collect();
		GC.WaitForPendingFinalizers();
		Console.WriteLine("After GC, {0} resource is in generation {1}", a.Id, GC.GetGeneration(a));

		Resource c = new Resource("Third");
		c.Consume(3);
		c.Dispose();

		try
		{
			Run(args[0]);
		}
		catch{}

		Console.WriteLine("Press any key to exit...");
		Console.ReadKey(true);
	}
}