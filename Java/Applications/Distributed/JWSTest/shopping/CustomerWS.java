package shopping;

import javax.jws.*;

@WebService(name="CustomerSupport", serviceName="CustomerService", portName="CustomerSoap")
public class CustomerWS{
	
	@WebMethod(operationName="Inquire")
	public int getStock(String item){
		int id = Store.find(item);
		return id < 0 ? 0 : Store.stockOf(id);
	}

	@WebMethod(operationName="Purchase")
	public OrderInfo placeOrder(String item, int quantity){
		OrderInfo info = new OrderInfo();
		int id = Store.find(item);
		if(id >= 0 && quantity <= Store.stockOf(id)){
			info.code = 1000000 + (int)(System.currentTimeMillis() % 1000000);
			info.amount = 1.06 * quantity * Store.priceOf(id) * (quantity < 6 ? 1 : 0.95);
		}
		return info;
	}
}

