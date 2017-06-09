import java.net.*;

class MulticastSocketTest{

	public static void main(String[] args) throws Exception{
		InetAddress addr = InetAddress.getByName("230.1.2.3");
		MulticastSocket subscriber = new MulticastSocket(2056);
		subscriber.joinGroup(addr);
		for(int i = 0; i < 5; ++i){
			DatagramPacket packet = new DatagramPacket(new byte[80], 80);
			subscriber.receive(packet);
			String text = new String(packet.getData(), 0, packet.getLength());
			System.out.println(text);
		}
		subscriber.leaveGroup(addr);
		subscriber.close();
	}
}

