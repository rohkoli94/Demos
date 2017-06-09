import java.io.*;

class DataIOTest{

	public static void main(String[] args) throws Exception{
		if(args.length > 2){
			String item = args[0].toUpperCase();
			float price = Float.parseFloat(args[1]);
			short stock = Short.parseShort(args[2]);
			DataOutputStream writer = new DataOutputStream(
				new FileOutputStream("product.dat"));
			writer.writeShort(stock);
			writer.writeFloat(price);
			writer.writeUTF(item);
			writer.close();
		}else{
			DataInputStream reader = new DataInputStream(
				new FileInputStream("product.dat"));
			short stock = reader.readShort();
			float price = reader.readFloat();
			String item = reader.readUTF();
			reader.close();
			System.out.printf("%s %s %s%n", item, price, stock);
		}
	}
}

