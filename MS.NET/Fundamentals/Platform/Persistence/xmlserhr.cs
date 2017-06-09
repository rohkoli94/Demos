using System;
using System.Text;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace HR
{
	public class Employee
	{

		public Employee(){}

		[XmlAttribute]
		public string Code {get; set;}

		public int Experience {get; set;}

		public double Salary {get; set;}

		[XmlIgnore]
		public string Password {get; set;}

		public override string ToString()
		{
			return string.Format("{0}\t{1}\t{2}\t{3}", Code, Password, Experience, Salary);
		}

		public byte[] Data
		{
			get
			{
				byte[] value = Encoding.UTF8.GetBytes(Password);	
				for(int i = 0; i < value.Length; ++i)
					value[i] = (byte)(value[i] ^ '#');
				return value;
			}
			set
			{
				for(int i = 0; i < value.Length; ++i)
					value[i] = (byte)(value[i] ^ '#');
				Password = Encoding.UTF8.GetString(value);	
			}
		}
	}

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
