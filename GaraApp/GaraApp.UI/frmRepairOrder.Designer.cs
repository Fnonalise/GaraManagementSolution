namespace GaraApp.UI
{
    partial class frmRepairOrder
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
            grpOrderInfo = new GroupBox();
            txtSymptom = new TextBox();
            lblSymptom = new Label();
            nudOdometer = new NumericUpDown();
            lblOdometer = new Label();
            txtCustomerPhone = new TextBox();
            lblPhone = new Label();
            txtCustomerName = new TextBox();
            lblCustomerName = new Label();
            cbCar = new ComboBox();
            lblCar = new Label();
            cbStatus = new ComboBox();
            lblStatus = new Label();
            dtpReceiveDate = new DateTimePicker();
            lblReceiveDate = new Label();
            txtRepairOrderId = new TextBox();
            lblOrderId = new Label();
            grpServiceLines = new GroupBox();
            btnRemoveService = new Button();
            dgvServiceLines = new DataGridView();
            btnAddService = new Button();
            numericUpDown1 = new NumericUpDown();
            nudServiceQty = new NumericUpDown();
            cbService = new ComboBox();
            grpPartLines = new GroupBox();
            btnRemovePart = new Button();
            dgvPartLines = new DataGridView();
            btnAddPart = new Button();
            nudPartPrice = new NumericUpDown();
            nudPartQty = new NumericUpDown();
            lblStock = new Label();
            cbPart = new ComboBox();
            grpSummary = new GroupBox();
            btnCancelOrder = new Button();
            btnPay = new Button();
            btnSaveOrder = new Button();
            btnNew = new Button();
            txtTotalAmount = new TextBox();
            lblTotal = new Label();
            repairServiceDetailBindingSource = new BindingSource(components);
            serviceBindingSource = new BindingSource(components);
            reportServiceBindingSource = new BindingSource(components);
            repairServiceDetailIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            repairOrderIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            repairOrderDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            serviceIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            serviceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            qtyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            unitPriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lineTotalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            partServiceBindingSource = new BindingSource(components);
            repairPartDetailBindingSource = new BindingSource(components);
            repairPartDetailIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            repairOrderIdDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            repairOrderDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            partIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            partDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            qtyDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            unitPriceDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            lineTotalDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            grpOrderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudOdometer).BeginInit();
            grpServiceLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvServiceLines).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudServiceQty).BeginInit();
            grpPartLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPartLines).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPartPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPartQty).BeginInit();
            grpSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)repairServiceDetailBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)serviceBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)reportServiceBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)partServiceBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)repairPartDetailBindingSource).BeginInit();
            SuspendLayout();
            // 
            // grpOrderInfo
            // 
            grpOrderInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpOrderInfo.Controls.Add(txtSymptom);
            grpOrderInfo.Controls.Add(lblSymptom);
            grpOrderInfo.Controls.Add(nudOdometer);
            grpOrderInfo.Controls.Add(lblOdometer);
            grpOrderInfo.Controls.Add(txtCustomerPhone);
            grpOrderInfo.Controls.Add(lblPhone);
            grpOrderInfo.Controls.Add(txtCustomerName);
            grpOrderInfo.Controls.Add(lblCustomerName);
            grpOrderInfo.Controls.Add(cbCar);
            grpOrderInfo.Controls.Add(lblCar);
            grpOrderInfo.Controls.Add(cbStatus);
            grpOrderInfo.Controls.Add(lblStatus);
            grpOrderInfo.Controls.Add(dtpReceiveDate);
            grpOrderInfo.Controls.Add(lblReceiveDate);
            grpOrderInfo.Controls.Add(txtRepairOrderId);
            grpOrderInfo.Controls.Add(lblOrderId);
            grpOrderInfo.Location = new Point(10, 30);
            grpOrderInfo.Name = "grpOrderInfo";
            grpOrderInfo.Size = new Size(1160, 170);
            grpOrderInfo.TabIndex = 0;
            grpOrderInfo.TabStop = false;
            grpOrderInfo.Text = "Thông tin phiếu";
            // 
            // txtSymptom
            // 
            txtSymptom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSymptom.Location = new Point(419, 123);
            txtSymptom.Multiline = true;
            txtSymptom.Name = "txtSymptom";
            txtSymptom.ScrollBars = ScrollBars.Vertical;
            txtSymptom.Size = new Size(620, 34);
            txtSymptom.TabIndex = 8;
            // 
            // lblSymptom
            // 
            lblSymptom.AutoSize = true;
            lblSymptom.Location = new Point(327, 126);
            lblSymptom.Name = "lblSymptom";
            lblSymptom.Size = new Size(86, 20);
            lblSymptom.TabIndex = 8;
            lblSymptom.Text = "Triệu chứng";
            // 
            // nudOdometer
            // 
            nudOdometer.Location = new Point(108, 124);
            nudOdometer.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudOdometer.Name = "nudOdometer";
            nudOdometer.Size = new Size(150, 27);
            nudOdometer.TabIndex = 7;
            // 
            // lblOdometer
            // 
            lblOdometer.AutoSize = true;
            lblOdometer.Location = new Point(52, 126);
            lblOdometer.Name = "lblOdometer";
            lblOdometer.Size = new Size(50, 20);
            lblOdometer.TabIndex = 7;
            lblOdometer.Text = "Số km";
            // 
            // txtCustomerPhone
            // 
            txtCustomerPhone.Location = new Point(638, 83);
            txtCustomerPhone.Name = "txtCustomerPhone";
            txtCustomerPhone.ReadOnly = true;
            txtCustomerPhone.Size = new Size(164, 27);
            txtCustomerPhone.TabIndex = 6;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(596, 86);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(36, 20);
            lblPhone.TabIndex = 6;
            lblPhone.Text = "SĐT";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(403, 83);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.ReadOnly = true;
            txtCustomerName.Size = new Size(125, 27);
            txtCustomerName.TabIndex = 5;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(348, 86);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(49, 20);
            lblCustomerName.TabIndex = 5;
            lblCustomerName.Text = "Khách";
            // 
            // cbCar
            // 
            cbCar.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCar.FormattingEnabled = true;
            cbCar.Location = new Point(146, 80);
            cbCar.Name = "cbCar";
            cbCar.Size = new Size(151, 28);
            cbCar.TabIndex = 4;
            // 
            // lblCar
            // 
            lblCar.AutoSize = true;
            lblCar.Location = new Point(52, 83);
            lblCar.Name = "lblCar";
            lblCar.Size = new Size(88, 20);
            lblCar.TabIndex = 4;
            lblCar.Text = "Xe (Biển số)";
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "OPEN", "PAID", "CANCELED" });
            cbStatus.Location = new Point(808, 30);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(151, 28);
            cbStatus.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(727, 33);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(75, 20);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Trạng thái";
            // 
            // dtpReceiveDate
            // 
            dtpReceiveDate.Format = DateTimePickerFormat.Custom;
            dtpReceiveDate.Location = new Point(419, 32);
            dtpReceiveDate.Name = "dtpReceiveDate";
            dtpReceiveDate.Size = new Size(250, 27);
            dtpReceiveDate.TabIndex = 2;
            // 
            // lblReceiveDate
            // 
            lblReceiveDate.AutoSize = true;
            lblReceiveDate.Location = new Point(333, 33);
            lblReceiveDate.Name = "lblReceiveDate";
            lblReceiveDate.Size = new Size(80, 20);
            lblReceiveDate.TabIndex = 2;
            lblReceiveDate.Text = "Ngày nhận";
            // 
            // txtRepairOrderId
            // 
            txtRepairOrderId.Location = new Point(138, 30);
            txtRepairOrderId.Name = "txtRepairOrderId";
            txtRepairOrderId.ReadOnly = true;
            txtRepairOrderId.Size = new Size(125, 27);
            txtRepairOrderId.TabIndex = 1;
            // 
            // lblOrderId
            // 
            lblOrderId.AutoSize = true;
            lblOrderId.Location = new Point(51, 33);
            lblOrderId.Name = "lblOrderId";
            lblOrderId.Size = new Size(71, 20);
            lblOrderId.TabIndex = 0;
            lblOrderId.Text = "Mã phiếu";
            // 
            // grpServiceLines
            // 
            grpServiceLines.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpServiceLines.Controls.Add(btnRemoveService);
            grpServiceLines.Controls.Add(dgvServiceLines);
            grpServiceLines.Controls.Add(btnAddService);
            grpServiceLines.Controls.Add(numericUpDown1);
            grpServiceLines.Controls.Add(nudServiceQty);
            grpServiceLines.Controls.Add(cbService);
            grpServiceLines.Location = new Point(10, 210);
            grpServiceLines.Name = "grpServiceLines";
            grpServiceLines.Size = new Size(570, 380);
            grpServiceLines.TabIndex = 20;
            grpServiceLines.TabStop = false;
            grpServiceLines.Text = "Chi tiết dịch vụ";
            // 
            // btnRemoveService
            // 
            btnRemoveService.Location = new Point(451, 345);
            btnRemoveService.Name = "btnRemoveService";
            btnRemoveService.Size = new Size(94, 29);
            btnRemoveService.TabIndex = 26;
            btnRemoveService.Text = "Xóa dòng";
            btnRemoveService.UseVisualStyleBackColor = true;
            // 
            // dgvServiceLines
            // 
            dgvServiceLines.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvServiceLines.AutoGenerateColumns = false;
            dgvServiceLines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvServiceLines.Columns.AddRange(new DataGridViewColumn[] { repairServiceDetailIdDataGridViewTextBoxColumn, repairOrderIdDataGridViewTextBoxColumn, repairOrderDataGridViewTextBoxColumn, serviceIdDataGridViewTextBoxColumn, serviceDataGridViewTextBoxColumn, qtyDataGridViewTextBoxColumn, unitPriceDataGridViewTextBoxColumn, lineTotalDataGridViewTextBoxColumn });
            dgvServiceLines.DataSource = repairServiceDetailBindingSource;
            dgvServiceLines.Location = new Point(15, 70);
            dgvServiceLines.Name = "dgvServiceLines";
            dgvServiceLines.ReadOnly = true;
            dgvServiceLines.RowHeadersWidth = 51;
            dgvServiceLines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServiceLines.Size = new Size(540, 263);
            dgvServiceLines.TabIndex = 25;
            // 
            // btnAddService
            // 
            btnAddService.Location = new Point(465, 28);
            btnAddService.Name = "btnAddService";
            btnAddService.Size = new Size(80, 28);
            btnAddService.TabIndex = 24;
            btnAddService.Text = "+ DV";
            btnAddService.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Location = new Point(345, 30);
            numericUpDown1.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(110, 27);
            numericUpDown1.TabIndex = 23;
            // 
            // nudServiceQty
            // 
            nudServiceQty.Location = new Point(265, 30);
            nudServiceQty.Name = "nudServiceQty";
            nudServiceQty.Size = new Size(70, 27);
            nudServiceQty.TabIndex = 22;
            // 
            // cbService
            // 
            cbService.DropDownStyle = ComboBoxStyle.DropDownList;
            cbService.FormattingEnabled = true;
            cbService.Location = new Point(15, 30);
            cbService.Name = "cbService";
            cbService.Size = new Size(240, 28);
            cbService.TabIndex = 21;
            // 
            // grpPartLines
            // 
            grpPartLines.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            grpPartLines.Controls.Add(btnRemovePart);
            grpPartLines.Controls.Add(dgvPartLines);
            grpPartLines.Controls.Add(btnAddPart);
            grpPartLines.Controls.Add(nudPartPrice);
            grpPartLines.Controls.Add(nudPartQty);
            grpPartLines.Controls.Add(lblStock);
            grpPartLines.Controls.Add(cbPart);
            grpPartLines.Location = new Point(600, 210);
            grpPartLines.Name = "grpPartLines";
            grpPartLines.Size = new Size(570, 380);
            grpPartLines.TabIndex = 40;
            grpPartLines.TabStop = false;
            grpPartLines.Text = "Chi tiết phụ tùng";
            // 
            // btnRemovePart
            // 
            btnRemovePart.Location = new Point(470, 345);
            btnRemovePart.Name = "btnRemovePart";
            btnRemovePart.Size = new Size(94, 29);
            btnRemovePart.TabIndex = 47;
            btnRemovePart.Text = "Xóa dòng";
            btnRemovePart.UseVisualStyleBackColor = true;
            // 
            // dgvPartLines
            // 
            dgvPartLines.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPartLines.AutoGenerateColumns = false;
            dgvPartLines.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPartLines.Columns.AddRange(new DataGridViewColumn[] { repairPartDetailIdDataGridViewTextBoxColumn, repairOrderIdDataGridViewTextBoxColumn1, repairOrderDataGridViewTextBoxColumn1, partIdDataGridViewTextBoxColumn, partDataGridViewTextBoxColumn, qtyDataGridViewTextBoxColumn1, unitPriceDataGridViewTextBoxColumn1, lineTotalDataGridViewTextBoxColumn1 });
            dgvPartLines.DataSource = repairPartDetailBindingSource;
            dgvPartLines.Location = new Point(18, 70);
            dgvPartLines.Name = "dgvPartLines";
            dgvPartLines.ReadOnly = true;
            dgvPartLines.RowHeadersWidth = 51;
            dgvPartLines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPartLines.Size = new Size(535, 263);
            dgvPartLines.TabIndex = 46;
            // 
            // btnAddPart
            // 
            btnAddPart.Location = new Point(506, 29);
            btnAddPart.Name = "btnAddPart";
            btnAddPart.Size = new Size(58, 29);
            btnAddPart.TabIndex = 45;
            btnAddPart.Text = "+ PT";
            btnAddPart.UseVisualStyleBackColor = true;
            // 
            // nudPartPrice
            // 
            nudPartPrice.DecimalPlaces = 2;
            nudPartPrice.Location = new Point(365, 31);
            nudPartPrice.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            nudPartPrice.Name = "nudPartPrice";
            nudPartPrice.Size = new Size(135, 27);
            nudPartPrice.TabIndex = 44;
            // 
            // nudPartQty
            // 
            nudPartQty.Location = new Point(209, 31);
            nudPartQty.Name = "nudPartQty";
            nudPartQty.Size = new Size(150, 27);
            nudPartQty.TabIndex = 43;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.ForeColor = Color.Red;
            lblStock.Location = new Point(153, 32);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(49, 20);
            lblStock.TabIndex = 42;
            lblStock.Text = "Tồn: 0";
            lblStock.Click += label1_Click;
            // 
            // cbPart
            // 
            cbPart.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPart.FormattingEnabled = true;
            cbPart.Location = new Point(7, 29);
            cbPart.Name = "cbPart";
            cbPart.Size = new Size(135, 28);
            cbPart.TabIndex = 41;
            // 
            // grpSummary
            // 
            grpSummary.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpSummary.Controls.Add(btnCancelOrder);
            grpSummary.Controls.Add(btnPay);
            grpSummary.Controls.Add(btnSaveOrder);
            grpSummary.Controls.Add(btnNew);
            grpSummary.Controls.Add(txtTotalAmount);
            grpSummary.Controls.Add(lblTotal);
            grpSummary.Location = new Point(10, 600);
            grpSummary.Name = "grpSummary";
            grpSummary.Size = new Size(1160, 110);
            grpSummary.TabIndex = 60;
            grpSummary.TabStop = false;
            grpSummary.Text = "Tổng kết";
            // 
            // btnCancelOrder
            // 
            btnCancelOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelOrder.Location = new Point(727, 39);
            btnCancelOrder.Name = "btnCancelOrder";
            btnCancelOrder.Size = new Size(94, 29);
            btnCancelOrder.TabIndex = 65;
            btnCancelOrder.Text = "Hủy phiếu";
            btnCancelOrder.UseVisualStyleBackColor = true;
            // 
            // btnPay
            // 
            btnPay.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnPay.Location = new Point(590, 39);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(94, 29);
            btnPay.TabIndex = 64;
            btnPay.Text = "Thanh toán";
            btnPay.UseVisualStyleBackColor = true;
            // 
            // btnSaveOrder
            // 
            btnSaveOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSaveOrder.Location = new Point(448, 39);
            btnSaveOrder.Name = "btnSaveOrder";
            btnSaveOrder.Size = new Size(94, 29);
            btnSaveOrder.TabIndex = 63;
            btnSaveOrder.Text = "Lưu phiếu (Transaction)";
            btnSaveOrder.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            btnNew.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnNew.Location = new Point(319, 39);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(94, 29);
            btnNew.TabIndex = 62;
            btnNew.Text = "Tạo mới";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // txtTotalAmount
            // 
            txtTotalAmount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtTotalAmount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTotalAmount.Location = new Point(108, 38);
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.ReadOnly = true;
            txtTotalAmount.Size = new Size(155, 34);
            txtTotalAmount.TabIndex = 61;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(22, 48);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(80, 20);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Tổng tiền:";
            // 
            // repairServiceDetailBindingSource
            // 
            repairServiceDetailBindingSource.DataSource = typeof(Entities.RepairServiceDetail);
            // 
            // serviceBindingSource
            // 
            serviceBindingSource.DataSource = typeof(Entities.Service);
            // 
            // reportServiceBindingSource
            // 
            reportServiceBindingSource.DataSource = typeof(BLL.ReportService);
            // 
            // repairServiceDetailIdDataGridViewTextBoxColumn
            // 
            repairServiceDetailIdDataGridViewTextBoxColumn.DataPropertyName = "RepairServiceDetailId";
            repairServiceDetailIdDataGridViewTextBoxColumn.HeaderText = "RepairServiceDetailId";
            repairServiceDetailIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            repairServiceDetailIdDataGridViewTextBoxColumn.Name = "repairServiceDetailIdDataGridViewTextBoxColumn";
            repairServiceDetailIdDataGridViewTextBoxColumn.ReadOnly = true;
            repairServiceDetailIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // repairOrderIdDataGridViewTextBoxColumn
            // 
            repairOrderIdDataGridViewTextBoxColumn.DataPropertyName = "RepairOrderId";
            repairOrderIdDataGridViewTextBoxColumn.HeaderText = "RepairOrderId";
            repairOrderIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            repairOrderIdDataGridViewTextBoxColumn.Name = "repairOrderIdDataGridViewTextBoxColumn";
            repairOrderIdDataGridViewTextBoxColumn.ReadOnly = true;
            repairOrderIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // repairOrderDataGridViewTextBoxColumn
            // 
            repairOrderDataGridViewTextBoxColumn.DataPropertyName = "RepairOrder";
            repairOrderDataGridViewTextBoxColumn.HeaderText = "RepairOrder";
            repairOrderDataGridViewTextBoxColumn.MinimumWidth = 6;
            repairOrderDataGridViewTextBoxColumn.Name = "repairOrderDataGridViewTextBoxColumn";
            repairOrderDataGridViewTextBoxColumn.ReadOnly = true;
            repairOrderDataGridViewTextBoxColumn.Width = 125;
            // 
            // serviceIdDataGridViewTextBoxColumn
            // 
            serviceIdDataGridViewTextBoxColumn.DataPropertyName = "ServiceId";
            serviceIdDataGridViewTextBoxColumn.HeaderText = "ServiceId";
            serviceIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            serviceIdDataGridViewTextBoxColumn.Name = "serviceIdDataGridViewTextBoxColumn";
            serviceIdDataGridViewTextBoxColumn.ReadOnly = true;
            serviceIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // serviceDataGridViewTextBoxColumn
            // 
            serviceDataGridViewTextBoxColumn.DataPropertyName = "Service";
            serviceDataGridViewTextBoxColumn.HeaderText = "Service";
            serviceDataGridViewTextBoxColumn.MinimumWidth = 6;
            serviceDataGridViewTextBoxColumn.Name = "serviceDataGridViewTextBoxColumn";
            serviceDataGridViewTextBoxColumn.ReadOnly = true;
            serviceDataGridViewTextBoxColumn.Width = 125;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            qtyDataGridViewTextBoxColumn.MinimumWidth = 6;
            qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            qtyDataGridViewTextBoxColumn.ReadOnly = true;
            qtyDataGridViewTextBoxColumn.Width = 125;
            // 
            // unitPriceDataGridViewTextBoxColumn
            // 
            unitPriceDataGridViewTextBoxColumn.DataPropertyName = "UnitPrice";
            unitPriceDataGridViewTextBoxColumn.HeaderText = "UnitPrice";
            unitPriceDataGridViewTextBoxColumn.MinimumWidth = 6;
            unitPriceDataGridViewTextBoxColumn.Name = "unitPriceDataGridViewTextBoxColumn";
            unitPriceDataGridViewTextBoxColumn.ReadOnly = true;
            unitPriceDataGridViewTextBoxColumn.Width = 125;
            // 
            // lineTotalDataGridViewTextBoxColumn
            // 
            lineTotalDataGridViewTextBoxColumn.DataPropertyName = "LineTotal";
            lineTotalDataGridViewTextBoxColumn.HeaderText = "LineTotal";
            lineTotalDataGridViewTextBoxColumn.MinimumWidth = 6;
            lineTotalDataGridViewTextBoxColumn.Name = "lineTotalDataGridViewTextBoxColumn";
            lineTotalDataGridViewTextBoxColumn.ReadOnly = true;
            lineTotalDataGridViewTextBoxColumn.Width = 125;
            // 
            // partServiceBindingSource
            // 
            partServiceBindingSource.DataSource = typeof(BLL.PartService);
            // 
            // repairPartDetailBindingSource
            // 
            repairPartDetailBindingSource.DataSource = typeof(Entities.RepairPartDetail);
            // 
            // repairPartDetailIdDataGridViewTextBoxColumn
            // 
            repairPartDetailIdDataGridViewTextBoxColumn.DataPropertyName = "RepairPartDetailId";
            repairPartDetailIdDataGridViewTextBoxColumn.HeaderText = "RepairPartDetailId";
            repairPartDetailIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            repairPartDetailIdDataGridViewTextBoxColumn.Name = "repairPartDetailIdDataGridViewTextBoxColumn";
            repairPartDetailIdDataGridViewTextBoxColumn.ReadOnly = true;
            repairPartDetailIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // repairOrderIdDataGridViewTextBoxColumn1
            // 
            repairOrderIdDataGridViewTextBoxColumn1.DataPropertyName = "RepairOrderId";
            repairOrderIdDataGridViewTextBoxColumn1.HeaderText = "RepairOrderId";
            repairOrderIdDataGridViewTextBoxColumn1.MinimumWidth = 6;
            repairOrderIdDataGridViewTextBoxColumn1.Name = "repairOrderIdDataGridViewTextBoxColumn1";
            repairOrderIdDataGridViewTextBoxColumn1.ReadOnly = true;
            repairOrderIdDataGridViewTextBoxColumn1.Width = 125;
            // 
            // repairOrderDataGridViewTextBoxColumn1
            // 
            repairOrderDataGridViewTextBoxColumn1.DataPropertyName = "RepairOrder";
            repairOrderDataGridViewTextBoxColumn1.HeaderText = "RepairOrder";
            repairOrderDataGridViewTextBoxColumn1.MinimumWidth = 6;
            repairOrderDataGridViewTextBoxColumn1.Name = "repairOrderDataGridViewTextBoxColumn1";
            repairOrderDataGridViewTextBoxColumn1.ReadOnly = true;
            repairOrderDataGridViewTextBoxColumn1.Width = 125;
            // 
            // partIdDataGridViewTextBoxColumn
            // 
            partIdDataGridViewTextBoxColumn.DataPropertyName = "PartId";
            partIdDataGridViewTextBoxColumn.HeaderText = "PartId";
            partIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            partIdDataGridViewTextBoxColumn.Name = "partIdDataGridViewTextBoxColumn";
            partIdDataGridViewTextBoxColumn.ReadOnly = true;
            partIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // partDataGridViewTextBoxColumn
            // 
            partDataGridViewTextBoxColumn.DataPropertyName = "Part";
            partDataGridViewTextBoxColumn.HeaderText = "Part";
            partDataGridViewTextBoxColumn.MinimumWidth = 6;
            partDataGridViewTextBoxColumn.Name = "partDataGridViewTextBoxColumn";
            partDataGridViewTextBoxColumn.ReadOnly = true;
            partDataGridViewTextBoxColumn.Width = 125;
            // 
            // qtyDataGridViewTextBoxColumn1
            // 
            qtyDataGridViewTextBoxColumn1.DataPropertyName = "Qty";
            qtyDataGridViewTextBoxColumn1.HeaderText = "Qty";
            qtyDataGridViewTextBoxColumn1.MinimumWidth = 6;
            qtyDataGridViewTextBoxColumn1.Name = "qtyDataGridViewTextBoxColumn1";
            qtyDataGridViewTextBoxColumn1.ReadOnly = true;
            qtyDataGridViewTextBoxColumn1.Width = 125;
            // 
            // unitPriceDataGridViewTextBoxColumn1
            // 
            unitPriceDataGridViewTextBoxColumn1.DataPropertyName = "UnitPrice";
            unitPriceDataGridViewTextBoxColumn1.HeaderText = "UnitPrice";
            unitPriceDataGridViewTextBoxColumn1.MinimumWidth = 6;
            unitPriceDataGridViewTextBoxColumn1.Name = "unitPriceDataGridViewTextBoxColumn1";
            unitPriceDataGridViewTextBoxColumn1.ReadOnly = true;
            unitPriceDataGridViewTextBoxColumn1.Width = 125;
            // 
            // lineTotalDataGridViewTextBoxColumn1
            // 
            lineTotalDataGridViewTextBoxColumn1.DataPropertyName = "LineTotal";
            lineTotalDataGridViewTextBoxColumn1.HeaderText = "LineTotal";
            lineTotalDataGridViewTextBoxColumn1.MinimumWidth = 6;
            lineTotalDataGridViewTextBoxColumn1.Name = "lineTotalDataGridViewTextBoxColumn1";
            lineTotalDataGridViewTextBoxColumn1.ReadOnly = true;
            lineTotalDataGridViewTextBoxColumn1.Width = 125;
            // 
            // frmRepairOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 703);
            Controls.Add(grpSummary);
            Controls.Add(grpPartLines);
            Controls.Add(grpServiceLines);
            Controls.Add(grpOrderInfo);
            Name = "frmRepairOrder";
            Text = "Phiếu sửa chữa";
            Load += frmRepairOrder_Load;
            grpOrderInfo.ResumeLayout(false);
            grpOrderInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudOdometer).EndInit();
            grpServiceLines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvServiceLines).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudServiceQty).EndInit();
            grpPartLines.ResumeLayout(false);
            grpPartLines.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPartLines).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPartPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPartQty).EndInit();
            grpSummary.ResumeLayout(false);
            grpSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)repairServiceDetailBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)serviceBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)reportServiceBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)partServiceBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)repairPartDetailBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpOrderInfo;
        private GroupBox grpServiceLines;
        private GroupBox grpPartLines;
        private DateTimePicker dtpReceiveDate;
        private Label lblReceiveDate;
        private TextBox txtRepairOrderId;
        private Label lblOrderId;
        private GroupBox grpSummary;
        private TextBox txtCustomerName;
        private Label lblCustomerName;
        private ComboBox cbCar;
        private Label lblCar;
        private ComboBox cbStatus;
        private Label lblStatus;
        private TextBox txtSymptom;
        private Label lblSymptom;
        private NumericUpDown nudOdometer;
        private Label lblOdometer;
        private TextBox txtCustomerPhone;
        private Label lblPhone;
        private NumericUpDown nudServiceQty;
        private ComboBox cbService;
        private DataGridView dgvServiceLines;
        private Button btnAddService;
        private NumericUpDown numericUpDown1;
        private Button btnRemoveService;
        private ComboBox cbPart;
        private Label lblStock;
        private Button btnAddPart;
        private NumericUpDown nudPartPrice;
        private NumericUpDown nudPartQty;
        private Button btnRemovePart;
        private DataGridView dgvPartLines;
        private Label lblTotal;
        private Button btnCancelOrder;
        private Button btnPay;
        private Button btnSaveOrder;
        private Button btnNew;
        private TextBox txtTotalAmount;
        private DataGridViewTextBoxColumn repairServiceDetailIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn repairOrderIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn repairOrderDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn serviceIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn serviceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn unitPriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn lineTotalDataGridViewTextBoxColumn;
        private BindingSource repairServiceDetailBindingSource;
        private BindingSource serviceBindingSource;
        private BindingSource reportServiceBindingSource;
        private DataGridViewTextBoxColumn repairPartDetailIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn repairOrderIdDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn repairOrderDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn partIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn partDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn unitPriceDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn lineTotalDataGridViewTextBoxColumn1;
        private BindingSource repairPartDetailBindingSource;
        private BindingSource partServiceBindingSource;
    }
}