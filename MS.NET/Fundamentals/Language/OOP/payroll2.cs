namespace Payroll
{
	public class Employee
	{
		internal int hours;
		protected float rate;
		private int id;
		static int count;

		public Employee(int h, float r)
		{
			hours = h;
			rate = r;
			id = 101 + count++;
		}

		public Employee() : this(0, 50)
		{
		}

		public int Hours
		{
			get { return hours; }
			set { hours = value; }
		}

		public float Rate
		{
			get { return rate; }
			set { rate = value; }
		}

		//expression bodied get property
		public int Id => id;
		
		//overridable method
		public virtual double GetNetIncome()
		{
			double income = rate * hours;
			int ot = hours - 180;

			if(ot > 0)
				income += 50 * ot;

			return income;
		}

		public static int CountInstances()
		{
			return count;
		}
	}

	public class SalesPerson : Employee
	{
		public double Sales {get; set;}

		public SalesPerson(int h, float r, double s) : base(h, r)
		{
			Sales = s;
		}

		//overriding GetNetIncome of base class
		public override double GetNetIncome()
		{
			double income = base.GetNetIncome();

			if(Sales >= 20000)
				income += 0.05 * Sales;

			return income;
		}
	}
}