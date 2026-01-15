namespace GaraApp.UI
{
    partial class frmService
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
            grpSearch = new GroupBox();
            btnReload = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblServiceName1 = new Label();
            dataGridView1 = new DataGridView();
            serviceIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            serviceNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            basePriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            serviceBindingSource = new BindingSource(components);
            grpInfo = new GroupBox();
            nudBasePrice = new NumericUpDown();
            lblBasePrice = new Label();
            txtServiceName = new TextBox();
            lblServiceName2 = new Label();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            grpSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serviceBindingSource).BeginInit();
            grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudBasePrice).BeginInit();
            SuspendLayout();
            // 
            // grpSearch
            // 
            grpSearch.Controls.Add(btnReload);
            grpSearch.Controls.Add(btnSearch);
            grpSearch.Controls.Add(txtSearch);
            grpSearch.Controls.Add(lblServiceName1);
            grpSearch.Location = new Point(12, 12);
            grpSearch.Name = "grpSearch";
            grpSearch.Size = new Size(708, 125);
            grpSearch.TabIndex = 0;
            grpSearch.TabStop = false;
            grpSearch.Text = "Tìm";
            // 
            // btnReload
            // 
            btnReload.Location = new Point(520, 47);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(94, 29);
            btnReload.TabIndex = 7;
            btnReload.Text = "Tải lại";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += lblKeyword_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(407, 46);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += lblKeyword_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(213, 48);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(179, 27);
            txtSearch.TabIndex = 5;
            // 
            // lblServiceName1
            // 
            lblServiceName1.Anchor = AnchorStyles.None;
            lblServiceName1.Location = new Point(126, 43);
            lblServiceName1.Name = "lblServiceName1";
            lblServiceName1.Size = new Size(91, 36);
            lblServiceName1.TabIndex = 4;
            lblServiceName1.Text = "Tên dịch vụ:";
            lblServiceName1.TextAlign = ContentAlignment.MiddleLeft;
            lblServiceName1.Click += lblKeyword_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { serviceIdDataGridViewTextBoxColumn, serviceNameDataGridViewTextBoxColumn, basePriceDataGridViewTextBoxColumn });
            dataGridView1.DataSource = serviceBindingSource;
            dataGridView1.Location = new Point(17, 156);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(703, 202);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // serviceIdDataGridViewTextBoxColumn
            // 
            serviceIdDataGridViewTextBoxColumn.DataPropertyName = "ServiceId";
            serviceIdDataGridViewTextBoxColumn.HeaderText = "ServiceId";
            serviceIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            serviceIdDataGridViewTextBoxColumn.Name = "serviceIdDataGridViewTextBoxColumn";
            serviceIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // serviceNameDataGridViewTextBoxColumn
            // 
            serviceNameDataGridViewTextBoxColumn.DataPropertyName = "ServiceName";
            serviceNameDataGridViewTextBoxColumn.HeaderText = "ServiceName";
            serviceNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            serviceNameDataGridViewTextBoxColumn.Name = "serviceNameDataGridViewTextBoxColumn";
            serviceNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // basePriceDataGridViewTextBoxColumn
            // 
            basePriceDataGridViewTextBoxColumn.DataPropertyName = "BasePrice";
            basePriceDataGridViewTextBoxColumn.HeaderText = "BasePrice";
            basePriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            basePriceDataGridViewTextBoxColumn.Name = "basePriceDataGridViewTextBoxColumn";
            basePriceDataGridViewTextBoxColumn.Width = 125;
            // 
            // serviceBindingSource
            // 
            serviceBindingSource.DataSource = typeof(Entities.Service);
            // 
            // grpInfo
            // 
            grpInfo.Controls.Add(btnClear);
            grpInfo.Controls.Add(btnDelete);
            grpInfo.Controls.Add(btnUpdate);
            grpInfo.Controls.Add(btnAdd);
            grpInfo.Controls.Add(nudBasePrice);
            grpInfo.Controls.Add(lblBasePrice);
            grpInfo.Controls.Add(txtServiceName);
            grpInfo.Controls.Add(lblServiceName2);
            grpInfo.Location = new Point(17, 391);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(703, 125);
            grpInfo.TabIndex = 2;
            grpInfo.TabStop = false;
            grpInfo.Text = "Thông tin";
            // 
            // nudBasePrice
            // 
            nudBasePrice.DecimalPlaces = 2;
            nudBasePrice.Location = new Point(274, 51);
            nudBasePrice.Name = "nudBasePrice";
            nudBasePrice.Size = new Size(150, 27);
            nudBasePrice.TabIndex = 22;
            // 
            // lblBasePrice
            // 
            lblBasePrice.AutoSize = true;
            lblBasePrice.Location = new Point(237, 53);
            lblBasePrice.Name = "lblBasePrice";
            lblBasePrice.Size = new Size(31, 20);
            lblBasePrice.TabIndex = 2;
            lblBasePrice.Text = "Giá";
            // 
            // txtServiceName
            // 
            txtServiceName.Location = new Point(72, 50);
            txtServiceName.Name = "txtServiceName";
            txtServiceName.Size = new Size(125, 27);
            txtServiceName.TabIndex = 21;
            // 
            // lblServiceName2
            // 
            lblServiceName2.AutoSize = true;
            lblServiceName2.Location = new Point(10, 53);
            lblServiceName2.Name = "lblServiceName2";
            lblServiceName2.Size = new Size(56, 20);
            lblServiceName2.TabIndex = 0;
            lblServiceName2.Text = "Tên DV";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(585, 69);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 34;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += lblKeyword_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(485, 69);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 33;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += lblKeyword_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(585, 24);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 32;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += lblKeyword_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(485, 24);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 31;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += lblKeyword_Click;
            // 
            // frmService
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 553);
            Controls.Add(grpInfo);
            Controls.Add(dataGridView1);
            Controls.Add(grpSearch);
            Name = "frmService";
            Text = "Dịch vụ";
            Load += frmService_Load;
            grpSearch.ResumeLayout(false);
            grpSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)serviceBindingSource).EndInit();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudBasePrice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpSearch;
        private Button btnReload;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lblServiceName1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn serviceIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn serviceNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn basePriceDataGridViewTextBoxColumn;
        private BindingSource serviceBindingSource;
        private GroupBox grpInfo;
        private Label lblServiceName2;
        private NumericUpDown nudBasePrice;
        private Label lblBasePrice;
        private TextBox txtServiceName;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
    }
}