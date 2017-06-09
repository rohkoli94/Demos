import shopping.*;
import java.util.*;
import java.rmi.*;

class ClientApp{

	public static void main(String[] args) throws Exception{
		ShopKeeper client = (ShopKeeper)Naming.lookup("rmi://localhost/shopkeeper");
		Scanner input = new Scanner(System.in);
		System.out.print("Item: ");
		String i = input.next();
		ItemInfo info = client.getItemInfo(i);
		if(info == null)
			System.out.println("Item not sold!");
		else{
			double p = info.getUnitPrice();
			System.out.print("Quantity: ");
			int q = input.nextInt();
			if(q > info.getCurrentStock())
				System.out.println("Item not in stock!");
			else{
				float r = client.getBulkDiscount(q);
				System.out.printf("Total payment: %.2f%n", p * q * (1 - r / 100));
			}
		}
	}
}

