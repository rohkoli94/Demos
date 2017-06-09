using System;
using System.Data;
using System.Data.SqlClient;

static class Program
{
	public static void Main(string[] args)
	{
		string sql = "UPDATE Product SET Stock=Stock+5";
		if(args.Length > 0)
			sql += " WHERE ProductNo=" + int.Parse(args[0]);
		
		SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Shop;Integrated Security=True");
		con.Open();

		SqlCommand cmd = new SqlCommand(sql, con);
		int n = cmd.ExecuteNonQuery();
		Console.WriteLine("Number of products updated = {0}", n);		

		con.Close();
	}
}