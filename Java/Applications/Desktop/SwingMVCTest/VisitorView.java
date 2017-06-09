package app;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.table.*;
import javax.swing.event.*;


public class VisitorView extends JFrame{

	JTextField nameTextField = new JTextField();
	JButton registerButton = new JButton("Register");
	JTable visitorTable = new JTable();

	public VisitorView(ActionListener listener){
		super("SwingMVCApp");
		setSize(400, 300);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
		setUndecorated(true);
		rootPane.setWindowDecorationStyle(JRootPane.FRAME);
		JPanel topPanel = new JPanel(new BorderLayout());
		topPanel.add(new JLabel("Name: "), BorderLayout.WEST);
		topPanel.add(nameTextField);
		topPanel.add(registerButton, BorderLayout.EAST);
		add(topPanel, BorderLayout.NORTH);
		add(new JScrollPane(visitorTable));
		registerButton.addActionListener(listener);
		/*
		registerButton.setEnabled(false);
		nameTextField.getDocument().addDocumentListener(new DocumentListener(){
			public void insertUpdate(DocumentEvent e){
				registerButton.setEnabled(nameTextField.getText().length() > 0);
			}

			public void removeUpdate(DocumentEvent e){
				registerButton.setEnabled(nameTextField.getText().length() > 0);
			}

			public void changedUpdate(DocumentEvent e){}
		});
		*/
	}

	public String getInput(){
		return nameTextField.getText();
	}

	public void bind(TableModel model){
		visitorTable.setModel(model);
	}
}
