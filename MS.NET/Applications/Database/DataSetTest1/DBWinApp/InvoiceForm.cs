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
    public partial class InvoiceForm : Form
    {
        internal string customerId;

        public InvoiceForm()
        {
            InitializeComponent();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            this.Text = "Invoice - " + customerId;
            invoiceTableAdapter.Fill(shopDataSet.Invoice, customerId);
        }
    }
}
