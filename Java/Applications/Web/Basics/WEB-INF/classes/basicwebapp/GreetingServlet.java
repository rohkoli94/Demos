package basicwebapp;

import java.io.*;
import javax.servlet.*;

public class GreetingServlet implements Servlet{

	private ServletConfig config;

	public void init(ServletConfig cfg) throws ServletException{
		config = cfg;
	}

	public ServletConfig getServletConfig(){
		return config;
	}

	public String getServletInfo(){
		return "Greeting Web Servlet";
	}

	public void service(ServletRequest request, ServletResponse response) throws IOException, ServletException{
		String name = request.getParameter("visitor");
		if(name == null) name = "";
		response.setContentType("text/html");
		PrintWriter output = response.getWriter();
		output.println("<html>");
		output.println("<head><title>BasicWebApp</title></head>");
		output.println("<body>");
		output.printf("<h1>Welcome Visitor %s</h1>%n", name);
		output.printf("<b>Time on server: </b>%s%n", new java.util.Date());
		output.println("</body>");
		output.println("</html>");
	}

	public void destroy(){}
}

