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
    public partial class AllotmentDetailsAll : Form
    {
        DataSet1 ds;
        public AllotmentDetailsAll()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            GridShow();
        }
        private void GridShow()
        {
            string query = "select ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS Sl_No,convert(varchar, o.Odate,105) as Order_Date,o.Party_Name,r.Location as Destination,v.Vehicle_Number,o.Vehicle_Type,o.Order_Type,o.Rate,o.Commission, CASE WHEN o.isCompleted=1 and isCancelled=0 then 'Delivered' when isCancelled=1 then 'Cancelled' else 'Not Delivered' END as Status from Orders o inner join Rate r on r.rateid=o.rateid INNER JOIN Vehicles v on v.vehicleid=o.vehicleid where oDate>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and oDate<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
            try
            {
                dataGridView1.DataSource = Connection.Instance.ShowDataInGridView(query);

                System.Data.DataColumn Date_From = new System.Data.DataColumn("Date_From", typeof(System.DateTime));
                Date_From.DefaultValue = dateTimePicker1.Value;
                System.Data.DataColumn Date_To = new System.Data.DataColumn("Date_To", typeof(System.DateTime));
                Date_To.DefaultValue = dateTimePicker1.Value;
                System.Data.DataColumn Owner = new System.Data.DataColumn("Owner", typeof(System.String));
                Owner.DefaultValue = "";
                System.Data.DataColumn Vehicle = new System.Data.DataColumn("Vehicle", typeof(System.String));
                Vehicle.DefaultValue = "";
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
            {}
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today.Date;
            dateTimePicker2.Value = DateTime.Today.Date;
            dataGridView1.DataSource = null;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                btnShow_Click(null, null);
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(System.IO.Path.GetDirectoryName(Application.ExecutablePath).ToString() + @"\Reports\rptAllottmentDetailsAll.rpt");
            cryRpt.SetDataSource(ds);
            cryRpt.Refresh();
            cryRpt.PrintToPrinter(1, true, 0, 0);
        }

        private void AllotmentDetailsAll_Load(object sender, EventArgs e)
        {
            ds = new DataSet1();
        }
    }
}
