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
    public partial class VehicleTurnList : Form
    {
        public string vehType;
        public Orders ord;
        public VehicleTurnList()
        {
            InitializeComponent();
        }

        private void VehicleTurnList_Load(object sender, EventArgs e)
        {
            try
            {
                string query = "select v.vehicleid,v.availability_order as Turn_Order,v.Vehicle_Number,o.Owner_Name from Vehicles v, owners o where v.ownid=o.ownid and Vehicle_Type='" + vehType + "' and isAvailable=1 and isActive=1 order by v.availability_order";
                
                dataGridView1.DataSource = Connection.Instance.ShowDataInGridView(query);
                dataGridView1.Columns[0].Visible = false;
                
            }
            catch
            {
               
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ord.setVehicle(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                this.Close();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
