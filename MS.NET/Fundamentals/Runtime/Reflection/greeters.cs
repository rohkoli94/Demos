namespace Greeters
{
	public class CasualGreeter
	{
		public string Meet(string name)
		{
			return "Hi " + name;
		}

		public string Leave(string name)
		{
			return "Bye " + name;
		}

	}	

	public class FormalGreeter
	{
		public string Meet(string name)
		{
			return "Hello " + name;
		}


		public string Leave(string name)
		{
			return "Goodbye " + name;
		}
	}	

	public class HouseGreeter
	{
		public string Meet(string name)
		{
			return "Welcome " + name;
		}

		public string Leave(string name)
		{
			return "Farewell " + name;
		}

	}	

}