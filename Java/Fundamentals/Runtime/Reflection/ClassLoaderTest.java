import java.util.*;
import java.lang.reflect.*;
import java.net.*;

class ClassLoaderTest{

	public static void main(String[] args) throws Exception{
		Scanner input = new Scanner(System.in);
		URL[] codebase = {new URL("file:./cmd-classes/")};
		for(;;){
			System.out.print("COMMAND: ");
			String cmd = input.nextLine();
			if(cmd.length() == 0) continue;
			if(cmd.equals("Quit")) break;
			try{
				ClassLoader loader = new URLClassLoader(codebase);
				Class<?> c = Class.forName("commands." + cmd, false, loader);
				Method m = c.getMethod("execute", String.class);
				m.invoke(null, "ClassLoaderTest");
			}catch(Exception e){
				System.out.println(e);
			}
			System.out.println();
		}
	}
}


