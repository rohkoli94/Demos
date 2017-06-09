import shopping.*;
import java.util.*;
import java.rmi.*;

class ClientApp{

	public static void main(String[] args) throws Exception{
		CartService service = (CartService)Naming.lookup("rmi://localhost/cartservice");
		Cart client = service.create();
		Scanner input = new Scanner(System.in);
		for(int n = 1;; ++n){
			System.out.printf("Item %d: ", n);
			String i = input.nextLine();
			if(i.length() == 0) break;
			System.out.printf("Adding %s to cart...", i);
			try{
				client.addItem(i);
				System.out.println("Succeeded.");
			}catch(MissingItemException e){
				System.out.println("Failed!");
			}
		}
		System.out.printf("Total payment: %.2f%n", client.checkout());
	}
}

