using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    using Shopping;
    using System.ServiceModel;

    public partial class MainForm : Form
    {
        NetTcpBinding binding = new NetTcpBinding();
        string address = "net.tcp://localhost:4011/shopping/shopkeeper";

        public MainForm()
        {
            InitializeComponent();
        }

        private void purchaseButton_Click(object sender, EventArgs e)
        {
            string item = itemTextBox.Text;
            int quantity = int.Parse(quantityTextBox.Text);

            using (var service = new ChannelFactory<IShopKeeper>(binding, address))
            {
                IShopKeeper client = service.CreateChannel();

                ItemInfo info = client.GetItemInfo(item);

                if (info == null)
                    paymentTextBox.Text = "item not sold!";
                else if (quantity > info.CurrentStock)
                    paymentTextBox.Text = "item not in stock!";
                else
                {
                    float discount = client.GetBulkDiscount(quantity);
                    double payment = quantity * info.UnitPrice * (1 - discount / 100);

                    paymentTextBox.Text = payment.ToString("0.00");
                }
            }
        }
    }
}
