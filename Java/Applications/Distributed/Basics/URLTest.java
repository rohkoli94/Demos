import java.io.*;
import java.net.*;

class URLTest{

	public static void main(String[] args) throws Exception{
		String address = String.format("http://localhost/stock.php?symbol=%s", args[0]);
		URL url = new URL(address);
		InputStream response = url.openStream();
		BufferedReader reader = new BufferedReader(
			new InputStreamReader(response));
		System.out.println(reader.readLine());
		reader.close();
	}
}

