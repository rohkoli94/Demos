package commands;

public class Greet{
	
	public static void execute(String arg){
		try{
			System.out.printf("Hello %s!%n", System.getProperty("user.name"));
		}catch(Exception e){
			System.out.println("Hello User!");
		}
	}
}

