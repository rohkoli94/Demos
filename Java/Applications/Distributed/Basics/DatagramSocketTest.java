import java.util.*;
import java.net.*;

class DatagramSocketTest{

	public static void main(String[] args) throws Exception{
		String[] symbols = {"APPL", "GOGL", "INTC", "MSFT", "ORCL"};
		Random rdm = new Random();
		InetAddress addr = InetAddress.getByName("230.1.2.3");
		DatagramSocket publisher = new DatagramSocket();
		for(;;){
			int i = rdm.nextInt(symbols.length);
			String text = String.format("%s - %.2f", symbols[i], 0.01 * (1000 + rdm.nextInt(9000)));
			byte[] data = text.getBytes();
			DatagramPacket packet = new DatagramPacket(data, data.length, addr, 2056);
			publisher.send(packet);
			Thread.sleep(10000);
		}
	}
}


