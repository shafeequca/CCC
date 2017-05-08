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
    public partial class CancellationDetails : Form
    {
        public CancellationDetails()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

            GridShow();
        }
        private void GridShow()
        {
            string query = "select o.oid as Order_No,convert(varchar, o.Odate,105) as Order_Date,o.Party_Name,r.Location as Destination,v.Vehicle_Name,v.Vehicle_Number,o.Vehicle_Type,o.Rate,c.Reason  from Orders o inner join Rate r on r.rateid=o.rateid INNER JOIN Vehicles v on v.vehicleid=o.vehicleid inner join OrderCancellation c on c.oid=o.oid where oDate>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' and oDate<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "'";
           
            dataGridView1.DataSource = Connection.Instance.ShowDataInGridView(query);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dataGridView1.DataSource = null;
        }
    }
}
