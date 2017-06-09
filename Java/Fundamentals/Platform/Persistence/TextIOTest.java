import java.io.*;

class TextIOTest{

	public static void main(String[] args) throws Exception{
		if(args.length > 2){
			String item = args[0].toUpperCase();
			float price = Float.parseFloat(args[1]);
			short stock = Short.parseShort(args[2]);
			PrintWriter writer = new PrintWriter(
				new OutputStreamWriter(
				new FileOutputStream("product.txt")));
			writer.println(stock);
			writer.println(price);
			writer.println(item);
			writer.close();
		}else{
			BufferedReader reader = new BufferedReader(
				new InputStreamReader(
				new FileInputStream("product.txt")));
			short stock = Short.parseShort(reader.readLine());
			float price = Float.parseFloat(reader.readLine());
			String item = reader.readLine();
			reader.close();
			System.out.printf("%s %s %s%n", item, price, stock);
		}
	}
}

