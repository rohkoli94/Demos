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
        CartClient client = new CartClient();

        public MainForm()
        {
            InitializeComponent();
        }

        private async void addButton_Click(object sender, EventArgs e)
        {
            string item = itemTextBox.Text;

            try
            {
                await client.AddItemAsync(item);
                itemsListBox.Items.Add(item);
            }
            catch(FaultException<MissingItem> ex)
            {
                MessageBox.Show($"This shop does not sell {ex.Detail.ItemName}", "ClientApp", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ClientApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void checkoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                double payment = await client.CheckoutAsync();
                MessageBox.Show($"Total payment is {payment:0.00}", "ClientApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ClientApp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
