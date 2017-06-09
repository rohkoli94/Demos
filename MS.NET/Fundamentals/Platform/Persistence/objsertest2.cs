using HR;
using System;

[Serializable]
class Office
{
	public Employee Manager { get; set; }

	public void Show()
	{	
		Console.WriteLine("Manager's credentials in app-domain<{0}> is {1}/{2}", AppDomain.CurrentDomain.Id, Manager.Code, Manager.Password);
	}		
}

static class Program
{
	public static void Main()
	{
		Office office = new Office();
		office.Manager = new Employee{Code="ACC501", Password="a1b2c3"};
		office.Show();			
		
		AppDomain dom = AppDomain.CreateDomain("Office");
		dom.DoCallBack(office.Show);
		AppDomain.Unload(dom);
	}
}