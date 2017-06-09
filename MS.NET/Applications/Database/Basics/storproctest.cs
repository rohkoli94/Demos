using System;
using System.Data;
using System.Data.SqlClient;

static class Program
{
	public static void Main(string[] args)
	{		
		string customerId = args[0].ToUpper();
		int productNo = int.Parse(args[1]);
		int quantity = int.Parse(args[2]);

		SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Shop;Integrated Security=True");
		con.Open();
		
		SqlCommand cmd = con.CreateCommand();
		cmd.CommandText = "PlaceOrder";
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.AddWithValue("@Customer", customerId);
		cmd.Parameters.AddWithValue("@Product", productNo);
		cmd.Parameters.AddWithValue("@Quantity", quantity);
		SqlParameter orderNoParam = cmd.Parameters.Add("@OrderNo", SqlDbType.Int);
		orderNoParam.Direction = ParameterDirection.Output;
		try
		{
			cmd.ExecuteNonQuery();
			Console.WriteLine("New Order Number: {0}", orderNoParam.Value);	
		}
		catch(SqlException ex)
		{
			Console.WriteLine("Order Failed: {0}", ex.Message);
		}

		con.Close();
	}
}