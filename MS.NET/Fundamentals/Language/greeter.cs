namespace Greeting
{
	public class Greeter
	{
		private bool formal;

		public Greeter(bool f)
		{
			formal = f;
		}

		public string Greet(string name)
		{
			if(formal)
				return "Hello " + name;

			return "Hi " + name;
		}
	}
}