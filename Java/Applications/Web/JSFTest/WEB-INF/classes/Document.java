package app;

import java.io.*;
import java.util.*;
import javax.xml.bind.*;
import javax.xml.bind.annotation.*;

@XmlRootElement(name="document")
public class Document<T> extends ArrayList<T>{

	private transient String file;
	private transient Class<T> type;

	@SuppressWarnings("unchecked")
	public static<T> Document<T> open(Class<T> type, String file){
		file = System.getProperty("user.home") + "/Documents/" + file;
		try{
			File f = new File(file);
			Document<T> list;
			if(f.exists()){
				if(Serializable.class.isAssignableFrom(type)){
					try(ObjectInputStream source = new ObjectInputStream(new FileInputStream(file))){
						list = (Document<T>)source.readObject();
					}
				}else{
					JAXBContext serializer = JAXBContext.newInstance(Document.class, type);
					Unmarshaller um = serializer.createUnmarshaller();
					try(FileReader source = new FileReader(file)){
						list = (Document<T>)um.unmarshal(source);	
					}
				}
			}else{
				list = new Document<T>();
			}
			list.file = file;
			list.type = type;
			return list;
		}catch(Exception e){
			throw new RuntimeException(e);
		}
	}

	public T find(java.util.function.Predicate<T> check){
		for(T entry : this)
			if(check.test(entry)) return entry;
		return null;
	}

	public void save(){
		try{
			if(Serializable.class.isAssignableFrom(type)){
				try(ObjectOutputStream target = new ObjectOutputStream(new FileOutputStream(file))){
					target.writeObject(this);
				}
			}else{
				JAXBContext serializer = JAXBContext.newInstance(Document.class, type);
				Marshaller m = serializer.createMarshaller();
				m.setProperty("jaxb.formatted.output", true);
				try(FileWriter target = new FileWriter(file)){
					m.marshal(this, target);
				}
			}
		}catch(Exception e){
			throw new RuntimeException(e);
		}
		
	}

	@XmlElementWrapper(name="items")
	@XmlElement(name="item")
	public final List<T> getItems(){
		return this;
	}
}

