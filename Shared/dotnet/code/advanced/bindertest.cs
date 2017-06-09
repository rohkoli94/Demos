using System;
using System.Reflection;
using System.Globalization;

class SimpleBinder : Binder
{

	//Is called by Type.InvokeMember for BindingFlags.InvokeMethod.
	//All methods which have matching number of arguments are passed in match array.
	//BindingToMethod must return the best possible match.
    	public override MethodBase BindToMethod(BindingFlags bindingAttr, MethodBase[] match, 
			ref object[] args, ParameterModifier[] modifiers, CultureInfo culture,
            		string[] names, out object state)
	{
		state = null;    //No reordering of arguments is required
		return match[0]; //Choose first method
    	}

	//Is called by Type.InvokeMember if parameter-type of method being invoked
	//does not match with the type of passed argument
    	public override object ChangeType(object value, Type type, CultureInfo culture)
	{
        	return Convert.ChangeType(value, type);
    	}

	//Is called by Type.InvokeMember for BindingFlags.GetField or BindingFlags.SetField.
	public override FieldInfo BindToField(BindingFlags bindingAttr, FieldInfo[] match, 
			object value, CultureInfo culture)
	{
        	return match[0]; //Choose first field
	}

	//Is called by Type.InvokeMember if BindingToMethod sets state to a non-null reference
	public override void ReorderArgumentArray(ref object[] args, object state){}

	//Is called by Type.GetMethod
    	public override MethodBase SelectMethod(BindingFlags bindingAttr, MethodBase[] match, 
			Type[] types, ParameterModifier[] modifiers) 
	{
        	return match[0]; //Choose first method
    	}

	//Is called by Type.GetProperty
   	public override PropertyInfo SelectProperty(BindingFlags bindingAttr,PropertyInfo[] match, 
			Type returnType, Type[] indexes, ParameterModifier[] modifiers)
	{
        	return match[0]; //Choose first property
    	}

}

class Test{

	public static double Power(double value, int index)
	{
		return (index == 0) ? 1 : value * Power(value, index - 1);
    	}

	public static void Main(string[] args)
	{
		Type t = Type.GetType(args[0]);
		string meth = args[1];
		object[] arguments = new object[args.Length - 2];
		Array.Copy(args, 2, arguments, 0, arguments.Length);
		
		double result = (double) t.InvokeMember(meth, BindingFlags.InvokeMethod, 
				new SimpleBinder(), null, arguments);
		Console.WriteLine(result);
		
    	}
}

//Run: bindertest.exe Test Power 2 10
