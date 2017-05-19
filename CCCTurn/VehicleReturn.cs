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
    public partial class VehicleReturn : Form
    {
        private bool isStart=true;
        public VehicleReturn()
        {
            InitializeComponent();
        }

        private void VehicleReturn_Load(object sender, EventArgs e)
        {
            isStart = true;
            comboLoad();
           cboVehicle.SelectedIndex = -1;
           
        }
        private void comboLoad()
        {
            string query = "select vehicleid,Vehicle_Number from Vehicles  where isAvailable=0 order By Vehicle_Number";
            cboVehicle.DataSource = Connection.Instance.ShowDataInGridView(query);
            cboVehicle.DisplayMember = "Vehicle_Number";
            cboVehicle.ValueMember = "vehicleid";
            isStart = false;
        }

        private void cboVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVehicle.SelectedIndex >= 0 && !isStart)
            {
                string query = "select o.oid,o.odate,o.party_name,r.Location,o.Vehicle_Type from Orders o INNER JOIN Rate r on r.rateid=o.rateid and o.isCompleted=0 WHERE vehicleid='" + cboVehicle.SelectedValue + "'";
                DataTable dt = (DataTable)Connection.Instance.ShowDataInGridView(query);
                if (dt.Rows.Count > 0)
                {
                    lblID.Text = dt.Rows[0][0].ToString();
                    lblDate.Text = dt.Rows[0][1].ToString();
                    lblParty.Text = dt.Rows[0][2].ToString();
                    lblDestination.Text = dt.Rows[0][3].ToString();
                    lblType.Text = dt.Rows[0][4].ToString();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            comboLoad();
            lblDate.Text = "";
            lblDestination.Text = "";
            lblID.Text = "";
            lblParty.Text = "";
            lblType.Text = "";
            cboVehicle.Text = "";
            cboVehicle.SelectedIndex = -1;
            cboVehicle.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboVehicle.SelectedIndex < 0)
                MessageBox.Show("Please select a vehicle");
            else if (lblID.Text=="")
                MessageBox.Show("Please select a vehicle properly");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to save?", "Vehicle Return", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string query = "insert into VehicleReturn values('" + cboVehicle.SelectedValue + "','" + lblID.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')";
                    Connection.Instance.ExecuteQueries(query);

                    query = "select max(availability_order) from Vehicles";
                    DataTable dt = (DataTable)Connection.Instance.ShowDataInGridView(query);
                    int availability_order = 1;
                    if (dt.Rows.Count > 0)
                    {
                        availability_order = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                        query = "update Vehicles set availability_order='" + availability_order + "',isAvailable=1 where vehicleid='" + cboVehicle.SelectedValue + "'";
                        Connection.Instance.ExecuteQueries(query);
                        query = "update orders set isCompleted=1 where oid='" + lblID.Text +"'";
                        Connection.Instance.ExecuteQueries(query);
                    }


                    btnClear_Click(null, null);
                }
            }
        }
    }
}
