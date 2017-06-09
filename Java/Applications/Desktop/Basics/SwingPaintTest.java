import java.util.*;
import java.awt.*;
import javax.swing.*;

class SwingPaintTest{
	
	static class MainFrame extends JFrame{
		
		MainFrame(){
			super("Hello Swing");
			setSize(400, 400);
			setDefaultCloseOperation(EXIT_ON_CLOSE);
			setUndecorated(true);
			rootPane.setWindowDecorationStyle(JRootPane.FRAME);
			setContentPane(new DrawPanel());
		}

		class DrawPanel extends JPanel{
		
			@Override
			public void paintComponent(Graphics g){
				Date now = new Date();
				g.setColor(Color.RED);
				g.drawRect(40, 40, 200, 20);
				g.setColor(Color.BLUE);
				g.drawString(now.toString(), 45, 55);
			}
		}
	}

	public static void main(String[] args) throws Exception{
		MainFrame frame = new MainFrame();
		frame.setVisible(true);
		for(;;){
			Thread.sleep(1000);
			SwingUtilities.invokeLater(new Runnable(){
				public void run(){
					frame.repaint();
				}
			});
		}
	}
}

