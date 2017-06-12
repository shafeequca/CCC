namespace CCCTurn
{
    partial class menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mastersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesVoucherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cashEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saleSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allottmentDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.fileToolStripMenuItem,
            this.mastersToolStripMenuItem,
            this.transactionsToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(694, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mastersToolStripMenuItem
            // 
            this.mastersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.areaToolStripMenuItem,
            this.customerMasterToolStripMenuItem,
            this.itemMasterToolStripMenuItem});
            this.mastersToolStripMenuItem.Name = "mastersToolStripMenuItem";
            this.mastersToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.mastersToolStripMenuItem.Text = "Masters";
            // 
            // areaToolStripMenuItem
            // 
            this.areaToolStripMenuItem.Name = "areaToolStripMenuItem";
            this.areaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.areaToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.areaToolStripMenuItem.Text = "Owner Master";
            this.areaToolStripMenuItem.Click += new System.EventHandler(this.areaToolStripMenuItem_Click);
            // 
            // customerMasterToolStripMenuItem
            // 
            this.customerMasterToolStripMenuItem.Name = "customerMasterToolStripMenuItem";
            this.customerMasterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.customerMasterToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.customerMasterToolStripMenuItem.Text = "Vehicle Entry";
            this.customerMasterToolStripMenuItem.Click += new System.EventHandler(this.customerMasterToolStripMenuItem_Click);
            // 
            // itemMasterToolStripMenuItem
            // 
            this.itemMasterToolStripMenuItem.Name = "itemMasterToolStripMenuItem";
            this.itemMasterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.itemMasterToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.itemMasterToolStripMenuItem.Text = "Destination / Party";
            this.itemMasterToolStripMenuItem.Click += new System.EventHandler(this.itemMasterToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesVoucherToolStripMenuItem,
            this.addStockToolStripMenuItem,
            this.cashEntryToolStripMenuItem});
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            // 
            // salesVoucherToolStripMenuItem
            // 
            this.salesVoucherToolStripMenuItem.Name = "salesVoucherToolStripMenuItem";
            this.salesVoucherToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.salesVoucherToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.salesVoucherToolStripMenuItem.Text = "Order Entry";
            this.salesVoucherToolStripMenuItem.Click += new System.EventHandler(this.salesVoucherToolStripMenuItem_Click);
            // 
            // addStockToolStripMenuItem
            // 
            this.addStockToolStripMenuItem.Name = "addStockToolStripMenuItem";
            this.addStockToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.addStockToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.addStockToolStripMenuItem.Text = "Order Cancellation";
            this.addStockToolStripMenuItem.Click += new System.EventHandler(this.addStockToolStripMenuItem_Click);
            // 
            // cashEntryToolStripMenuItem
            // 
            this.cashEntryToolStripMenuItem.Name = "cashEntryToolStripMenuItem";
            this.cashEntryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.cashEntryToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.cashEntryToolStripMenuItem.Text = "Order Delivery";
            this.cashEntryToolStripMenuItem.Click += new System.EventHandler(this.cashEntryToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saleSheetToolStripMenuItem,
            this.orderedItemsToolStripMenuItem,
            this.allottmentDetailToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // saleSheetToolStripMenuItem
            // 
            this.saleSheetToolStripMenuItem.Name = "saleSheetToolStripMenuItem";
            this.saleSheetToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.saleSheetToolStripMenuItem.Text = "Allottment Details";
            this.saleSheetToolStripMenuItem.Click += new System.EventHandler(this.saleSheetToolStripMenuItem_Click);
            // 
            // orderedItemsToolStripMenuItem
            // 
            this.orderedItemsToolStripMenuItem.Name = "orderedItemsToolStripMenuItem";
            this.orderedItemsToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.orderedItemsToolStripMenuItem.Text = "Cancelled Orders";
            this.orderedItemsToolStripMenuItem.Click += new System.EventHandler(this.orderedItemsToolStripMenuItem_Click);
            // 
            // allottmentDetailToolStripMenuItem
            // 
            this.allottmentDetailToolStripMenuItem.Name = "allottmentDetailToolStripMenuItem";
            this.allottmentDetailToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.allottmentDetailToolStripMenuItem.Text = "Allottment Details(Date Wise) ";
            this.allottmentDetailToolStripMenuItem.Click += new System.EventHandler(this.allottmentDetailToolStripMenuItem_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(694, 358);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CCC Turn V.1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mastersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem areaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesVoucherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cashEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saleSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderedItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allottmentDetailToolStripMenuItem;
    }
}