package saleswebapp;

import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.annotation.*;

@WebFilter("/protected/*")
public class AuthorizationFilter implements Filter{

	public void init(FilterConfig cfg) throws ServletException{}

	public void doFilter(ServletRequest req, ServletResponse res, FilterChain next) throws IOException, ServletException{
		HttpServletRequest request = (HttpServletRequest)req;
		HttpServletResponse response = (HttpServletResponse)res;
		HttpSession session = request.getSession(true);
		CustomerBean cb = (CustomerBean)session.getAttribute("customer");
		if(cb == null || cb.getId() == null)
			response.sendRedirect("../customer.jspx");
		else{
			response.setHeader("Cache-Control", "no-cache,no-store");
			next.doFilter(req, res);
		}
	}

	public void destroy(){}
}

