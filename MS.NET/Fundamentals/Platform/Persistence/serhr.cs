using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HR
{
	[Serializable]
	public class Employee
	{
		[NonSerialized]
		private string password;
		
		public Employee(){}

		public string Code {get; set;}

		public int Experience {get; set;}

		public double Salary {get; set;}

		public string Password 
		{
			get {return password;}
			set {password = value;}
		}

		public override string ToString()
		{
			return string.Format("{0}\t{1}\t{2}\t{3}", Code, Password, Experience, Salary);
		}

		[OnDeserialized]
		private void Reset(StreamingContext context)
		{
			password = "lost";		
		}
	}
	
	[Serializable]
	public class Department
	{
		public string Title {get; set;}

		public List<Employee> Employees {get; set;} = new List<Employee>();

		public Employee AddEmployee(int exp, double sal){
			Employee emp = new Employee();
			int i = 501 + Employees.Count;

			emp.Code = Title.Substring(0, 3).ToUpper() + i;
			emp.Password = "PWD" + i;
			emp.Experience = exp;
			emp.Salary = sal;
			Employees.Add(emp);

			return emp;
		}

	}

}
