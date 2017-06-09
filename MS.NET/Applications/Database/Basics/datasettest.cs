using System;
using System.Data;
using System.Data.SqlClient;

static class Program
{
	public static void Main(string[] args)
	{
		DataSet ds = new DataSet();
		
		if(args.Length == 0)
		{
			SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Shop;Integrated Security=True");
			SqlDataAdapter da = new SqlDataAdapter("SELECT ProductNo, Price, Stock FROM Product", con);
			da.Fill(ds, "Product");
		}
		else
		{
			ds.ReadXml(args[0]);
		}

		foreach(DataRow row in ds.Tables["Product"].Rows)
			Console.WriteLine("{0, -6}{1, 10:0.00}{2, 8}", row["ProductNo"], row["Price"], row["Stock"]);
	}
}