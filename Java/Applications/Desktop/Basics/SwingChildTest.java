import java.util.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

class SwingChildTest{
	
	static class MainFrame extends JFrame{
		
		MainFrame(){
			super("Hello Swing");
			setSize(400, 400);
			setDefaultCloseOperation(EXIT_ON_CLOSE);
			setLayout(new FlowLayout());
			JButton timeButton = new JButton("Time");
			timeButton.addActionListener(new ActionListener(){
				public void actionPerformed(ActionEvent e){
					Date now = new Date();
					JOptionPane.showMessageDialog(MainFrame.this, now, "Hello Swing", JOptionPane.INFORMATION_MESSAGE);
				}
			});
			add(timeButton);
		}
	}

	public static void main(String[] args) throws Exception{
		UIManager.setLookAndFeel(new com.sun.java.swing.plaf.motif.MotifLookAndFeel());
		MainFrame frame = new MainFrame();
		frame.setVisible(true);
	}
}

