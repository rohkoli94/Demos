package sales;

import javax.ejb.*;
import javax.faces.bean.*;
import javax.validation.constraints.*;

@ManagedBean(name="productInput")
@ViewScoped
public class ProductInputBean{

	@EJB
	private ProductMakerEJB productMaker;

	@NotNull
	private double price;

	@NotNull
	@Min(5)
	@Max(50)
	private int stock;

	public double getPrice(){return price;}
	public void setPrice(double value){price = value;}

	public int getStock(){return stock;}
	public void setStock(int value){stock = value;}

	public String create(){
		productMaker.addNewProduct(price, stock);
		return "index";
	}
}

