class GCTest{

	static class Resource implements AutoCloseable{

		private String id;

		static{
			System.out.println("Resource class initialized");
		}

		Resource(String name){
			id = name;
			System.out.printf("%s-resource acquired%n", id);
		}

		public String getId(){return id;}

		public void consume(){
			System.out.printf("%s-resource consumed%n", id);
		}

		public void close(){
			if(id != null){
				System.out.printf("%s-resource released%n", id);
				id = null;
			}
		}

		public void finalize(){
			close();
		}
	}

	private static void run(){
		Resource b = new Resource("Second");
		b.consume();
	}

	public static void main(String[] args){
		Resource a = new Resource("First");
		a.consume();
		run();
		a = null;
		System.gc(); //request garbage collection
		Resource c = new Resource("Third");
		c.consume();
		c.close();
		try(Resource d = new Resource("Fourth")){
			d.consume();
		}
	}
}

