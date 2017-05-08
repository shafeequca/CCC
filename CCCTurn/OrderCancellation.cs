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
    public partial class OrderCancellation : Form
    {
        public OrderCancellation()
        {
            InitializeComponent();
        }

        private void OrderCancellation_Load(object sender, EventArgs e)
        {
           // comboLoad();
            GridShow();
        }
        //private void comboLoad()
        //{
        //    string query = "select r.rateid,r.Location from Orders o inner join Rate r on r.rateid=o.rateid and o.isCompleted=0 order By r.Location";
        //    cboDestination.DataSource = Connection.Instance.ShowDataInGridView(query);
        //    cboDestination.DisplayMember = "Location";
        //    cboDestination.ValueMember = "rateid";

        //}
        private void GridShow()
        {
            try
            {
                string query = "select o.oid as Order_No,oDate as Order_Date,r.Location as Destination,o.Vehicle_Type,v.Vehicle_name from orders o inner join Vehicles v on o.vehicleid=v.vehicleid inner join rate r on o.rateid=r.rateid where o.isCompleted=0  order by o.oid desc";

                //if (cboDestination.SelectedIndex >= 0)
                //{
                //    query = "select o.oid as Order_No,oDate as Order_Date,r.Location as Destination,o.Vehicle_Type,v.Vehicle_name from orders o inner join Vehicles v on o.vehicleid=v.vehicleid inner join rate on o.rateid=r.rateid where o.isCompleted=0 and o.rateid='" + cboDestination.SelectedValue +"' order by o.oid desc";
                
                //}
                dataGridView1.DataSource = Connection.Instance.ShowDataInGridView(query);
                //dataGridView1.Columns[0].Width = 110;
                //dataGridView1.Columns[1].Width = 120;
                //dataGridView1.Columns[2].Width = 250;
                //dataGridView1.Columns[3].Width = 135;
                //dataGridView1.Columns[4].Width = 200;
            }
            catch { }
        }

        private void cboDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtReason.Text = "";
            GridShow();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtReason.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the reason for cancellation");
                txtReason.Focus();
            }
            else if(dataGridView1.SelectedRows.Count==0)
            {
                MessageBox.Show("Please select an order to cancel");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to cancel this order?", "Order Cancellation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    string query = "insert into OrderCancellation values(GETDATE(),'" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "','" + txtReason.Text.Trim() + "')";
                    Connection.Instance.ExecuteQueries(query);

                    query = "update v set isAvailable=1 from Vehicles v inner join Orders o on o.vehicleid=v.vehicleid where o.oid='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
                        Connection.Instance.ExecuteQueries(query);
                        query = "update orders set isCompleted=1,isCancelled=1 where oid='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "'";
                        Connection.Instance.ExecuteQueries(query);
                        btnRefresh_Click(null, null);
                }
            }

        }
    }
}
