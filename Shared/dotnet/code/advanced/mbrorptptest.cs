using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;

class EnglishGreeter : MarshalByRefObject
{
	//A virtual member of any class is invoked through an indirection
	public virtual string Meet(string name, int age)
	{
		if(age < 20)
			return "Hi " + name;

		return "Hello " + name;
	}

	//A non-virtual instance member of a MarshalByRefObject derived class
	//is also invoked through an indirection in order to enable proxying
	public string Leave(string name)
	{
		return "Bye " + name;
	}
}


class EchoProxy : System.Runtime.Remoting.Proxies.RealProxy
{
	private MarshalByRefObject target;

	//The base class constructor creates transparent proxy which exposes 
        //instance members of specified MarshalByRefObject derived class
	private EchoProxy(MarshalByRefObject mbro) : base(mbro.GetType())
	{
		target = mbro;
	}

	//This method is called by transparent proxy with msg containing information of its
        //invoked member and it expects a return message containing the result of invocation
	public override IMessage Invoke(IMessage msg)
	{
		//Convert msg to IMethodCallMessage for accessing information in msg as properties
		IMethodCallMessage call = (IMethodCallMessage)msg; 

		Console.WriteLine(">> Invoking {0} method of {1} class", call.MethodName, target.GetType().Name);
		
		//Will invoke the member specified in msg on the target object and give back
		//a ReturnMessage containing the result of invocation
		return RemotingServices.ExecuteMessage(target, call);
	}

	public static M CreateFor<M>(M original) where M : MarshalByRefObject
	{
		//create real proxy from the target MarshalByRefObject
		EchoProxy rp = new EchoProxy(original);

		//obtain the transparent-proxy from its parent real-proxy 
		return (M)rp.GetTransparentProxy(); 
	}

}

static class Program
{
	public static void Main()
	{
		EnglishGreeter g = new EnglishGreeter();
		EnglishGreeter gp = EchoProxy.CreateFor(g);

		Console.WriteLine(gp.Meet("Jack", 19));
		Console.WriteLine(gp.Leave("Jack"));
	}
}