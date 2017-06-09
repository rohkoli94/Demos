using System;

namespace BindingApp
{
    public class Visitor
    {
        public string Name { get; set; }

        public int Frequency { get; set; } = 1;

        public DateTime Recent { get; set; } = DateTime.Now;

        public void Revisit()
        {
            Frequency += 1;
            Recent = DateTime.Now;
        }

    }

    public class VisitorModel
    {
        private Document<Visitor> dataStore;

        public VisitorModel()
        {
            dataStore = Document<Visitor>.Open("visitors.xml");
        }

        public Visitor[] ReadVisitors()
        {
            return dataStore.ToArray();
        }

        public void WriteVisitor(string name)
        {
            Visitor visitor = dataStore.Find(e => e.Name == name);

            if (visitor == null)
                dataStore.Add(new Visitor { Name = name });
            else
                visitor.Revisit();

            dataStore.Save();
        }
    }
}
