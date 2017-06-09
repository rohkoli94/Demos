package app;

public class VisitorModel extends javax.swing.table.AbstractTableModel{

	private Document<Visitor> store;

	public VisitorModel(){
		store = Document.open(Visitor.class, "visitors.xml");
	}

	@Override
	public int getColumnCount(){
		return 3;
	}

	@Override
	public String getColumnName(int i){
		String[] names = {"Name", "Frequency", "Recent"};
		return names[i];
	}

	@Override
	public int getRowCount(){
		return store.size();
	}

	@Override
	public Object getValueAt(int i, int j){
		Visitor visitor = store.get(i);
		Object[] row = {visitor.name, visitor.frequency, visitor.recent};
		return row[j];
	}

	public void register(String name){
		Visitor visitor = store.find(e -> e.name.equals(name));
		if(visitor == null)
			store.add(new Visitor(name));
		else
			visitor.revisit();
		store.save();
		fireTableDataChanged();
	}
}

