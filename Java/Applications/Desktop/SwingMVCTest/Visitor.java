package app;

import java.util.*;

public class Visitor{

	String name;
	int frequency;
	Date recent;

	Visitor(String id){
		name = id;
		frequency = 1;
		recent = new Date();
	}

	public Visitor(){
		this(null);
	}

	public String getName(){return name;}
	public void setName(String value){name = value;} 

	public int getFrequency(){return frequency;}
	public void setFrequency(int value){frequency = value;} 

	public Date getRecent(){return recent;}
	public void setRecent(Date value){recent = value;} 

	public void revisit(){
		frequency += 1;
		recent = new Date();
	}
}

