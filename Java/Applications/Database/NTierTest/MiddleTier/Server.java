import java.rmi.registry.*;
import javax.xml.ws.*;
import javax.naming.*;
import oracle.jdbc.pool.*;

class Server{

	public static void main(String[] args) throws Exception{
		OracleConnectionPoolDataSource ds = new OracleConnectionPoolDataSource();
		ds.setURL("jdbc:oracle:thin:@//localhost/xe");
		ds.setUser("scott");
		ds.setPassword("tiger");
		LocateRegistry.createRegistry(2099);
		System.setProperty("java.naming.factory.initial", "com.sun.jndi.rmi.registry.RegistryContextFactory");
		System.setProperty("java.naming.provider.url", "rmi://localhost:2099");
		Context naming = new InitialContext();
		naming.bind("jdbc/SalesDB", ds);
		System.setErr(new java.io.PrintStream("server.log"));
		Endpoint.publish("http://0.0.0.0:8020/sales/ordermanager", new sales.OrderManager());
	}
}

