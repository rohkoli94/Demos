import java.util.*;
import java.lang.reflect.*;
import java.net.*;
import java.security.*;

class SandboxTest{

	static class SandboxPolicy extends Policy{
		
		@Override
		public Permissions getPermissions(ProtectionDomain domain){
			Permissions permissions = new Permissions();
			if(domain.getClassLoader() == ClassLoader.getSystemClassLoader())
				permissions.add(new AllPermission());
			return permissions;
		}
	}

	public static void main(String[] args) throws Exception{
		Scanner input = new Scanner(System.in);
		URL[] codebase = {new URL("file:./cmd-classes/")};
		Policy.setPolicy(new SandboxPolicy());
		System.setSecurityManager(new SecurityManager());
		for(;;){
			System.out.print("COMMAND: ");
			String cmd = input.nextLine();
			if(cmd.length() == 0) continue;
			if(cmd.equals("Quit")) break;
			try{
				ClassLoader loader = new URLClassLoader(codebase);
				Class<?> c = Class.forName("commands." + cmd, false, loader);
				Method m = c.getMethod("execute", String.class);
				m.invoke(null, "SandboxTest");
			}catch(Exception e){
				System.out.println(e);
			}
			System.out.println();
		}
	}
}


