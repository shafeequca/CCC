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
    public partial class Owners : Form
    {
        public Owners()
        {
            InitializeComponent();
            this.txtOwner.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOwner_KeyDown);
            this.txtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhone_KeyDown);
            this.txtPhone.KeyPress += new KeyPressEventHandler(NumberOnly_KeyPress);

        }

        private void NumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar == 8 || e.KeyChar == 13 || (e.KeyChar >= 48 && e.KeyChar <= 57)))
                e.Handled = true;
        }
        private void txtOwner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtAddress.Focus();
            }

        }
        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnSave_Click(null,null);
            }

        }
        private void Owners_Load(object sender, EventArgs e)
        {
            GridShow();
        }
         private void GridShow()
        {
            try
            {
                string query = "select * from Owners where Owner_name like '%" + txtSearch.Text.Trim() + "%'";
                dataGridView1.DataSource = Connection.Instance.ShowDataInGridView(query);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
            }
            catch { }
        }

         private void btnSave_Click(object sender, EventArgs e)
         {
             if (lblID.Text.Trim() == "")
             {
                 //Insert
                 if (txtOwner.Text.Trim() == "")
                     MessageBox.Show("Please enter the owner name");
                 else
                 {
                     DialogResult dialogResult = MessageBox.Show("Do you want to save the owner?", "Owner Master", MessageBoxButtons.YesNo);
                     if (dialogResult == DialogResult.Yes)
                     {
                         string query = "insert into Owners values('" + txtOwner.Text.Trim() + "','" + txtAddress.Text.Trim() + "','" + txtPhone.Text.Trim() + "')";
                         Connection.Instance.ExecuteQueries(query);
                         GridShow();
                         btnClear_Click(null, null);
                     }
                 }

             }
             else
             {
                 //Update
                 if (txtOwner.Text.Trim() == "")
                     MessageBox.Show("Please enter the owner name");
                 else
                 {
                     DialogResult dialogResult = MessageBox.Show("Do you want to save the owner", "Owner Master", MessageBoxButtons.YesNo);
                     if (dialogResult == DialogResult.Yes)
                     {
                         string query = "update Owners set Owner_name='" + txtOwner.Text.Trim() + "',Owner_Address='" + txtAddress.Text.Trim() + "',Owner_Phone='" + txtPhone.Text.Trim() + "' where ownid='" + lblID.Text.Trim() + "'";
                         Connection.Instance.ExecuteQueries(query);
                         GridShow();
                         btnClear_Click(null, null);
                     }
                 }
             }
         }

         private void btnDelete_Click(object sender, EventArgs e)
         {
             if (lblID.Text.Trim() == "")
                 MessageBox.Show("No item selected to delete");
             else
             {
                 DialogResult dialogResult = MessageBox.Show("All data under this owner would be deleted. Do you want to delete the owner", "Owner Master", MessageBoxButtons.YesNo);
                 if (dialogResult == DialogResult.Yes)
                 {
                     string query = "Delete from Owners where ownid='" + lblID.Text.Trim() + "'";
                     Connection.Instance.ExecuteQueries(query);
                     GridShow();
                     btnClear_Click(null, null);
                 }
             }
         }

         private void txtSearch_TextChanged(object sender, EventArgs e)
         {
             GridShow();
         }

         private void btnClear_Click(object sender, EventArgs e)
         {
             lblID.Text = "";
             txtOwner.Text = "";
             txtAddress.Text = "";
             txtPhone.Text = "";
             txtSearch.Text = "";
             txtOwner.Focus();
         }

        
         private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
         {
             if (e.RowIndex >= 0)
             {
                 lblID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                 txtOwner.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                 txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                 txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
             }
         }

         private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {

         }
    }
}
