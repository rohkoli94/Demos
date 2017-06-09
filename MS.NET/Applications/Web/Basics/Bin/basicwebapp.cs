using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BasicWebApp
{
	public class PageModule : IHttpModule
	{
		public void Init(HttpApplication app)
		{
			app.BeginRequest += delegate(object sender, EventArgs e)
			{
				string path = app.Context.Request.Path;
				if(path.EndsWith(".page"))
					app.Context.RewritePath(path.Replace(".page", ".html"));
			};
		}

		public void Dispose() {}
	}
	
	public class GreetingHandler : IHttpHandler
	{
		public void ProcessRequest(HttpContext context)
		{
			string name = context.Request.QueryString["visitor"];
			TextWriter output = context.Response.Output;

			output.WriteLine("<html>");
			output.WriteLine("<head><title>BasicWebApp</title></head>");
			output.WriteLine("<body>");
			output.WriteLine($"<h1>Welcome Visitor {name}</h1>");
			output.WriteLine($"<b>Time on server: </b>{DateTime.Now}");
			output.WriteLine("</body>");
			output.WriteLine("</html>");

		}

		public bool IsReusable
		{
			get {return true;}
		}
	}
	
	public class StateHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
	{
		public void ProcessRequest(HttpContext context)
		{
			string name = context.Request.Form["visitor"];
			if(name == null || name.Length == 0)
			{
				context.Response.Redirect("welcome.gwh");
				return ;				
			}
			
			int count = (int?)context.Session[name] ?? 1;
			context.Session[name] = count + 1;
			
			TextWriter output = context.Response.Output;
			output.WriteLine("<html>");
			output.WriteLine("<head><title>BasicWebApp</title></head>");
			output.WriteLine("<body>");
			output.WriteLine($"<h1>Hello {name}</h1>");
			output.WriteLine($"<b>Number of greetings = </b>{count}");
			output.WriteLine("</body>");
			output.WriteLine("</html>");

		}

		public bool IsReusable
		{
			get {return false;}
		}
		
	}

	public class PostBackTestPage : Page
	{
		protected Label OutputLabel;
		protected TextBox NameTextBox;
		protected Label GreetCountLabel;

		protected void GreetButton_Click(object sender, EventArgs e)
		{
			string name = NameTextBox.Text;
			OutputLabel.Text = "Hello " + name;

			int count = (int?)ViewState[name] ?? 1;
			ViewState[name] = count + 1;
			GreetCountLabel.Text = "Number of greetings = " + count;
		}
	}
}