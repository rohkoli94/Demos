using System;

class MessageEventArgs : EventArgs
{
	public string From {get;}

	public string Text {get;}

	internal MessageEventArgs(string frm, string txt)
	{
		From = frm;
		Text = txt;
	}
}

delegate void MessageEventHandler(object sender, MessageEventArgs e);

//event source
class Messenger
{
	public string Owner {get; set;}

	public event MessageEventHandler Receive;

	private void OnReceive(MessageEventArgs e)
	{
		Receive?.Invoke(this, e);
	}

	public void Send(string text, Messenger to)
	{
		MessageEventArgs e = new MessageEventArgs(Owner, text);
		to.OnReceive(e);
	}
} 

//event sink
class MessengerApp
{
	private Messenger first, second;

	internal MessengerApp()
	{
		first = new Messenger();
		first.Owner = "Jack";
		first.Receive += first_Receive;
		first.Receive += ShowTime; //contravariance for second parameter

		second = new Messenger();
		second.Owner = "Jill";
	}

	private void first_Receive(object sender, MessageEventArgs e)
	{
		Console.WriteLine(">> Jack received '{0}' from {1}", e.Text, e.From);
	}

	private void ShowTime(object sender, EventArgs e)
	{
		Console.WriteLine(DateTime.Now);
	}

	internal void Run()
	{
		second.Send("Hi Jack", first);

		for(int t = Environment.TickCount + 5000; Environment.TickCount < t;);

		second.Send("Bye Jack", first);
	}
}

static class Program
{
	public static void Main()
	{
		var app = new MessengerApp();
		app.Run();
	}
}