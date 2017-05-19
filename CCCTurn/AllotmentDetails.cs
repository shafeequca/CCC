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
    public partial class AllotmentDetails : Form
    {
        private bool isStart = true;

        public AllotmentDetails()
        {
            InitializeComponent();
        }

        private void AllotmentDetails_Load(object sender, EventArgs e)
        {
            comboLoad();
            cboOwner.SelectedIndex = -1;
        }
        private void comboLoad()
        {
            string query = "select ownid,Owner_Name from Owners order By Owner_Name";
            cboOwner.DataSource = Connection.Instance.ShowDataInGridView(query);
            cboOwner.DisplayMember = "Owner_Name";
            cboOwner.ValueMember = "ownid";
            isStart = false;

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //GridShow();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

         GridShow();
        }
        private void GridShow()
        {
            string query = "select o.oid as Order_No,convert(varchar, o.Odate,105) as Order_Date,o.Party_Name,r.Location as Destination,v.Vehicle_Number,o.Vehicle_Type,o.Rate,o.Commission, CASE WHEN o.isCompleted=1 and isCancelled=0 then 'Delivered' when isCancelled=1 then 'Cancelled' else 'Not Delivered' END as Status from Orders o inner join Rate r on r.rateid=o.rateid INNER JOIN Vehicles v on v.vehicleid=o.vehicleid where oDate>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and oDate<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            if (cboVehicle.SelectedIndex>=0)
                query = "select o.oid as Order_No,convert(varchar, o.Odate,105) as Order_Date,o.Party_Name,r.Location as Destination,v.Vehicle_Number,o.Vehicle_Type,o.Rate,o.Commission, CASE WHEN o.isCompleted=1 and isCancelled=0 then 'Delivered' when isCancelled=1 then 'Cancelled' else 'Not Delivered' END as Status from Orders o inner join Rate r on r.rateid=o.rateid INNER JOIN Vehicles v on v.vehicleid=o.vehicleid where oDate>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and oDate<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and o.vehicleid='" + cboVehicle.SelectedValue + "'";
            else if (cboOwner.SelectedIndex >= 0)
                query = "select o.oid as Order_No,convert(varchar, o.Odate,105) as Order_Date,o.Party_Name,r.Location as Destination,v.Vehicle_Number,o.Vehicle_Type,o.Rate,o.Commission, CASE WHEN o.isCompleted=1 and isCancelled=0 then 'Delivered' when isCancelled=1 then 'Cancelled' else 'Not Delivered' END as Status from Orders o inner join Rate r on r.rateid=o.rateid INNER JOIN Vehicles v on v.vehicleid=o.vehicleid where oDate>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and oDate<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and v.ownid='" + cboOwner.SelectedValue + "'";

            dataGridView1.DataSource = Connection.Instance.ShowDataInGridView(query);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            cboOwner.Text = "";
            cboOwner.SelectedIndex = -1;
            cboVehicle.Text = "";
            cboVehicle.SelectedIndex = -1;

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            //GridShow();
        }

        private void cboOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboOwner.SelectedIndex >= 0 && !isStart)
            {

                string query = "select vehicleid,Vehicle_Name from Vehicles where ownid='" + cboOwner.SelectedValue + "' order By Vehicle_Name";
                cboVehicle.DataSource = Connection.Instance.ShowDataInGridView(query);
                cboVehicle.DisplayMember = "Vehicle_Name";
                cboVehicle.ValueMember = "vehicleid";
                cboVehicle.SelectedIndex = -1;
            }
        }
    }
}
