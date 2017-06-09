package hr;

import java.io.*;
import java.util.*;

public class Employee implements Externalizable{

	private String code;
	private String password;
	private int experience;
	private double salary;

	public final String getCode(){
		return code;
	}

	public final void setCode(String value){
		code = value;
	}
	
	public final String getPassword(){
		return password;
	}

	public final void setPassword(String value){
		password = value;
	}

	public final int getExperience(){
		return experience;
	}

	public final void setExperience(int value){
		experience = value;
	}

	public final double getSalary(){
		return salary;
	}

	public final void setSalary(double value){
		salary = value;
	}

	@Override
	public String toString(){
		return String.format("%s\t%d\t%.2f\t%s", code, experience, salary, 
			password);
	}
	
	public void writeExternal(ObjectOutput output) throws IOException{
		output.writeUTF(code);
		output.writeInt(experience);
		output.writeDouble(salary);
		byte[] data = password.getBytes();
		for(int i = 0; i < data.length; ++i)
			data[i] = (byte)(data[i] ^ '#');
		String epwd = Base64.getEncoder().encodeToString(data);
		output.writeUTF(epwd);
	}

	public void readExternal(ObjectInput input) throws IOException{
		code = input.readUTF();
		experience = input.readInt();
		salary = input.readDouble();
		String epwd = input.readUTF();
		byte[] data = Base64.getDecoder().decode(epwd);
		for(int i = 0; i < data.length; ++i)
			data[i] = (byte)(data[i] ^ '#');
		password = new String(data);
	}
}




















