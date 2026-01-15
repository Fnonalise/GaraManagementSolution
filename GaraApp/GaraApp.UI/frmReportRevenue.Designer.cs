namespace GaraApp.UI
{
    partial class frmReportRevenue
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
            components = new System.ComponentModel.Container();
            grpFilter = new GroupBox();
            btnRun = new Button();
            dtpTo = new DateTimePicker();
            dtpFrom = new DateTimePicker();
            lblTo = new Label();
            lblFrom = new Label();
            dgvRevenue = new DataGridView();
            grpSummary = new GroupBox();
            lblSumRevenue = new Label();
            lblSumOrders = new Label();
            reportServiceBindingSource = new BindingSource(components);
            grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRevenue).BeginInit();
            grpSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)reportServiceBindingSource).BeginInit();
            SuspendLayout();
            // 
            // grpFilter
            // 
            grpFilter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpFilter.Controls.Add(btnRun);
            grpFilter.Controls.Add(dtpTo);
            grpFilter.Controls.Add(dtpFrom);
            grpFilter.Controls.Add(lblTo);
            grpFilter.Controls.Add(lblFrom);
            grpFilter.Location = new Point(21, 12);
            grpFilter.Name = "grpFilter";
            grpFilter.Size = new Size(949, 113);
            grpFilter.TabIndex = 0;
            grpFilter.TabStop = false;
            grpFilter.Text = "Bộ lọc";
            // 
            // btnRun
            // 
            btnRun.Location = new Point(769, 43);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(122, 29);
            btnRun.TabIndex = 4;
            btnRun.Text = "Chạy báo cáo";
            btnRun.UseVisualStyleBackColor = true;
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(466, 42);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(250, 27);
            dtpTo.TabIndex = 3;
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(95, 42);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(250, 27);
            dtpFrom.TabIndex = 2;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Location = new Point(388, 47);
            lblTo.Name = "lblTo";
            lblTo.Size = new Size(72, 20);
            lblTo.TabIndex = 1;
            lblTo.Text = "Đến ngày";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(27, 47);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(62, 20);
            lblFrom.TabIndex = 0;
            lblFrom.Text = "Từ ngày";
            // 
            // dgvRevenue
            // 
            dgvRevenue.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRevenue.AutoGenerateColumns = false;
            dgvRevenue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRevenue.DataSource = reportServiceBindingSource;
            dgvRevenue.Location = new Point(21, 152);
            dgvRevenue.Name = "dgvRevenue";
            dgvRevenue.RowHeadersWidth = 51;
            dgvRevenue.Size = new Size(949, 290);
            dgvRevenue.TabIndex = 1;
            // 
            // grpSummary
            // 
            grpSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpSummary.Controls.Add(lblSumRevenue);
            grpSummary.Controls.Add(lblSumOrders);
            grpSummary.Location = new Point(21, 466);
            grpSummary.Name = "grpSummary";
            grpSummary.Size = new Size(949, 125);
            grpSummary.TabIndex = 2;
            grpSummary.TabStop = false;
            grpSummary.Text = "Tổng hợp";
            // 
            // lblSumRevenue
            // 
            lblSumRevenue.AutoSize = true;
            lblSumRevenue.Location = new Point(432, 61);
            lblSumRevenue.Name = "lblSumRevenue";
            lblSumRevenue.Size = new Size(117, 20);
            lblSumRevenue.TabIndex = 1;
            lblSumRevenue.Text = "Tổng doanh thu:";
            // 
            // lblSumOrders
            // 
            lblSumOrders.AutoSize = true;
            lblSumOrders.Location = new Point(74, 61);
            lblSumOrders.Name = "lblSumOrders";
            lblSumOrders.Size = new Size(87, 20);
            lblSumOrders.TabIndex = 0;
            lblSumOrders.Text = "Tổng phiếu:";
            // 
            // reportServiceBindingSource
            // 
            reportServiceBindingSource.DataSource = typeof(BLL.ReportService);
            // 
            // frmReportRevenue
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(grpSummary);
            Controls.Add(dgvRevenue);
            Controls.Add(grpFilter);
            Name = "frmReportRevenue";
            Text = "Báo cáo doanh thu";
            Load += frmReportRevenue_Load;
            grpFilter.ResumeLayout(false);
            grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRevenue).EndInit();
            grpSummary.ResumeLayout(false);
            grpSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)reportServiceBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpFilter;
        private DateTimePicker dtpTo;
        private DateTimePicker dtpFrom;
        private Label lblTo;
        private Label lblFrom;
        private Button btnRun;
        private DataGridView dgvRevenue;
        private GroupBox grpSummary;
        private Label lblSumRevenue;
        private Label lblSumOrders;
        private BindingSource reportServiceBindingSource;
    }
}