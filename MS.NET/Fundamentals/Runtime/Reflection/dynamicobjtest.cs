using System;
using System.Reflection;
using System.Dynamic;

class UsageCounter : DynamicObject
{
	private int count;
	private object target;

	internal UsageCounter(object obj)
	{
		target = obj;	
	}

	public int CountUsage() => count;

	public override bool TryInvokeMember(InvokeMemberBinder binder, object[] arguments, out object result)
	{
		Type t = target.GetType();
		
		try
		{
			result = t.InvokeMember(binder.Name, BindingFlags.InvokeMethod, null, target, arguments);	
			count += 1;
			return true;
		}	
		catch(MissingMethodException)
		{
			result = null;
			return false;
		}
	}
}

static class Program
{
	public static void Main(string[] args)
	{
		Type t = Type.GetType(args[0], true);
		dynamic g = Activator.CreateInstance(t);
		dynamic cg = new UsageCounter(g);

		Console.WriteLine(cg.Meet("Jack")); //duck-typing, compiler creates a DLR call site
		Console.WriteLine(cg.Leave("Jack"));
		//Console.WriteLine(cg.Kill("Jack"));
		Console.WriteLine("Number of usage = {0}", cg.CountUsage());
	}
}