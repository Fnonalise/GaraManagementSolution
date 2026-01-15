namespace GaraApp.UI
{
    partial class frmPart
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
            dgvParts = new DataGridView();
            btnReload = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblKeyword = new Label();
            btnLowStock = new Button();
            lblMinQty = new Label();
            nudStockQty = new NumericUpDown();
            lblStockQty = new Label();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            lblUnitPrice = new Label();
            txtUnit = new TextBox();
            lblUnit = new Label();
            txtPartName = new TextBox();
            lblPartName = new Label();
            txtPartId = new TextBox();
            lblPartId = new Label();
            nudUnitPrice = new NumericUpDown();
            nudMinQty = new NumericUpDown();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            partBindingSource = new BindingSource(components);
            partIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            partNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            unitDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            unitPriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            stockQtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            minQtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvParts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStockQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudUnitPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMinQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)partBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvParts
            // 
            dgvParts.AutoGenerateColumns = false;
            dgvParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParts.Columns.AddRange(new DataGridViewColumn[] { partIdDataGridViewTextBoxColumn, partNameDataGridViewTextBoxColumn, unitDataGridViewTextBoxColumn, unitPriceDataGridViewTextBoxColumn, stockQtyDataGridViewTextBoxColumn, minQtyDataGridViewTextBoxColumn });
            dgvParts.DataSource = partBindingSource;
            dgvParts.Location = new Point(22, 89);
            dgvParts.Name = "dgvParts";
            dgvParts.RowHeadersWidth = 51;
            dgvParts.Size = new Size(766, 228);
            dgvParts.TabIndex = 32;
            dgvParts.CellContentClick += dgvParts_CellContentClick;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(487, 25);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(94, 29);
            btnReload.TabIndex = 3;
            btnReload.Text = "Tải lại";
            btnReload.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(387, 25);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(193, 27);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(179, 27);
            txtSearch.TabIndex = 1;
            // 
            // lblKeyword
            // 
            lblKeyword.Anchor = AnchorStyles.None;
            lblKeyword.Location = new Point(86, 21);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(101, 36);
            lblKeyword.TabIndex = 28;
            lblKeyword.Text = "Tên phụ tùng:";
            lblKeyword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnLowStock
            // 
            btnLowStock.Location = new Point(587, 25);
            btnLowStock.Name = "btnLowStock";
            btnLowStock.Size = new Size(114, 29);
            btnLowStock.TabIndex = 4;
            btnLowStock.Text = "Tồn kho thấp";
            btnLowStock.UseVisualStyleBackColor = true;
            // 
            // lblMinQty
            // 
            lblMinQty.Location = new Point(209, 406);
            lblMinQty.Name = "lblMinQty";
            lblMinQty.Size = new Size(42, 24);
            lblMinQty.TabIndex = 60;
            lblMinQty.Text = "Min";
            // 
            // nudStockQty
            // 
            nudStockQty.Location = new Point(103, 403);
            nudStockQty.Name = "nudStockQty";
            nudStockQty.Size = new Size(84, 27);
            nudStockQty.TabIndex = 25;
            // 
            // lblStockQty
            // 
            lblStockQty.AutoSize = true;
            lblStockQty.Location = new Point(42, 405);
            lblStockQty.Name = "lblStockQty";
            lblStockQty.Size = new Size(62, 20);
            lblStockQty.TabIndex = 59;
            lblStockQty.Text = "Tồn kho";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(696, 401);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 30;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(596, 401);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 29;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(496, 401);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 28;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(396, 401);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 27;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Location = new Point(559, 357);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(31, 20);
            lblUnitPrice.TabIndex = 58;
            lblUnitPrice.Text = "Giá";
            // 
            // txtUnit
            // 
            txtUnit.Location = new Point(410, 354);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(125, 27);
            txtUnit.TabIndex = 23;
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Location = new Point(343, 357);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(52, 20);
            lblUnit.TabIndex = 57;
            lblUnit.Text = "Đơn vị";
            // 
            // txtPartName
            // 
            txtPartName.Location = new Point(200, 354);
            txtPartName.Name = "txtPartName";
            txtPartName.Size = new Size(125, 27);
            txtPartName.TabIndex = 22;
            // 
            // lblPartName
            // 
            lblPartName.AutoSize = true;
            lblPartName.Location = new Point(140, 357);
            lblPartName.Name = "lblPartName";
            lblPartName.Size = new Size(52, 20);
            lblPartName.TabIndex = 56;
            lblPartName.Text = "Tên PT";
            // 
            // txtPartId
            // 
            txtPartId.Location = new Point(84, 354);
            txtPartId.Name = "txtPartId";
            txtPartId.ReadOnly = true;
            txtPartId.Size = new Size(42, 27);
            txtPartId.TabIndex = 21;
            // 
            // lblPartId
            // 
            lblPartId.AutoSize = true;
            lblPartId.Location = new Point(24, 357);
            lblPartId.Name = "lblPartId";
            lblPartId.Size = new Size(50, 20);
            lblPartId.TabIndex = 54;
            lblPartId.Text = "Mã PT";
            // 
            // nudUnitPrice
            // 
            nudUnitPrice.DecimalPlaces = 2;
            nudUnitPrice.Location = new Point(598, 354);
            nudUnitPrice.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudUnitPrice.Name = "nudUnitPrice";
            nudUnitPrice.Size = new Size(150, 27);
            nudUnitPrice.TabIndex = 24;
            // 
            // nudMinQty
            // 
            nudMinQty.Location = new Point(257, 403);
            nudMinQty.Name = "nudMinQty";
            nudMinQty.Size = new Size(104, 27);
            nudMinQty.TabIndex = 26;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // partBindingSource
            // 
            partBindingSource.DataSource = typeof(Entities.Part);
            // 
            // partIdDataGridViewTextBoxColumn
            // 
            partIdDataGridViewTextBoxColumn.DataPropertyName = "PartId";
            partIdDataGridViewTextBoxColumn.HeaderText = "PartId";
            partIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            partIdDataGridViewTextBoxColumn.Name = "partIdDataGridViewTextBoxColumn";
            partIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // partNameDataGridViewTextBoxColumn
            // 
            partNameDataGridViewTextBoxColumn.DataPropertyName = "PartName";
            partNameDataGridViewTextBoxColumn.HeaderText = "PartName";
            partNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            partNameDataGridViewTextBoxColumn.Name = "partNameDataGridViewTextBoxColumn";
            partNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // unitDataGridViewTextBoxColumn
            // 
            unitDataGridViewTextBoxColumn.DataPropertyName = "Unit";
            unitDataGridViewTextBoxColumn.HeaderText = "Unit";
            unitDataGridViewTextBoxColumn.MinimumWidth = 6;
            unitDataGridViewTextBoxColumn.Name = "unitDataGridViewTextBoxColumn";
            unitDataGridViewTextBoxColumn.Width = 125;
            // 
            // unitPriceDataGridViewTextBoxColumn
            // 
            unitPriceDataGridViewTextBoxColumn.DataPropertyName = "UnitPrice";
            unitPriceDataGridViewTextBoxColumn.HeaderText = "UnitPrice";
            unitPriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            unitPriceDataGridViewTextBoxColumn.Name = "unitPriceDataGridViewTextBoxColumn";
            unitPriceDataGridViewTextBoxColumn.Width = 125;
            // 
            // stockQtyDataGridViewTextBoxColumn
            // 
            stockQtyDataGridViewTextBoxColumn.DataPropertyName = "StockQty";
            stockQtyDataGridViewTextBoxColumn.HeaderText = "StockQty";
            stockQtyDataGridViewTextBoxColumn.MinimumWidth = 6;
            stockQtyDataGridViewTextBoxColumn.Name = "stockQtyDataGridViewTextBoxColumn";
            stockQtyDataGridViewTextBoxColumn.Width = 125;
            // 
            // minQtyDataGridViewTextBoxColumn
            // 
            minQtyDataGridViewTextBoxColumn.DataPropertyName = "MinQty";
            minQtyDataGridViewTextBoxColumn.HeaderText = "MinQty";
            minQtyDataGridViewTextBoxColumn.MinimumWidth = 6;
            minQtyDataGridViewTextBoxColumn.Name = "minQtyDataGridViewTextBoxColumn";
            minQtyDataGridViewTextBoxColumn.Width = 125;
            // 
            // frmPart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(nudMinQty);
            Controls.Add(nudUnitPrice);
            Controls.Add(lblMinQty);
            Controls.Add(nudStockQty);
            Controls.Add(lblStockQty);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(lblUnitPrice);
            Controls.Add(txtUnit);
            Controls.Add(lblUnit);
            Controls.Add(txtPartName);
            Controls.Add(lblPartName);
            Controls.Add(txtPartId);
            Controls.Add(lblPartId);
            Controls.Add(btnLowStock);
            Controls.Add(dgvParts);
            Controls.Add(btnReload);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblKeyword);
            Name = "frmPart";
            Text = "Quản lý phụ tùng";
            Load += frmPart_Load;
            ((System.ComponentModel.ISupportInitialize)dgvParts).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStockQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudUnitPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMinQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)partBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvParts;
        private Button btnReload;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lblKeyword;
        private Button btnLowStock;
        private ComboBox cbCustomer;
        private Label lblMinQty;
        private NumericUpDown nudStockQty;
        private Label lblStockQty;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private TextBox txtModel;
        private Label lblUnitPrice;
        private TextBox txtUnit;
        private Label lblUnit;
        private TextBox txtPartName;
        private Label lblPartName;
        private TextBox txtPartId;
        private Label lblPartId;
        private NumericUpDown nudUnitPrice;
        private NumericUpDown nudMinQty;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private DataGridViewTextBoxColumn partIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn partNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn unitPriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn stockQtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn minQtyDataGridViewTextBoxColumn;
        private BindingSource partBindingSource;
    }
}