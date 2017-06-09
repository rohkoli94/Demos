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

namespace PresentationTierApp
{
    using Sales;
    using System.ServiceModel;
    using System.Transactions;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void orderButton_Click(object sender, RoutedEventArgs e)
        {
            string customerId = customerIdTextBox.Text.ToUpper();
            int productNo = int.Parse(productNoTextBox.Text);
            int quantity = int.Parse(quantityTextBox.Text);

            using (var service = new ChannelFactory<IOrderManager>("OrderManagerTcp"))
            {
                IOrderManager client = service.CreateChannel();

                try
                {
                    int orderNo;
                    decimal payment;

                    using (var tx = new TransactionScope())
                    {
                        orderNo = client.PlaceOrder(customerId, productNo, quantity);
                        payment = client.SellProduct(productNo, quantity);
                        tx.Complete();
                    }

                    MessageBox.Show($"New order number is {orderNo} and payment is {payment:0.00}", "Order Placed", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Order cannot be placed with the specified input!", "Order Failed", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    service.Abort();
                }
            }
        }
    }
}
