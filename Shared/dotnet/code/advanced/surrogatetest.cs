using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


interface IStringifiable
{
	void FromString(string state);
}


// Surrogate for objects which support IStringifiable interface
class StringifiableSurrogate : ISerializationSurrogate
{
	//Is called by Formatter during serialization
	public void GetObjectData(object source, SerializationInfo info, StreamingContext context)
	{
		//Write serialization data to info
		info.AddValue("__state", source.ToString());
	}

	//Is called by Formatter during deserialization
	public object SetObjectData(object source, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
	{
		IStringifiable obj = (IStringifiable) source;

		//Read serialization data from info
		string state = info.GetString("__state");
	
		//Initialize source object with serialization data
		obj.FromString(state);

		return source;
	}

}

class StringifiableSurrogateSelector : ISurrogateSelector
{
	
	private ISurrogateSelector next = null;

	public void ChainSelector(ISurrogateSelector selector)
	{
		next = selector;
	}

	public ISurrogateSelector GetNextSelector()
	{
		return next;
	}

	public ISerializationSurrogate GetSurrogate(Type t, StreamingContext context, out ISurrogateSelector selector)
	{
		
		//Return StringifiableSurrogate if target Type
		//implements IStringifiable interface
		if(typeof(IStringifiable).IsAssignableFrom(t))
		{
			selector = this;
			return new StringifiableSurrogate();
		}
		
		if(next != null)
			return next.GetSurrogate(t, context, out selector);
		
		selector = null;
		return null;
	}
}

//Demo class
class ContactInfo : IStringifiable
{
	public string Country;
	public string City;
	public string Phone;

	public override string ToString()
	{
		return String.Format("{0}-{1}-{2}", Country, City, Phone);
	}

	public void FromString(string state)
	{
		string[] fields = state.Split('-');

		City = fields[0];
		Country = fields[1];
		Phone = fields[2];
	}	
}

class Test
{
	public static void Main(string[] args)
	{
		ContactInfo obj = null;

		//Create Formatter with StringifiableSurrogate
		BinaryFormatter serializer = new BinaryFormatter(new StringifiableSurrogateSelector(), new StreamingContext());
		//serializer.SurrogateSelector.ChainSelector(new OtherSurrogateSelector());

		if(args.Length > 2)
		{
			obj = new ContactInfo{City=args[0], Country=args[1], Phone=args[2]};
			FileStream fs = new FileStream("surtest.ser", FileMode.Create);
			serializer.Serialize(fs, obj);
			fs.Close();
		}
		else
		{
			FileStream fs = new FileStream("surtest.ser", FileMode.Open);
			obj = (ContactInfo) serializer.Deserialize(fs);
			fs.Close();
		}

		Console.WriteLine(obj);
	}
}


