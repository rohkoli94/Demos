using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirstApp
{
    public partial class MainForm : Form
    {
        private EstateEntities estate = new EstateEntities();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            houseTypeComboBox.SelectedIndex = 0;
        }

        private void houseTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (houseTypeComboBox.SelectedIndex == 0)
                housesDataGridView.DataSource = estate.Houses.OfType<Apartment>().ToList();
            else
                housesDataGridView.DataSource = estate.Houses.OfType<Bungalow>().ToList();
        }

        private void acquireButton_Click(object sender, EventArgs e)
        {
            House house;
            int count = int.Parse(countTextBox.Text);

            if (houseTypeComboBox.SelectedIndex == 0)
                house = new Apartment { Floor = count };
            else
                house = new Bungalow { Floors = count };
            house.Area = float.Parse(areaTextBox.Text);

            estate.Houses.Add(house);
            estate.SaveChanges();

            houseTypeComboBox_SelectedIndexChanged(this, e);
        }


    }
}
