using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CCCTurn
{
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
        }
        private void Orders_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            comboLoad();
            cboType.SelectedIndex = -1;
        }
        private void comboLoad()
        {
            string query = "select rateid,Location from Rate order By Location";
            cboDestination.DataSource = Connection.Instance.ShowDataInGridView(query);
            cboDestination.DisplayMember = "Location";
            cboDestination.ValueMember = "rateid";
            cboDestination.SelectedIndex = -1;

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblVehicleID.Text = "";
            lblRate.Text = "";
            txtParty.Text = "";
            comboLoad();
            cboDestination.SelectedIndex = -1;
            cboType.SelectedIndex = -1;
            txtVehicle.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            txtParty.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboDestination.SelectedIndex<0)
                MessageBox.Show("Please select a destination");
            else if (cboType.Text.Trim() == "")
                MessageBox.Show("Please selecet a vehicle type");
            else if (lblVehicleID.Text=="")
                MessageBox.Show("No vehicle available to allot this order");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save the Order?", "Order Entry", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string query = "insert into Orders(oDate,Party_Name,rateid,Vehicle_Type,Rate,vehicleid,allt_date) values('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "','" + txtParty.Text.Trim() + "','" + cboDestination.SelectedValue + "','" + cboType.Text + "','"+ lblRate.Text +"','" + lblVehicleID.Text.Trim() + "',GETDATE())";
                    Connection.Instance.ExecuteQueries(query);
                   
                   query = "update Vehicles set isAvailable=0 where vehicleid='" + lblVehicleID.Text + "'";
                   Connection.Instance.ExecuteQueries(query);

                    
                    btnClear_Click(null, null);
                }
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from Rate where rateid='" + cboDestination.SelectedValue + "'";
                DataTable dt = (DataTable)Connection.Instance.ShowDataInGridView(query);
                if (dt.Rows.Count > 0)
                {
                    if (cboType.Text == "20 DA")
                        lblRate.Text = dt.Rows[0][2].ToString();
                    else if (cboType.Text == "20 Trailor")
                        lblRate.Text = dt.Rows[0][3].ToString();
                    if (cboType.Text == "20 Multi")
                        lblRate.Text = dt.Rows[0][4].ToString();
                    else if (cboType.Text == "40 DA")
                        lblRate.Text = dt.Rows[0][5].ToString();
                    if (cboType.Text == "40 Trailor")
                        lblRate.Text = dt.Rows[0][6].ToString();
                    else if (cboType.Text == "40 Multi")
                        lblRate.Text = dt.Rows[0][7].ToString();

                    query = "select top 1 * from Vehicles where Vehicle_Type='" + cboType.Text + "' and isAvailable=1 and isActive=1 order by availability_order";
                    dt.Rows.Clear();
                    dt = (DataTable)Connection.Instance.ShowDataInGridView(query);
                    if (dt.Rows.Count > 0)
                    {
                        lblVehicleID.Text = dt.Rows[0][0].ToString();
                        txtVehicle.Text = dt.Rows[0][2].ToString();

                    }
                    else
                    {
                        txtVehicle.Text = "";
                        lblVehicleID.Text = "";
                        MessageBox.Show("No vehicle available to allot this order");
                    }
                }
            }
            catch {
                txtVehicle.Text = "";
                lblVehicleID.Text = "";
                cboType.SelectedIndex = -1;
                lblRate.Text = "";
            }

        }

    }


}

