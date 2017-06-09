class ThreadLocalTest{

	static class PrintItem{

		private static String text;

		public static void write(String value){
			text = value;
		}

		public static String read(){
			return text;
		}
	}

	static class Printer{

		public static void print(int copies){
			for(int i = 1; i <= copies; ++i){
				System.out.printf("%d:%s%n", i, PrintItem.read());
				Worker.doWork(i);
			}
		}
	}

	public static void main(String[] args) throws Exception{
		PrintItem.write("monday");
		Printer.print(5);
		PrintItem.write("sunday");
		Printer.print(5);
	}
}











