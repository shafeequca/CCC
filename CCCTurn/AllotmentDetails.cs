using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CCCTurn.Dataset;

namespace CCCTurn
{
    public partial class AllotmentDetails : Form
    {
        private bool isStart = true;
        DataSet1 ds;

        public AllotmentDetails()
        {
            InitializeComponent();
        }

        private void AllotmentDetails_Load(object sender, EventArgs e)
        {
            ds = new DataSet1();
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
            string query = "select ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS Sl_No,convert(varchar, o.Odate,105) as Order_Date,o.Party_Name,r.Location as Destination,v.Vehicle_Number,o.Vehicle_Type,o.Order_Type,o.Rate,o.Commission, CASE WHEN o.isCompleted=1 and isCancelled=0 then 'Delivered' when isCancelled=1 then 'Cancelled' else 'Not Delivered' END as Status from Orders o inner join Rate r on r.rateid=o.rateid INNER JOIN Vehicles v on v.vehicleid=o.vehicleid where oDate>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and oDate<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            if (cboVehicle.SelectedIndex>=0)
                query = "select ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS Sl_No,convert(varchar, o.Odate,105) as Order_Date,o.Party_Name,r.Location as Destination,v.Vehicle_Number,o.Vehicle_Type,o.Order_Type,o.Rate,o.Commission, CASE WHEN o.isCompleted=1 and isCancelled=0 then 'Delivered' when isCancelled=1 then 'Cancelled' else 'Not Delivered' END as Status from Orders o inner join Rate r on r.rateid=o.rateid INNER JOIN Vehicles v on v.vehicleid=o.vehicleid where oDate>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and oDate<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and o.vehicleid='" + cboVehicle.SelectedValue + "'";
            else if (cboOwner.SelectedIndex >= 0)
                query = "select ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS Sl_No,convert(varchar, o.Odate,105) as Order_Date,o.Party_Name,r.Location as Destination,v.Vehicle_Number,o.Vehicle_Type,o.Order_Type,o.Rate,o.Commission, CASE WHEN o.isCompleted=1 and isCancelled=0 then 'Delivered' when isCancelled=1 then 'Cancelled' else 'Not Delivered' END as Status from Orders o inner join Rate r on r.rateid=o.rateid INNER JOIN Vehicles v on v.vehicleid=o.vehicleid where oDate>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and oDate<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' and v.ownid='" + cboOwner.SelectedValue + "'";
            try
            {
                dataGridView1.DataSource = Connection.Instance.ShowDataInGridView(query);
                System.Data.DataColumn Date_From = new System.Data.DataColumn("Date_From", typeof(System.DateTime));
                Date_From.DefaultValue = dateTimePicker1.Value;
                System.Data.DataColumn Date_To = new System.Data.DataColumn("Date_To", typeof(System.DateTime));
                Date_To.DefaultValue = dateTimePicker1.Value;
                System.Data.DataColumn Owner = new System.Data.DataColumn("Owner", typeof(System.String));
                Owner.DefaultValue = cboOwner.GetItemText(cboOwner.SelectedItem);
                System.Data.DataColumn Vehicle = new System.Data.DataColumn("Vehicle", typeof(System.String));
                Vehicle.DefaultValue = cboVehicle.GetItemText(cboVehicle.SelectedItem);
                DataTable dt = (DataTable)Connection.Instance.ShowDataInGridView(query);
                dt.Columns.Add(Date_From);
                dt.Columns.Add(Date_To);
                dt.Columns.Add(Owner);
                dt.Columns.Add(Vehicle);

                ds.Tables["AllottmentDetails"].Clear();
                ds.Tables["AllottmentDetails"].Merge(dt);
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Connection.Instance.ShowDataInGridView(query);
                //dataGridView1.Columns[0].Visible = false;
                //dataGridView1.Columns[1].MinimumWidth = 350;
                //ItemGrid.Columns[5].HeaderText = "Total";
                //ItemGrid.Columns.Add("Cash", "Cash");
                //ItemGrid.Columns.Add("Discounts", "Discounts");
                //ItemGrid.Columns.Add("Bal", "Balance");
            }
            catch (Exception ex)
            { }
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                btnShow_Click(null, null);
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + @"\Reports\rptAllottmentDetails.rpt");
            cryRpt.SetDataSource(ds);
            cryRpt.Refresh();
            cryRpt.PrintToPrinter(1, true, 0, 0);
        }
    }
}
