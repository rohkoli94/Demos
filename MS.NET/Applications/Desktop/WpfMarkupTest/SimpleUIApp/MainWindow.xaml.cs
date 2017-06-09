using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleUIApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int count = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void greetButton_Click(object sender, RoutedEventArgs e)
        {
            outputtextBlock.Text = $"Good {periodComboBox.Text} {personTextBox.Text}";

            e.Handled = count > 3;
        }

        private void Grid_ButtonClick(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource == greetButton)
                MessageBox.Show($"Number of greetings = {++count}", "SimpleUIApp");
        }
    }
}
