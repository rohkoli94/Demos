import javax.swing.*;

class SwingPlainTest{
	
	static class MainFrame extends JFrame{
		
		MainFrame(){
			super("Hello Swing");
			setSize(400, 400);
			setDefaultCloseOperation(EXIT_ON_CLOSE);
		}
	}

	public static void main(String[] args) throws Exception{
		MainFrame frame = new MainFrame();
		frame.setVisible(true);
	}
}

