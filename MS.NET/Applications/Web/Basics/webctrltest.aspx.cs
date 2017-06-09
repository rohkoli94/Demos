using System;

namespace BasicWebApp
{
	partial class WebCtrlTestPage : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			VisitorLabel.Text = Request.QueryString["visitor"];
			TimeLabel.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		}
	}
}