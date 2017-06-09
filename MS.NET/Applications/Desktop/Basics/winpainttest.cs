using System;
using System.Drawing;
using System.Windows.Forms;

class MainForm : Form
{
	private float radius = 100;
	private int direction = 1;

	internal MainForm()
	{
		this.Text = "Hello WinForms";
		this.Size = new Size(400, 400);
		this.BackColor = Color.FromArgb(255, 255, 255);

		Timer anim = new Timer();
		anim.Interval = 100;
		anim.Tick += anim_Tick;
		anim.Start();
	}

	private void anim_Tick(object sender, EventArgs e)
	{
		radius -= 0.9f * direction;
		
		if(radius < 10 || radius > 100)
			direction = -direction;
	
		Refresh();
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		using(Brush br = new SolidBrush(Color.Green))
			e.Graphics.FillEllipse(br, 100, 100, 2 * radius, 2 * radius);

		using(Pen pn = new Pen(Color.Blue, 5))		
			e.Graphics.DrawEllipse(pn, 100, 100, 2 * radius, 2 * radius);
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