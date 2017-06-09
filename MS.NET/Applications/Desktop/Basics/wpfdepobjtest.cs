using System;
using System.Threading;
using System.Windows;
using System.Windows.Data;

class Clock : DependencyObject 
{
	public static readonly DependencyProperty TimeProperty = DependencyProperty.Register("Time", typeof(string), typeof(Clock));

	public string Time
	{
		get {return (string)GetValue(TimeProperty);}
		set {SetValue(TimeProperty, value);}
	}

	internal Clock()
	{
		Thread child = new Thread(Execute);
		child.IsBackground = true;
		child.Start();
	}

	private void Execute()
	{
		for(;;)
		{
			Thread.Sleep(1000);
			
			//called by child thread
			Dispatcher.Invoke(delegate()
			{
				//executed by owner thread of this object 
				this.Time = DateTime.Now.ToString();				
			});
		}
	}
}


class MainWindow : Window
{
	internal MainWindow()
	{
		this.Title = "Hello WPF";

		Binding clockBinding = new Binding("Time");
		clockBinding.Source = new Clock();

		this.SetBinding(ContentProperty, clockBinding);
	}
}

static class Program
{
	[STAThread]
	public static void Main()
	{
		Application app = new Application();
		app.Run(new MainWindow());
	}
}