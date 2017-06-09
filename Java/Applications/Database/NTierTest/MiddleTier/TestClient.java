import sales.client.*;

class TestClient{

	public static void main(String[] args) throws Exception{
		String customerId = args[0].toUpperCase();
		int productNo = Integer.parseInt(args[1]);
		int quantity = Integer.parseInt(args[2]);
		OrderManagerService service = new OrderManagerService();
		OrderManager client = service.getOrderManagerPort();
		try{
			System.out.printf("New Order Number: %d%n", client.placeOrder(customerId, productNo, quantity));
		}catch(Exception e){
			System.out.printf("Order Failed: %s%n", e.getMessage());
		}
	}
}

