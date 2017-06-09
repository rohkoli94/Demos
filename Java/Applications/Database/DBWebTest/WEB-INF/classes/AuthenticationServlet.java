package saleswebapp;

import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.annotation.*;

@WebServlet({"/login", "/logout"})
public class AuthenticationServlet extends HttpServlet{

	@Override
	public void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException{
		HttpSession session = request.getSession(true);
		CustomerBean cb = (CustomerBean)session.getAttribute("customer");
		if(cb == null){
			cb = new CustomerBean();
			session.setAttribute("customer", cb);
		}
		String customerId = request.getParameter("customerId");
		String password = request.getParameter("password");
		try{
			if(cb.authenticate(customerId, password))
				response.sendRedirect("protected/order.jspx");
			else
				response.sendRedirect("customer.jspx?failed=true");
		}catch(Exception e){
			response.sendError(500, e.getMessage());
		}
	}
	
	@Override
	public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException{
		HttpSession session = request.getSession(false);
		if(session != null)
			session.invalidate();
		RequestDispatcher dispatcher = request.getRequestDispatcher("/product.jspx");
		dispatcher.forward(request, response);
	}
}
