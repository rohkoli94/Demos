package app;

import java.util.*;
import javax.faces.bean.*;

@ManagedBean(name="visitorModel")
@RequestScoped
public class VisitorManagedBean{

	private Document<Visitor> doc;

	public VisitorManagedBean(){
		doc = Document.open(Visitor.class, "visitors.xml");
	}

	public Iterable<Visitor> getVisitors(){
		return doc;
	}

	public String putVisitor(String name){
		Visitor visitor = doc.find(v -> v.name.equals(name));
		if(visitor == null)
			doc.add(new Visitor(name));
		else
			visitor.revisit();
		doc.save();
		return "index";
	}
}

