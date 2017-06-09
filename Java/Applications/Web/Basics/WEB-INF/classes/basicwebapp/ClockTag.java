package basicwebapp;

import java.io.*;
import java.util.*;
import java.text.*;
import javax.servlet.jsp.*;
import javax.servlet.jsp.tagext.*;

public class ClockTag implements SimpleTag{

	private JspContext context;
	private JspFragment body;
	private JspTag parent;

	private SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

	public void setFormat(String value){
		formatter.applyPattern(value);
	}

	public void setJspContext(JspContext value){
		context = value;
	}

	public void setJspBody(JspFragment value){
		body = value;
	}

	public void setParent(JspTag value){
		parent = value;
	}

	public JspTag getParent(){
		return parent;
	}

	public void doTag() throws IOException, JspTagException{
		Date now = new Date();
		JspWriter output = context.getOut();
		output.print(String.format("<span>%s</span>", formatter.format(now)));
	}
}

