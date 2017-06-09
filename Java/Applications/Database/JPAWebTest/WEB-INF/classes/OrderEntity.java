package sales;

import java.sql.*;
import javax.persistence.*;

@Entity
@Table(name="orders")
public class OrderEntity implements java.io.Serializable{

	@Id
	@Column(name="ord_no")
	public int orderNo;

	@Column(name="ord_date")
	public Date orderDate;

	@Column(name="cust_id")
	public String customerId;

	@Column(name="pno")
	public int productNo;

	@Column(name="qty")
	public int quantity;

	public int getOrderNo(){return orderNo;}

	public Date getOrderDate(){return orderDate;}

	public String getCustomerId(){return customerId;}

	public int getProductNo(){return productNo;}

	public int getQuantity(){return quantity;}
}

