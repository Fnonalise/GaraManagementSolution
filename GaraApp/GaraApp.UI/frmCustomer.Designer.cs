namespace GaraApp.UI
{
    partial class frmCustomer
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
            lblKeyword = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnReload = new Button();
            dgvCustomers = new DataGridView();
            customerBindingSource = new BindingSource(components);
            lblCustomerId = new Label();
            txtID = new TextBox();
            lblFullName = new Label();
            txtName = new TextBox();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            customerServiceBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customerBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customerServiceBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblKeyword
            // 
            lblKeyword.Anchor = AnchorStyles.None;
            lblKeyword.Location = new Point(144, 30);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(68, 36);
            lblKeyword.TabIndex = 0;
            lblKeyword.Text = "Từ khóa:";
            lblKeyword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(218, 35);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(179, 27);
            txtSearch.TabIndex = 1;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(412, 33);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(525, 34);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(94, 29);
            btnReload.TabIndex = 3;
            btnReload.Text = "Tải lại";
            btnReload.UseVisualStyleBackColor = true;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.DataSource = customerServiceBindingSource;
            dgvCustomers.Location = new Point(64, 99);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.Size = new Size(675, 228);
            dgvCustomers.TabIndex = 10;
            // 
            // customerBindingSource
            // 
            customerBindingSource.DataSource = typeof(Entities.Customer);
            // 
            // lblCustomerId
            // 
            lblCustomerId.AutoSize = true;
            lblCustomerId.Location = new Point(43, 363);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(54, 20);
            lblCustomerId.TabIndex = 11;
            lblCustomerId.Text = "Mã KH";
            // 
            // txtID
            // 
            txtID.Location = new Point(103, 360);
            txtID.Name = "txtID";
            txtID.Size = new Size(125, 27);
            txtID.TabIndex = 21;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(272, 363);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(54, 20);
            lblFullName.TabIndex = 13;
            lblFullName.Text = "Họ tên";
            // 
            // txtName
            // 
            txtName.Location = new Point(332, 360);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 22;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(534, 360);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(125, 27);
            txtPhone.TabIndex = 23;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(492, 363);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(36, 20);
            lblPhone.TabIndex = 15;
            lblPhone.Text = "SĐT";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(103, 409);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(223, 27);
            txtAddress.TabIndex = 24;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(43, 412);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(55, 20);
            lblAddress.TabIndex = 17;
            lblAddress.Text = "Địa chỉ";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(367, 407);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 25;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(467, 407);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 26;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(567, 407);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 27;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(667, 408);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 28;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // customerServiceBindingSource
            // 
            customerServiceBindingSource.DataSource = typeof(BLL.CustomerService);
            // 
            // frmCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClear);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtName);
            Controls.Add(lblFullName);
            Controls.Add(txtID);
            Controls.Add(lblCustomerId);
            Controls.Add(dgvCustomers);
            Controls.Add(btnReload);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblKeyword);
            Name = "frmCustomer";
            Text = "Quản lý khách hàng";
            Load += frmCustomer_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ((System.ComponentModel.ISupportInitialize)customerBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)customerServiceBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblKeyword;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnReload;
        private DataGridView dgvCustomers;
        private Label lblCustomerId;
        private TextBox txtID;
        private Label lblFullName;
        private TextBox txtName;
        private TextBox txtPhone;
        private Label lblPhone;
        private TextBox txtAddress;
        private Label lblAddress;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private BindingSource customerBindingSource;
        private BindingSource customerServiceBindingSource;
    }
}