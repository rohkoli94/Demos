import java.util.*;
import javax.naming.*;

public class SimpleContextFactory implements javax.naming.spi.InitialContextFactory{

	public Context getInitialContext(Hashtable env) throws NamingException{
		return new SimpleContext();
	}

	static class SimpleContext extends InitialContext{

		private static Map<String, Object> bindings = new HashMap<String, Object>();

		public SimpleContext() throws NamingException{
			super(true);
		}

		@Override
		public void bind(String name, Object obj){
			bindings.put(name, obj);
		}

		@Override
		public Object lookup(String name){
			return bindings.get(name);
		}
	}
}

