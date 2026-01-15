using GaraApp.BLL;
using GaraApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GaraApp.BLL.RepairOrderService;

namespace GaraApp.UI
{
    public partial class frmRepairOrder : Form
    {
        private readonly CarService _carService = new CarService();
        private readonly ServiceService _serviceService = new ServiceService();
        private readonly PartService _partService = new PartService();
        private readonly RepairOrderService _repairOrderService = new RepairOrderService();

        private List<Car> _cars = new List<Car>();
        private List<Service> _services = new List<Service>();
        private List<Part> _parts = new List<Part>();

        private List<ServiceLineUI> _serviceLines = new List<ServiceLineUI>();
        private List<PartLineUI> _partLines = new List<PartLineUI>();

        public frmRepairOrder()
        {
            InitializeComponent();

            // Wire up events
            cbCar.SelectedIndexChanged += cbCar_SelectedIndexChanged;
            cbService.SelectedIndexChanged += cbService_SelectedIndexChanged;
            cbPart.SelectedIndexChanged += cbPart_SelectedIndexChanged;
            
            btnNew.Click += btnNew_Click;
            btnAddService.Click += btnAddService_Click;
            btnRemoveService.Click += btnRemoveService_Click;
            btnAddPart.Click += btnAddPart_Click;
            btnRemovePart.Click += btnRemovePart_Click;
            btnSaveOrder.Click += btnSaveOrder_Click;
            btnPay.Click += btnPay_Click;
            btnCancelOrder.Click += btnCancelOrder_Click;

            // Set up date format
            dtpReceiveDate.Format = DateTimePickerFormat.Custom;
            dtpReceiveDate.CustomFormat = "dd/MM/yyyy HH:mm";

            // Set default status
            cbStatus.SelectedIndex = 0; // OPEN
        }

        private async void frmRepairOrder_Load(object sender, EventArgs e)
        {
            await LoadMasterDataAsync();
            ResetForm();
        }

        private async Task LoadMasterDataAsync()
        {
            try
            {
                ToggleBusy(true);

                // Load Cars
                _cars = await _carService.GetCarsAsync();
                cbCar.DataSource = null;
                cbCar.DisplayMember = "LicensePlate";
                cbCar.ValueMember = "CarId";
                cbCar.DataSource = _cars;
                cbCar.SelectedIndex = -1;

                // Load Services
                _services = await _serviceService.GetServicesAsync();
                cbService.DataSource = null;
                cbService.DisplayMember = "ServiceName";
                cbService.ValueMember = "ServiceId";
                cbService.DataSource = _services.ToList();
                cbService.SelectedIndex = -1;

                // Load Parts
                _parts = await _partService.GetPartsAsync();
                cbPart.DataSource = null;
                cbPart.DisplayMember = "PartName";
                cbPart.ValueMember = "PartId";
                cbPart.DataSource = _parts.ToList();
                cbPart.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusy(false);
            }
        }

        private void cbCar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCar.SelectedValue != null && cbCar.SelectedValue is int carId && carId > 0)
            {
                var car = _cars.FirstOrDefault(c => c.CarId == carId);
                if (car != null && car.Customer != null)
                {
                    txtCustomerName.Text = car.Customer.FullName;
                    txtCustomerPhone.Text = car.Customer.Phone;
                }
                else
                {
                    txtCustomerName.Clear();
                    txtCustomerPhone.Clear();
                }
            }
            else
            {
                txtCustomerName.Clear();
                txtCustomerPhone.Clear();
            }
        }

        private void cbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbService.SelectedValue != null && cbService.SelectedValue is int serviceId && serviceId > 0)
            {
                var service = _services.FirstOrDefault(s => s.ServiceId == serviceId);
                if (service != null)
                {   
                    numericUpDown1.Value = service.BasePrice;
                    nudServiceQty.Value = 1;
                }
            }
        }

        private void cbPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPart.SelectedValue != null && cbPart.SelectedValue is int partId && partId > 0)
            {
                var part = _parts.FirstOrDefault(p => p.PartId == partId);
                if (part != null)
                {
                    lblStock.Text = $"Tồn: {part.StockQty}";
                    nudPartPrice.Value = part.UnitPrice;
                    nudPartQty.Value = 1;
                }
                else
                {
                    lblStock.Text = "Tồn: 0";
                }
            }
            else
            {
                lblStock.Text = "Tồn: 0";
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (cbService.SelectedValue == null || !(cbService.SelectedValue is int serviceId) || serviceId <= 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudServiceQty.Value <= 0)
            {
                MessageBox.Show("Số lượng phải > 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var service = _services.FirstOrDefault(s => s.ServiceId == serviceId);
            if (service == null) return;

            // Check duplicate
            if (_serviceLines.Any(x => x.ServiceId == serviceId))
            {
                MessageBox.Show("Dịch vụ đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var line = new ServiceLineUI
            {
                ServiceId = serviceId,
                ServiceName = service.ServiceName,
                Qty = (int)nudServiceQty.Value,
                UnitPrice = numericUpDown1.Value,
                LineTotal = numericUpDown1.Value * nudServiceQty.Value
            };

            _serviceLines.Add(line);
            RefreshServiceGrid();
            CalculateTotal();

            cbService.SelectedIndex = -1;
        }

        private void btnRemoveService_Click(object sender, EventArgs e)
        {
            if (dgvServiceLines.CurrentRow == null || dgvServiceLines.CurrentRow.Index < 0)
            {
                MessageBox.Show("Chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = dgvServiceLines.CurrentRow.Index;
            if (index >= 0 && index < _serviceLines.Count)
            {
                _serviceLines.RemoveAt(index);
                RefreshServiceGrid();
                CalculateTotal();
            }
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            if (cbPart.SelectedValue == null || !(cbPart.SelectedValue is int partId) || partId <= 0)
            {
                MessageBox.Show("Vui lòng chọn phụ tùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudPartQty.Value <= 0)
            {
                MessageBox.Show("Số lượng phải > 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var part = _parts.FirstOrDefault(p => p.PartId == partId);
            if (part == null) return;

            // Check stock
            var totalQtyUsed = _partLines.Where(x => x.PartId == partId).Sum(x => x.Qty);
            var newQty = (int)nudPartQty.Value;
            
            if (totalQtyUsed + newQty > part.StockQty)
            {
                MessageBox.Show($"Không đủ tồn kho! Tồn: {part.StockQty}, đã dùng: {totalQtyUsed}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var line = new PartLineUI
            {
                PartId = partId,
                PartName = part.PartName,
                Qty = newQty,
                UnitPrice = nudPartPrice.Value,
                LineTotal = nudPartPrice.Value * newQty
            };

            _partLines.Add(line);
            RefreshPartGrid();
            CalculateTotal();

            cbPart.SelectedIndex = -1;
        }

        private void btnRemovePart_Click(object sender, EventArgs e)
        {
            if (dgvPartLines.CurrentRow == null || dgvPartLines.CurrentRow.Index < 0)
            {
                MessageBox.Show("Chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = dgvPartLines.CurrentRow.Index;
            if (index >= 0 && index < _partLines.Count)
            {
                _partLines.RemoveAt(index);
                RefreshPartGrid();
                CalculateTotal();
            }
        }

        private async void btnSaveOrder_Click(object sender, EventArgs e)
        {
            if (cbCar.SelectedValue == null || !(cbCar.SelectedValue is int carId) || carId <= 0)
            {
                MessageBox.Show("Vui lòng chọn xe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_serviceLines.Count == 0 && _partLines.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất 1 dịch vụ hoặc phụ tùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ToggleBusy(true);

                var services = _serviceLines.Select(s => new ServiceLine
                {
                    ServiceId = s.ServiceId,
                    Qty = s.Qty,
                    UnitPrice = s.UnitPrice
                }).ToList();

                var parts = _partLines.Select(p => new PartLine
                {
                    PartId = p.PartId,
                    Qty = p.Qty,
                    UnitPrice = p.UnitPrice
                }).ToList();

                int orderId = await _repairOrderService.CreateRepairOrderAsync(
                    carId,
                    txtSymptom.Text.Trim(),
                    (int)nudOdometer.Value,
                    services,
                    parts
                );

                MessageBox.Show($"Lưu phiếu sửa chữa thành công! Mã phiếu: {orderId}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                txtRepairOrderId.Text = orderId.ToString();
                cbStatus.SelectedIndex = 0; // OPEN
                
                // Disable editing after save
                DisableEditing();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusy(false);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRepairOrderId.Text))
            {
                MessageBox.Show("Chưa có phiếu để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cbStatus.SelectedIndex = 1; // PAID
            MessageBox.Show("Đã đánh dấu thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRepairOrderId.Text))
            {
                MessageBox.Show("Chưa có phiếu để hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Bạn có chắc muốn hủy phiếu này không?",
                "Xác nhận hủy",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                cbStatus.SelectedIndex = 2; // CANCELED
                MessageBox.Show("Đã hủy phiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Keep for Designer compatibility
        }

        private void RefreshServiceGrid()
        {
            dgvServiceLines.AutoGenerateColumns = false;
            dgvServiceLines.DataSource = null;
            dgvServiceLines.DataSource = _serviceLines.ToList();
            
            SetupServiceGrid();
        }

        private void SetupServiceGrid()
        {
            dgvServiceLines.Columns.Clear();
            dgvServiceLines.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ServiceId", HeaderText = "Mã DV", Width = 70 });
            dgvServiceLines.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ServiceName", HeaderText = "Tên dịch vụ", Width = 200 });
            dgvServiceLines.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Qty", HeaderText = "SL", Width = 50 });
            dgvServiceLines.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UnitPrice", HeaderText = "Đơn giá", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvServiceLines.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LineTotal", HeaderText = "Thành tiền", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
        }

        private void RefreshPartGrid()
        {
            dgvPartLines.AutoGenerateColumns = false;
            dgvPartLines.DataSource = null;
            dgvPartLines.DataSource = _partLines.ToList();
            
            SetupPartGrid();
        }

        private void SetupPartGrid()
        {
            dgvPartLines.Columns.Clear();
            dgvPartLines.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PartId", HeaderText = "Mã PT", Width = 70 });
            dgvPartLines.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PartName", HeaderText = "Tên phụ tùng", Width = 200 });
            dgvPartLines.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Qty", HeaderText = "SL", Width = 50 });
            dgvPartLines.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UnitPrice", HeaderText = "Đơn giá", Width = 100, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
            dgvPartLines.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LineTotal", HeaderText = "Thành tiền", Width = 120, DefaultCellStyle = new DataGridViewCellStyle { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight } });
        }

        private void CalculateTotal()
        {
            decimal total = _serviceLines.Sum(s => s.LineTotal) + _partLines.Sum(p => p.LineTotal);
            txtTotalAmount.Text = total.ToString("N0");
        }

        private void ResetForm()
        {
            txtRepairOrderId.Clear();
            dtpReceiveDate.Value = DateTime.Now;
            cbCar.SelectedIndex = -1;
            txtCustomerName.Clear();
            txtCustomerPhone.Clear();
            nudOdometer.Value = 0;
            txtSymptom.Clear();
            cbStatus.SelectedIndex = 0; // OPEN

            _serviceLines.Clear();
            _partLines.Clear();
            RefreshServiceGrid();
            RefreshPartGrid();
            CalculateTotal();

            EnableEditing();
        }

        private void EnableEditing()
        {
            grpOrderInfo.Enabled = true;
            grpServiceLines.Enabled = true;
            grpPartLines.Enabled = true;
            btnSaveOrder.Enabled = true;
        }

        private void DisableEditing()
        {
            grpOrderInfo.Enabled = false;
            grpServiceLines.Enabled = false;
            grpPartLines.Enabled = false;
            btnSaveOrder.Enabled = false;
        }

        private void ToggleBusy(bool busy)
        {
            UseWaitCursor = busy;
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
            
            btnNew.Enabled = !busy;
            btnSaveOrder.Enabled = !busy;
            btnPay.Enabled = !busy;
            btnCancelOrder.Enabled = !busy;
        }

        // Helper classes for UI binding
        private class ServiceLineUI
        {
            public int ServiceId { get; set; }
            public string ServiceName { get; set; } = "";
            public int Qty { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal LineTotal { get; set; }
        }

        private class PartLineUI
        {
            public int PartId { get; set; }
            public string PartName { get; set; } = "";
            public int Qty { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal LineTotal { get; set; }
        }
    }
}
