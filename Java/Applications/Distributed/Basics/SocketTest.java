import java.util.*;
import java.io.*;
import java.net.*;

class SocketTest{

	public static void main(String[] args) throws Exception{
		String host = args.length > 0 ? args[0] : "localhost";
		Socket client = new Socket(host, 2055);
		Scanner input = new Scanner(System.in);
		BufferedReader reader = new BufferedReader(
			new InputStreamReader(client.getInputStream()));
		PrintWriter writer = new PrintWriter(
			new OutputStreamWriter(client.getOutputStream()));
		System.out.println(reader.readLine());
		System.out.print("REQUEST : ");
		String symbol = input.next();
		writer.println(symbol);
		writer.flush();
		System.out.printf("RESPONSE: %s%n", reader.readLine());
		writer.close();
		reader.close();
		client.close();
	}
}

