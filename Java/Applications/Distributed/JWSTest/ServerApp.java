import javax.xml.ws.*;

class ServerApp{

	public static void main(String[] args) throws Exception{
		System.setErr(null);
		Endpoint.publish("http://localhost:8059/shopping/customerws", new shopping.CustomerWS());
	}
}

