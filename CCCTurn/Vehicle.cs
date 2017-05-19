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
    public partial class Vehicle : Form
    {
        public Vehicle()
        {
            InitializeComponent();
            this.txtPhone.KeyPress += new KeyPressEventHandler(NumberOnly_KeyPress);

        }

        private void NumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == 8 || e.KeyChar == 13 || (e.KeyChar >= 48 && e.KeyChar <= 57)))
                e.Handled = true;
        }

        private void Vehicle_Load(object sender, EventArgs e)
        {
            comboLoad();
            GridShow();
            cboOwner.SelectedIndex = -1;
            cboType.SelectedIndex = 0;
        }
        private void comboLoad()
        {
            string query = "select ownid,Owner_Name from Owners order By Owner_Name";
            cboOwner.DataSource = Connection.Instance.ShowDataInGridView(query);
            cboOwner.DisplayMember = "Owner_Name";
            cboOwner.ValueMember = "ownid";

        }
        private void GridShow()
        {
            try
            {
                string query = "select v.*,o.Owner_Name from Vehicles v, owners o where v.ownid=o.ownid and v.Vehicle_Number like '%" + txtSearch.Text.Trim() + "%'  order by o.ownid,v.Vehicle_Number";
                dataGridView1.DataSource = Connection.Instance.ShowDataInGridView(query);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblID.Text.Trim() == "")
            {
                //Insert
                if (txtVehicle.Text.Trim() == "")
                    MessageBox.Show("Please enter the Vehicle name");
                else if (txtVehicleNumber.Text.Trim() == "")
                    MessageBox.Show("Please enter the Vehicle number");
                else if (cboOwner.SelectedIndex<0)
                    MessageBox.Show("Please select an owner");
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to save the Vehicle?", "Vehicle Master", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {

                        string query = "select max(availability_order) from Vehicles";
                        DataTable dt = (DataTable)Connection.Instance.ShowDataInGridView(query);
                        int availability_order = 1;
                        if (dt.Rows.Count > 0)
                        {
                            availability_order = Convert.ToInt32(dt.Rows[0][0].ToString() == "" ? "0" : dt.Rows[0][0].ToString()) + 1;
                        }
                        query = "insert into Vehicles values('" + txtVehicle.Text.Trim() + "','" + txtVehicleNumber.Text.Trim() + "','" + cboOwner.SelectedValue + "','" + cboType.Text + "','" + txtDriver.Text.Trim() + "','" + txtAddress.Text.Trim() + "','" + txtPhone.Text.Trim() + "','" + chkActive.Checked + "',1,'" + availability_order + "')";
                        Connection.Instance.ExecuteQueries(query);
                        GridShow();
                        btnClear_Click(null, null);
                    }
                }

            }
            else
            {
                //Update
                if (txtVehicle.Text.Trim() == "")
                    MessageBox.Show("Please enter the Vehicle name");
                else if (txtVehicleNumber.Text.Trim() == "")
                    MessageBox.Show("Please enter the Vehicle number");
                else if (cboOwner.SelectedIndex < 0)
                    MessageBox.Show("Please select an owner");
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to save the vehicle", "Vehicle Master", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string query = "update Vehicles set Vehicle_name='" + txtVehicle.Text.Trim() + "',Vehicle_Number='" + txtVehicleNumber.Text.Trim() + "',ownid='" + cboOwner.SelectedValue + "',Vehicle_Type='" + cboType.Text + "',Vehicle_Driver='" + txtDriver.Text.Trim() + "',Driver_Address='" + txtAddress.Text.Trim() + "',Driver_phone='" + txtPhone.Text.Trim() + "',isActive='" + chkActive.Checked + "' where vehicleid='"+ lblID.Text +"'";
                        Connection.Instance.ExecuteQueries(query);
                        GridShow();
                        btnClear_Click(null, null);
                    }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblID.Text = "";
            txtVehicle.Text = "";
            txtVehicleNumber.Text = "";
            comboLoad();
            if(cboOwner.Items.Count>0)
                cboOwner.SelectedIndex = 0;
            cboType.SelectedIndex = 0;
            txtDriver.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtSearch.Text = "";
            chkActive.Checked = true;
            cboOwner.SelectedIndex = -1;
            txtVehicle.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lblID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtVehicle.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtVehicleNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                cboOwner.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                cboType.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtDriver.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                chkActive.Checked = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GridShow();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblID.Text.Trim() == "")
                MessageBox.Show("No item selected to delete");
            else
            {
                DialogResult dialogResult = MessageBox.Show("All data under this vehicle would be deleted. Do you want to delete the vehicle", "Vehicle Master", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string query = "Delete from vehicles where vehicleid='" + lblID.Text.Trim() + "'";
                    Connection.Instance.ExecuteQueries(query);
                    GridShow();
                    btnClear_Click(null, null);
                }
            }
        }
    }
}
