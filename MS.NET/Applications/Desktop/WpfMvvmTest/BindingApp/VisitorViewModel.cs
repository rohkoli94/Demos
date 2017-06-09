using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingApp
{
    using System.Windows.Input;
    using System.ComponentModel;

    public class VisitorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private VisitorModel model = new VisitorModel();

        public IEnumerable<Visitor> Visitors => model.ReadVisitors();

        private string nameToRegister;

        public string NameToRegister
        {
            get { return nameToRegister; }
            set
            {
                nameToRegister = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameToRegister"));
            }
        }

        private bool CanExecuteRegister()
        {
            return nameToRegister?.Length > 0;
        }

        private void ExecuteRegister()
        {
            model.WriteVisitor(nameToRegister);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Visitors"));
        }

        class RegisterCommand : ICommand
        {
            internal VisitorViewModel Outer;

            event EventHandler ICommand.CanExecuteChanged
            {
                add
                {
                    CommandManager.RequerySuggested += value;
                }

                remove
                {
                    CommandManager.RequerySuggested -= value;
                }
            }

            bool ICommand.CanExecute(object parameter)
            {
                return Outer.CanExecuteRegister();
            }

            void ICommand.Execute(object parameter)
            {
                Outer.ExecuteRegister();
            }
        }

        public ICommand Register => new RegisterCommand { Outer = this };
    }
}
