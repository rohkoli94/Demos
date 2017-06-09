import shopping.client.*;

class ClientApp{

	public static void main(String[] args) throws Exception{
		String item = args[0].toLowerCase();
		int quantity = Integer.parseInt(args[1]);
		CustomerService service = new CustomerService();
		CustomerSupport client = service.getCustomerSoap();
		if(quantity > client.inquire(item))
			System.out.println("Item not available!");
		else{
			Receipt order = client.purchase(item, quantity);
			System.out.printf("Order number is %d and payment is %.2f%n", order.getStatus(), order.getPayment());
		}
	}
}

