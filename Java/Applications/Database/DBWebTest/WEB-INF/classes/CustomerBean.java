package saleswebapp;

import java.util.*;
import java.sql.*;
import javax.sql.*;
import javax.naming.*;

public class CustomerBean implements java.io.Serializable{

	private String id;

	public final String getId(){return id;}

	public boolean authenticate(String user, String password) throws Exception{
		Context naming = new InitialContext();
		DataSource ds = (DataSource)naming.lookup("jdbc/SalesDB");
		try(Connection con = ds.getConnection()){
			PreparedStatement pstmt = con.prepareStatement("select count(cust_id) from customers where cust_id=? and pwd=?");
			pstmt.setString(1, user);
			pstmt.setString(2, password);
			ResultSet rs = pstmt.executeQuery();
			rs.next();
			int count = rs.getInt(1);
			rs.close();
			pstmt.close();
			if(count == 1){
				id = user;
				return true;
			}
			id = null;
			return false;
		}
	}

	public int placeOrder(int productNo, int quantity) throws Exception{
		Context naming = new InitialContext();
		DataSource ds = (DataSource)naming.lookup("jdbc/SalesDB");
		try(Connection con = ds.getConnection()){
			CallableStatement cstmt = con.prepareCall("{call place_order(?, ?, ?, ?)}");
			cstmt.setString(1, id);
			cstmt.setInt(2, productNo);
			cstmt.setInt(3, quantity);
			cstmt.registerOutParameter(4, Types.INTEGER);
			cstmt.execute();
			int orderNo = cstmt.getInt(4);
			cstmt.close();
			return orderNo;
		}
	}

	public List<InvoiceEntry> getInvoice() throws Exception{
		List<InvoiceEntry> entries = new ArrayList<>();
		Context naming = new InitialContext();
		DataSource ds = (DataSource)naming.lookup("jdbc/SalesDB");
		try(Connection con = ds.getConnection()){
			PreparedStatement pstmt = con.prepareStatement("select ord_date, pno, qty, amt from invoices where cust_id=?");
			pstmt.setString(1, id);
			ResultSet rs = pstmt.executeQuery();
			while(rs.next())
				entries.add(new InvoiceEntry(rs));
			rs.close();
			pstmt.close();
		}	
		return entries;
	}

	public static class InvoiceEntry{
		
		private java.sql.Date orderDate;
		private int productNo;
		private int quantity;
		private double amount;

		InvoiceEntry(ResultSet rs) throws SQLException{
			orderDate = rs.getDate("ord_date");
			productNo = rs.getInt("pno");
			quantity = rs.getInt("qty");
			amount = rs.getDouble("amt");
		}

		public final java.sql.Date getOrderDate(){return orderDate;}
		
		public final int getProductNo(){return productNo;}
		
		public final int getQuantity(){return quantity;}
		
		public final double getAmount(){return amount;}
	}
}

