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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();
            foreach (Form f in Application.OpenForms)
                openForms.Add(f);
            foreach (Form f in openForms)
            {
                if (f.Name != "menu")
                    f.Close();
            }
            Login frm = new Login();
            frm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void areaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();
            foreach (Form f in Application.OpenForms)
                openForms.Add(f);
            foreach (Form f in openForms)
            {
                if (f.Name == "Owners")
                {
                    f.Activate();
                    return;
                }
            }
            Owners frm = new Owners();
            frm.Show(this);
        }

        private void customerMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();
            foreach (Form f in Application.OpenForms)
                openForms.Add(f);
            foreach (Form f in openForms)
            {
                if (f.Name == "Vehicle")
                {
                    f.Activate();
                    return;
                }
            }
            Vehicle frm = new Vehicle();
            frm.Show(this);
        }

        private void itemMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();
            foreach (Form f in Application.OpenForms)
                openForms.Add(f);
            foreach (Form f in openForms)
            {
                if (f.Name == "Locations")
                {
                    f.Activate();
                    return;
                }
            }
            Locations frm = new Locations();
            frm.Show(this);
        }

        private void salesVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();
            foreach (Form f in Application.OpenForms)
                openForms.Add(f);
            foreach (Form f in openForms)
            {
                if (f.Name == "Orders")
                {
                    f.Activate();
                    return;
                }
            }
            Orders frm = new Orders();
            frm.Show(this);
        }

        private void addStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();
            foreach (Form f in Application.OpenForms)
                openForms.Add(f);
            foreach (Form f in openForms)
            {
                if (f.Name == "OrderCancellation")
                {
                    f.Activate();
                    return;
                }
            }
            OrderCancellation frm = new OrderCancellation();
            frm.Show(this);
        }

        private void cashEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();
            foreach (Form f in Application.OpenForms)
                openForms.Add(f);
            foreach (Form f in openForms)
            {
                if (f.Name == "VehicleReturn")
                {
                    f.Activate();
                    return;
                }
            }
            VehicleReturn frm = new VehicleReturn();
            frm.Show(this);
        }

        private void saleSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();
            foreach (Form f in Application.OpenForms)
                openForms.Add(f);
            foreach (Form f in openForms)
            {
                if (f.Name == "AllotmentDetails")
                {
                    f.Activate();
                    return;
                }
            }
            AllotmentDetails frm = new AllotmentDetails();
            frm.Show(this);
        }

        private void orderedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            List<Form> openForms = new List<Form>();
            foreach (Form f in Application.OpenForms)
                openForms.Add(f);
            foreach (Form f in openForms)
            {
                if (f.Name == "CancellationDetails")
                {
                    f.Activate();
                    return;
                }
            }
            CancellationDetails frm = new CancellationDetails();
            frm.Show(this);
        }

        private void menu_Load(object sender, EventArgs e)
        {
            DateTime dt=new DateTime(2017,08,01);
            if (DateTime.Now > dt)
            {
                MessageBox.Show("dll expired. please update with latest version");
                Application.Exit();
                
            }
            Login frm = new Login();
            frm.ShowDialog();
        }
    }
}
