namespace GaraApp.UI
{
    partial class frmCar
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
            lblPlateKeyword = new Label();
            txtSearchPlate = new TextBox();
            lblCustomerFilter = new Label();
            cbFilterCustomer = new ComboBox();
            btnSearch = new Button();
            btnReload = new Button();
            dgvCars = new DataGridView();
            carBindingSource = new BindingSource(components);
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            txtModel = new TextBox();
            lblModel = new Label();
            txtBrand = new TextBox();
            lblBrand = new Label();
            txtLicensePlate = new TextBox();
            lblLicensePlate = new Label();
            txtCarId = new TextBox();
            lblCarId = new Label();
            lblYear = new Label();
            nudYear = new NumericUpDown();
            lblCustomer = new Label();
            cbCustomer = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvCars).BeginInit();
            ((System.ComponentModel.ISupportInitialize)carBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            SuspendLayout();
            // 
            // lblPlateKeyword
            // 
            lblPlateKeyword.Location = new Point(30, 23);
            lblPlateKeyword.Name = "lblPlateKeyword";
            lblPlateKeyword.Size = new Size(62, 25);
            lblPlateKeyword.TabIndex = 0;
            lblPlateKeyword.Text = "Biển số:";
            // 
            // txtSearchPlate
            // 
            txtSearchPlate.Location = new Point(98, 20);
            txtSearchPlate.Name = "txtSearchPlate";
            txtSearchPlate.Size = new Size(125, 27);
            txtSearchPlate.TabIndex = 1;
            // 
            // lblCustomerFilter
            // 
            lblCustomerFilter.AutoSize = true;
            lblCustomerFilter.Location = new Point(242, 22);
            lblCustomerFilter.Name = "lblCustomerFilter";
            lblCustomerFilter.Size = new Size(52, 20);
            lblCustomerFilter.TabIndex = 2;
            lblCustomerFilter.Text = "Khách:";
            // 
            // cbFilterCustomer
            // 
            cbFilterCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFilterCustomer.FormattingEnabled = true;
            cbFilterCustomer.Location = new Point(300, 19);
            cbFilterCustomer.Name = "cbFilterCustomer";
            cbFilterCustomer.Size = new Size(151, 28);
            cbFilterCustomer.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(489, 20);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(604, 20);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(94, 29);
            btnReload.TabIndex = 4;
            btnReload.Text = "Tải lại";
            btnReload.UseVisualStyleBackColor = true;
            // 
            // dgvCars
            // 
            dgvCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCars.Location = new Point(30, 102);
            dgvCars.Name = "dgvCars";
            dgvCars.RowHeadersWidth = 51;
            dgvCars.Size = new Size(758, 216);
            dgvCars.TabIndex = 5;
            // 
            // carBindingSource
            // 
            carBindingSource.DataSource = typeof(Entities.Car);
            // 
            // btnClear
            // 
            btnClear.Location = new Point(684, 398);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 30;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(584, 398);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 29;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(484, 398);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 28;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(384, 398);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 27;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // txtModel
            // 
            txtModel.Location = new Point(604, 351);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(125, 27);
            txtModel.TabIndex = 24;
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Location = new Point(544, 354);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(57, 20);
            lblModel.TabIndex = 32;
            lblModel.Text = "Mẫu xe";
            // 
            // txtBrand
            // 
            txtBrand.Location = new Point(398, 351);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(125, 27);
            txtBrand.TabIndex = 23;
           
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Location = new Point(331, 354);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(64, 20);
            lblBrand.TabIndex = 31;
            lblBrand.Text = "Hãng xe";
            // 
            // txtLicensePlate
            // 
            txtLicensePlate.Location = new Point(188, 351);
            txtLicensePlate.Name = "txtLicensePlate";
            txtLicensePlate.Size = new Size(125, 27);
            txtLicensePlate.TabIndex = 22;
            // 
            // lblLicensePlate
            // 
            lblLicensePlate.AutoSize = true;
            lblLicensePlate.Location = new Point(128, 354);
            lblLicensePlate.Name = "lblLicensePlate";
            lblLicensePlate.Size = new Size(57, 20);
            lblLicensePlate.TabIndex = 30;
            lblLicensePlate.Text = "Biển số";
            // 
            // txtCarId
            // 
            txtCarId.Location = new Point(72, 351);
            txtCarId.Name = "txtCarId";
            txtCarId.ReadOnly = true;
            txtCarId.Size = new Size(42, 27);
            txtCarId.TabIndex = 21;
            // 
            // lblCarId
            // 
            lblCarId.AutoSize = true;
            lblCarId.Location = new Point(12, 354);
            lblCarId.Name = "lblCarId";
            lblCarId.Size = new Size(51, 20);
            lblCarId.TabIndex = 29;
            lblCarId.Text = "Mã Xe";
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(13, 402);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(41, 20);
            lblYear.TabIndex = 41;
            lblYear.Text = "Năm";
            // 
            // nudYear
            // 
            nudYear.Location = new Point(60, 400);
            nudYear.Maximum = new decimal(new int[] { 2050, 0, 0, 0 });
            nudYear.Minimum = new decimal(new int[] { 1980, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.Size = new Size(84, 27);
            nudYear.TabIndex = 25;
            nudYear.Value = new decimal(new int[] { 1980, 0, 0, 0 });
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(160, 402);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(53, 20);
            lblCustomer.TabIndex = 42;
            lblCustomer.Text = "Chủ xe";
            // 
            // cbCustomer
            // 
            cbCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCustomer.FormattingEnabled = true;
            cbCustomer.Location = new Point(219, 399);
            cbCustomer.Name = "cbCustomer";
            cbCustomer.Size = new Size(151, 28);
            cbCustomer.TabIndex = 26;
            // 
            // frmCar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbCustomer);
            Controls.Add(lblCustomer);
            Controls.Add(nudYear);
            Controls.Add(lblYear);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtModel);
            Controls.Add(lblModel);
            Controls.Add(txtBrand);
            Controls.Add(lblBrand);
            Controls.Add(txtLicensePlate);
            Controls.Add(lblLicensePlate);
            Controls.Add(txtCarId);
            Controls.Add(lblCarId);
            Controls.Add(dgvCars);
            Controls.Add(btnReload);
            Controls.Add(btnSearch);
            Controls.Add(cbFilterCustomer);
            Controls.Add(lblCustomerFilter);
            Controls.Add(txtSearchPlate);
            Controls.Add(lblPlateKeyword);
            Name = "frmCar";
            Text = "Quản lý xe";
            Load += frmCar_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCars).EndInit();
            ((System.ComponentModel.ISupportInitialize)carBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPlateKeyword;
        private TextBox txtSearchPlate;
        private Label lblCustomerFilter;
        private ComboBox cbFilterCustomer;
        private Button btnSearch;
        private Button btnReload;
        private DataGridView dgvCars;
        private Button btnClear;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private TextBox txtModel;
        private Label lblModel;
        private TextBox txtBrand;
        private Label lblBrand;
        private TextBox txtLicensePlate;
        private Label lblLicensePlate;
        private TextBox txtCarId;
        private Label lblCarId;
        private Label lblYear;
        private NumericUpDown nudYear;
        private Label lblCustomer;
        private ComboBox cbCustomer;
        private BindingSource carBindingSource;
    }
}