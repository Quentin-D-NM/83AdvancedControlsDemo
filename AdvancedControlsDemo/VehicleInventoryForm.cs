using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedControlsDemo
{
    public partial class VehicleInventoryForm : Form
    {
        private List<Vehicle> vehicles = new List<Vehicle>();
        public VehicleInventoryForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboxType.Text == "Sedan")
            {
                Sedan sedan = new Sedan();
                sedan.LicensePlate = txtLicense.Text;
                sedan.VIN = txtVin.Text;
                vehicles.Add(sedan);
                //Refresh the list box
                lboxInventory.DataSource = null;
                lboxInventory.DataSource = vehicles;
                txtResults.Text = "Successfuly added sedan";
            }
            else if (cboxType.Text == "Truck")
            {
                Truck truck = new Truck(txtVin.Text, txtLicense.Text);
                vehicles.Add(truck);
                //Refresh the list box
                lboxInventory.DataSource = null;
                lboxInventory.DataSource = vehicles;
                txtResults.Text = "Successfuly added truck";
            }
        }

        private void lboxInventory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Vehicle vehicle = (Vehicle)lboxInventory.SelectedItem;
            txtSummary.Text = vehicle.GetDescription();
        }
    }
}
