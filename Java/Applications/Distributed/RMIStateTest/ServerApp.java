import java.rmi.*;

class ServerApp{

	public static void main(String[] args) throws Exception{
		Naming.rebind("cartservice", new shopping.CartServiceImpl());
	}
}

