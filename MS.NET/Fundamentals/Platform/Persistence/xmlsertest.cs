using HR;
using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Xml.Serialization;

static class Program
{
	public static void Main(string[] args)
	{
		XmlSerializer serializer = new XmlSerializer(typeof(Department));
		
		if(args.Length > 0)
		{
			Department dept = new Department();
			dept.Title = args[0];
			dept.AddEmployee(3, 34000);
			dept.AddEmployee(5, 56000);
			dept.AddEmployee(2, 23000);
			dept.AddEmployee(4, 45000);
			dept.AddEmployee(6, 67000);

			using(var target = new FileStream("dept.xml", FileMode.Create))
				serializer.Serialize(target, dept);
		}
		else
		{
			Department dept;
			using(var mapping = MemoryMappedFile.CreateFromFile("dept.xml"))
			{
				using(var source = mapping.CreateViewStream())
					dept = (Department)serializer.Deserialize(source);
			}	

			Console.WriteLine("Employees of {0} department", dept.Title);
			foreach(Employee emp in dept.Employees)
				Console.WriteLine(emp);
		}
	}
}