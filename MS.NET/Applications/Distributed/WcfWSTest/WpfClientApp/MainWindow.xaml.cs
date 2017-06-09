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

namespace WpfClientApp
{
    using Shopping;
    using System.Collections.ObjectModel;

    class PurchaseEntry
    {
        public int Order { get; set; }

        public string Item { get; set; }

        public int Quantity { get; set; }

        public double Amount { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ICollection<PurchaseEntry> purchases;

        public MainWindow()
        {
            InitializeComponent();

            purchases = new ObservableCollection<PurchaseEntry>();
            ordersDataGrid.ItemsSource = purchases;
        }

        private void getButton_Click(object sender, RoutedEventArgs e)
        {
            string item = itemTextBox.Text;

            using (var client = new CustomerSupportClient())
            {
                int stock = client.Inquire(item);
                quantityTextBox.Text = stock.ToString();
            }
        }

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            string item = itemTextBox.Text;
            int quantity = int.Parse(quantityTextBox.Text);

            using (var client = new CustomerSupportClient())
            {
                Receipt purchase = client.Purchase(item, quantity);
                if (purchase.Status != 0)
                {
                    purchases.Add(new PurchaseEntry
                    {
                        Order = purchase.Status,
                        Item = item,
                        Quantity = quantity,
                        Amount = purchase.Payment
                    });
                }
                else
                    MessageBox.Show("Not available!", this.Title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            double payment = purchases.Sum(p => p.Amount);
            string text = $"Total payment is {payment:0.00}, clear orders?";

            if(MessageBox.Show(text, this.Title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                itemTextBox.Clear();
                quantityTextBox.Clear();
                purchases.Clear();
            }
        }
    }
}
