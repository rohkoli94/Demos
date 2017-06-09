package sales.client;

import javax.ws.rs.*;
import javax.ws.rs.core.*;

@Path("/om")
public class OrderManagerRS{

	public static class OrderInput{
	
		public String customerId;

		public int productNo;

		public int quantity;
	}
	
	@POST
	@Consumes(MediaType.APPLICATION_JSON)
	public Response submit(OrderInput input){
		OrderManagerService service = new OrderManagerService();
		OrderManager client = service.getOrderManagerPort();
		try{
			int orderNo = client.placeOrder(input.customerId, input.productNo, input.quantity);
			return Response.ok(orderNo).build();
		}catch(Exception e){
			return Response.serverError().entity("Invalid order inputs").build();
		}
	}
}

