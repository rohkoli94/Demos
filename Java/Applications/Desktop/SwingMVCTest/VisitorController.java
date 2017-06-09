package app;

import java.awt.event.*;

public class VisitorController implements ActionListener{

	VisitorModel model = new VisitorModel();
	VisitorView view = new VisitorView(this);

	public void actionPerformed(ActionEvent e){
		String name = view.getInput();
		model.register(name);
	}

	private void start(){
		view.bind(model);
		view.setVisible(true);
	}

	public static void main(String[] args) throws Exception{
		VisitorController controller = new VisitorController();
		controller.start();
	}
}

