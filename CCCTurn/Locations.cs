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
    public partial class Locations : Form
    {
        public Locations()
        {
            InitializeComponent();
            this.txt20DA.KeyPress += new KeyPressEventHandler(NumberOnly_KeyPress);
            this.txt40DA.KeyPress += new KeyPressEventHandler(NumberOnly_KeyPress);
            this.txt20Trailor.KeyPress += new KeyPressEventHandler(NumberOnly_KeyPress);
            this.txt40Trailor.KeyPress += new KeyPressEventHandler(NumberOnly_KeyPress);
            this.txt20Multi.KeyPress += new KeyPressEventHandler(NumberOnly_KeyPress);
            this.txt40multi.KeyPress += new KeyPressEventHandler(NumberOnly_KeyPress);
            this.txtDestination.KeyPress += new KeyPressEventHandler(txtDestination_KeyPress);

        }
        private void txtDestination_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt20DA.Focus();
            }
        }

        private void NumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 13 || (e.KeyChar >= 48 && e.KeyChar <= 57)))
                e.Handled = true;
            TextBox tb = sender as TextBox;
            if (e.KeyChar == 13)
            {
                if (tb.Name == "txt20DA")
                    txt40DA.Focus();
                else if (tb.Name == "txt40DA")
                    txt20Trailor.Focus();
                else if (tb.Name == "txt20Trailor")
                    txt40Trailor.Focus();
                else if (tb.Name == "txt40Trailor")
                    txt20Multi.Focus();
                else if (tb.Name == "txt20Multi")
                    txt40multi.Focus();
                else if (tb.Name == "txt40multi")
                    btnSave_Click(null, null);

            }
        }

        private void Locations_Load(object sender, EventArgs e)
        {

            GridShow();
        }
        private void GridShow()
        {
            try
            {
                string query = "select Location as Destinations,* from Rate where Location like '%" + txtSearch.Text.Trim() + "%'";
                dataGridView1.DataSource = Connection.Instance.ShowDataInGridView(query);
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblID.Text.Trim() == "")
            {
                //Insert
                if (txtDestination.Text.Trim() == "")
                    MessageBox.Show("Please enter the destination");
                else if (txt20DA.Text.Trim() == "" || txt20Trailor.Text.Trim() == "" || txt20Multi.Text.Trim() == "" || txt40DA.Text.Trim() == "" || txt40Trailor.Text.Trim() == "" || txt40multi.Text.Trim() == "")
                    MessageBox.Show("Please enter the rates");
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to save the destination?", "Destination Master", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string query = "insert into Rate values('" + txtDestination.Text.Trim() + "','" + txt20DA.Text.Trim() + "','" + txt20Trailor.Text.Trim() + "','" + txt20Multi.Text.Trim() + "','" + txt40DA.Text.Trim() + "','" + txt40Trailor.Text.Trim() + "','" + txt40multi.Text.Trim() + "')";
                        Connection.Instance.ExecuteQueries(query);
                        GridShow();
                        btnClear_Click(null, null);
                    }
                }

            }
            else
            {
                //Update
                if (txtDestination.Text.Trim() == "")
                    MessageBox.Show("Please enter the destination");
                else if (txt20DA.Text.Trim() == "" || txt20Trailor.Text.Trim() == "" || txt20Multi.Text.Trim() == "" || txt40DA.Text.Trim() == "" || txt40Trailor.Text.Trim() == "" || txt40multi.Text.Trim() == "")
                    MessageBox.Show("Please enter the rates");
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to save the destination", "Destination Master", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string query = "update Rate set Location='" + txtDestination.Text.Trim() + "',Rate_20_DA='" + txt20DA.Text.Trim() + "',Rate_20_Trailor='" + txt20Trailor.Text.Trim() + "',Rate_20_Multi='" + txt20Multi.Text.Trim() + "',Rate_40_DA='" + txt40DA.Text.Trim() + "',Rate_40_Trailor='" + txt40Trailor.Text.Trim() + "',Rate_40_Multi='" + txt40multi.Text.Trim() + "' where rateid='"+ lblID.Text +"'";
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
            txtDestination.Text = "";
            txt20DA.Text = "";
            txt20Trailor.Text = "";
            txt20Multi.Text = "";
            txt40DA.Text = "";
            txt40Trailor.Text = "";
            txt40multi.Text = "";
            txtSearch.Text = "";
            txtDestination.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblID.Text.Trim() == "")
                MessageBox.Show("No item selected to delete");
            else
            {
                DialogResult dialogResult = MessageBox.Show("All data under this destination would be deleted. Do you want to delete the destination", "Destination Master", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string query = "Delete from rate where rateid='" + lblID.Text.Trim() + "'";
                    Connection.Instance.ExecuteQueries(query);
                    GridShow();
                    btnClear_Click(null, null);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                lblID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDestination.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txt20DA.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txt20Trailor.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txt20Multi.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txt40DA.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txt40Trailor.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txt40multi.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtDestination.Focus();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            GridShow();
        }
    }
}
