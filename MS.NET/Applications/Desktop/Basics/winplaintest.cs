using System;
using System.Windows.Forms;

class MainForm : Form
{
	internal MainForm()
	{
		this.Text = "Hello WinForms";
	}

	protected override void OnClosed(EventArgs e)
	{
		MessageBox.Show("Goodbye User", "Hello WinForms");
	}
}

static class Program
{
	[STAThread]
	public static void Main()
	{
		Application.Run(new MainForm());		
	}
}