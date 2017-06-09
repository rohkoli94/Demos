using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HR
{
	[Serializable]
	public class Employee : ISerializable
	{

		public Employee(){}

		public string Code {get; set;}

		public int Experience {get; set;}

		public double Salary {get; set;}

		public string Password {get; set;}

		public override string ToString()
		{
			return string.Format("{0}\t{1}\t{2}\t{3}", Code, Password, Experience, Salary);
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_code", Code);
			info.AddValue("_experience", Experience);
			info.AddValue("_salary", Salary);

			if(context.State == StreamingContextStates.CrossAppDomain)
				info.AddValue("_password", Password.ToUpper());
			else
			{
				byte[] data = Encoding.UTF8.GetBytes(Password);
				for(int i = 0; i < data.Length; ++i)	
					data[i] = (byte)(data[i] ^ '#');
				string epwd = Convert.ToBase64String(data);
				info.AddValue("_data", epwd);
			}
		}

		private Employee(SerializationInfo info, StreamingContext context)
		{
			Code = info.GetString("_code");
			Experience = info.GetInt32("_experience");
			Salary = info.GetDouble("_salary");
				
			if(context.State == StreamingContextStates.CrossAppDomain)
				Password = info.GetString("_password");
			else
			{
				string epwd = info.GetString("_data");	
				byte[] data = Convert.FromBase64String(epwd);
				for(int i = 0; i < data.Length; ++i)	
					data[i] = (byte)(data[i] ^ '#');
				Password = Encoding.UTF8.GetString(data);
			}
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
