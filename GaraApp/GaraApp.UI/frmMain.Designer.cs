namespace GaraApp.UI
{
    partial class frmMain
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
            menuMain = new MenuStrip();
            mnuCatalog = new ToolStripMenuItem();
            mnuCustomers = new ToolStripMenuItem();
            mnuCars = new ToolStripMenuItem();
            mnuParts = new ToolStripMenuItem();
            mnuServices = new ToolStripMenuItem();
            mnuBusiness = new ToolStripMenuItem();
            mnuRepairOrders = new ToolStripMenuItem();
            mnuReports = new ToolStripMenuItem();
            mnuRevenue = new ToolStripMenuItem();
            mnuSystem = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            menuMain.SuspendLayout();
            SuspendLayout();
            // 
            // menuMain
            // 
            menuMain.ImageScalingSize = new Size(20, 20);
            menuMain.Items.AddRange(new ToolStripItem[] { mnuCatalog, mnuBusiness, mnuReports, mnuSystem });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(907, 28);
            menuMain.TabIndex = 0;
            menuMain.Text = "menuStrip1";
            // 
            // mnuCatalog
            // 
            mnuCatalog.DropDownItems.AddRange(new ToolStripItem[] { mnuCustomers, mnuCars, mnuParts, mnuServices });
            mnuCatalog.Name = "mnuCatalog";
            mnuCatalog.Size = new Size(90, 24);
            mnuCatalog.Text = "Danh mục";
            // 
            // mnuCustomers
            // 
            mnuCustomers.Name = "mnuCustomers";
            mnuCustomers.Size = new Size(169, 26);
            mnuCustomers.Text = "Khách hàng";
            mnuCustomers.Click += mnuCustomers_Click;
            // 
            // mnuCars
            // 
            mnuCars.Name = "mnuCars";
            mnuCars.Size = new Size(169, 26);
            mnuCars.Text = "Xe";
            mnuCars.Click += mnuCars_Click;
            // 
            // mnuParts
            // 
            mnuParts.Name = "mnuParts";
            mnuParts.Size = new Size(169, 26);
            mnuParts.Text = "Phụ tùng";
            mnuParts.Click += mnuParts_Click;
            // 
            // mnuServices
            // 
            mnuServices.Name = "mnuServices";
            mnuServices.Size = new Size(169, 26);
            mnuServices.Text = "Dịch vụ";
            mnuServices.Click += mnuServices_Click;
            // 
            // mnuBusiness
            // 
            mnuBusiness.DropDownItems.AddRange(new ToolStripItem[] { mnuRepairOrders });
            mnuBusiness.Name = "mnuBusiness";
            mnuBusiness.Size = new Size(91, 24);
            mnuBusiness.Text = "Nghiệp vụ";
            // 
            // mnuRepairOrders
            // 
            mnuRepairOrders.Name = "mnuRepairOrders";
            mnuRepairOrders.Size = new Size(191, 26);
            mnuRepairOrders.Text = "Phiếu sửa chữa";
            mnuRepairOrders.Click += mnuRepairOrders_Click;
            // 
            // mnuReports
            // 
            mnuReports.DropDownItems.AddRange(new ToolStripItem[] { mnuRevenue });
            mnuReports.Name = "mnuReports";
            mnuReports.Size = new Size(77, 24);
            mnuReports.Text = "Báo cáo";
            // 
            // mnuRevenue
            // 
            mnuRevenue.Name = "mnuRevenue";
            mnuRevenue.Size = new Size(224, 26);
            mnuRevenue.Text = "Doanh thu";
            mnuRevenue.Click += mnuRevenue_Click;
            // 
            // mnuSystem
            // 
            mnuSystem.DropDownItems.AddRange(new ToolStripItem[] { mnuExit });
            mnuSystem.Name = "mnuSystem";
            mnuSystem.Size = new Size(85, 24);
            mnuSystem.Text = "Hệ thống";
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(224, 26);
            mnuExit.Text = "Thoát";
            mnuExit.Click += mnuExit_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(907, 518);
            Controls.Add(menuMain);
            MainMenuStrip = menuMain;
            Name = "frmMain";
            Text = "Gara Management";
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuMain;
        private ToolStripMenuItem mnuCatalog;
        private ToolStripMenuItem mnuBusiness;
        private ToolStripMenuItem mnuCustomers;
        private ToolStripMenuItem mnuCars;
        private ToolStripMenuItem mnuParts;
        private ToolStripMenuItem mnuServices;
        private ToolStripMenuItem mnuRepairOrders;
        private ToolStripMenuItem mnuReports;
        private ToolStripMenuItem mnuRevenue;
        private ToolStripMenuItem mnuSystem;
        private ToolStripMenuItem mnuExit;
    }
}