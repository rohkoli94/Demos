using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBWinApp
{
    public partial class OrderForm : Form
    {
        internal string customerId;

        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'shopDataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.shopDataSet.Product);
            this.Text = "New Order - " + customerId;
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            int productNo = int.Parse(productNoComboBox.Text);
            int quantity = int.Parse(quantityNumericUpDown.Text);
            var shop = new ShopDataSetTableAdapters.ShopQueries();

            int orderNo = (int)shop.SelectNewOrderNo();
            shop.InsertNewOrder(orderNo, DateTime.Today, customerId, productNo, quantity);

            MessageBox.Show($"New order number is {orderNo}", "Order Placed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();

        }
    }
}
