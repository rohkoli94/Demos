package shopping;

public class MissingItemException extends Exception{

	private String itemName;

	public MissingItemException(String name){
		super(name);
		itemName = name;
	}

	public final String getItemName(){return itemName;}
}

