using GaraApp.BLL;
using GaraApp.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaraApp.UI
{
    public partial class frmCar : Form
    {
        private readonly CarService _carService = new CarService();
        private readonly CustomerService _customerService = new CustomerService();

        public frmCar()
        {
            InitializeComponent();

            // Wire up events (Load event đã được wire trong Designer)
            dgvCars.CellClick += dgvCars_CellClick;
            txtSearchPlate.KeyDown += txtSearchPlate_KeyDown;
            btnSearch.Click += btnSearch_Click;
            btnReload.Click += btnReload_Click;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;

            // Set default year
            nudYear.Value = DateTime.Now.Year;
        }

        private async void frmCar_Load(object sender, EventArgs e)
        {
            await LoadCustomersAsync();
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                ToggleBusy(true);

                dgvCars.AutoGenerateColumns = true;
                dgvCars.DataSource = null;
                dgvCars.DataSource = await _carService.GetCarsAsync();
                SetUpGridView();
                dgvCars.ClearSelection();
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

        private async Task LoadCustomersAsync()
        {
            try
            {
                var customers = await _customerService.GetCustomersAsync();

                // ComboBox cho form nhập liệu
                var customerList = customers.ToList();
                cbCustomer.DataSource = null;
                cbCustomer.DisplayMember = "FullName";
                cbCustomer.ValueMember = "CustomerId";
                cbCustomer.DataSource = customerList;
                cbCustomer.SelectedIndex = -1;

                // ComboBox cho bộ lọc tìm kiếm
                var filterList = customers.ToList();
                filterList.Insert(0, new Customer { CustomerId = 0, FullName = "-- Tất cả --" });
                cbFilterCustomer.DataSource = null;
                cbFilterCustomer.DisplayMember = "FullName";
                cbFilterCustomer.ValueMember = "CustomerId";
                cbFilterCustomer.DataSource = filterList;
                cbFilterCustomer.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách chủ xe: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetUpGridView()
        {
            // Hide navigation property if present
            if (dgvCars.Columns["Customer"] != null)
                dgvCars.Columns["Customer"].Visible = false;

            if (dgvCars.Columns["CarId"] != null)
            {
                dgvCars.Columns["CarId"].HeaderText = "Mã xe";
                dgvCars.Columns["CarId"].Width = 70;
            }
            if (dgvCars.Columns["LicensePlate"] != null)
            {
                dgvCars.Columns["LicensePlate"].HeaderText = "Biển số";
                dgvCars.Columns["LicensePlate"].Width = 100;
            }
            if (dgvCars.Columns["Brand"] != null)
            {
                dgvCars.Columns["Brand"].HeaderText = "Hãng";
                dgvCars.Columns["Brand"].Width = 100;
            }
            if (dgvCars.Columns["Model"] != null)
            {
                dgvCars.Columns["Model"].HeaderText = "Model";
                dgvCars.Columns["Model"].Width = 120;
            }
            if (dgvCars.Columns["Year"] != null)
            {
                dgvCars.Columns["Year"].HeaderText = "Năm";
                dgvCars.Columns["Year"].Width = 70;
            }
            if (dgvCars.Columns["CustomerId"] != null)
            {
                dgvCars.Columns["CustomerId"].HeaderText = "Mã KH";
                dgvCars.Columns["CustomerId"].Width = 70;
            }

            dgvCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCars.MultiSelect = false;
            dgvCars.ReadOnly = true;
            dgvCars.AllowUserToAddRows = false;
        }

        private void dgvCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            try
            {
                DataGridViewRow row = dgvCars.Rows[e.RowIndex];

                txtCarId.Text = row.Cells["CarId"].Value?.ToString() ?? "";
                txtLicensePlate.Text = row.Cells["LicensePlate"].Value?.ToString() ?? "";
                txtBrand.Text = row.Cells["Brand"].Value?.ToString() ?? "";
                txtModel.Text = row.Cells["Model"].Value?.ToString() ?? "";

                // Xử lý năm với NumericUpDown
                if (row.Cells["Year"].Value != null && int.TryParse(row.Cells["Year"].Value.ToString(), out int year))
                {
                    if (year >= nudYear.Minimum && year <= nudYear.Maximum)
                        nudYear.Value = year;
                    else
                        nudYear.Value = DateTime.Now.Year;
                }
                else
                {
                    nudYear.Value = DateTime.Now.Year;
                }

                // Set customer combobox by value
                if (row.Cells["CustomerId"].Value != null && int.TryParse(row.Cells["CustomerId"].Value.ToString(), out int custId))
                {
                    cbCustomer.SelectedValue = custId;
                }
                else
                {
                    cbCustomer.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLicensePlate.Text))
            {
                MessageBox.Show("Vui lòng nhập Biển số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicensePlate.Focus();
                return;
            }

            if (cbCustomer.SelectedValue == null || !(cbCustomer.SelectedValue is int) || (int)cbCustomer.SelectedValue <= 0)
            {
                MessageBox.Show("Vui lòng chọn chủ xe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbCustomer.Focus();
                return;
            }

            try
            {
                ToggleBusy(true);

                var car = new Car
                {
                    LicensePlate = txtLicensePlate.Text.Trim(),
                    Brand = txtBrand.Text.Trim(),
                    Model = txtModel.Text.Trim(),
                    Year = (int)nudYear.Value,
                    CustomerId = (int)cbCustomer.SelectedValue
                };

                await _carService.AddCarAsync(car);

                MessageBox.Show("Thêm xe thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm xe: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusy(false);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarId.Text) || !int.TryParse(txtCarId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Chọn xe cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLicensePlate.Text))
            {
                MessageBox.Show("Vui lòng nhập Biển số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLicensePlate.Focus();
                return;
            }

            if (cbCustomer.SelectedValue == null || !(cbCustomer.SelectedValue is int) || (int)cbCustomer.SelectedValue <= 0)
            {
                MessageBox.Show("Vui lòng chọn chủ xe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbCustomer.Focus();
                return;
            }

            try
            {
                ToggleBusy(true);

                var car = new Car
                {
                    CarId = id,
                    LicensePlate = txtLicensePlate.Text.Trim(),
                    Brand = txtBrand.Text.Trim(),
                    Model = txtModel.Text.Trim(),
                    Year = (int)nudYear.Value,
                    CustomerId = (int)cbCustomer.SelectedValue
                };

                await _carService.UpdateCarAsync(car);

                MessageBox.Show("Cập nhật xe thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật xe: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusy(false);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCarId.Text) || !int.TryParse(txtCarId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Chọn xe cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Bạn có chắc muốn xóa xe biển số '{txtLicensePlate.Text}' không?\n\nLưu ý: Xe đang có lịch sử sửa chữa sẽ không thể xóa.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                ToggleBusy(true);
                await _carService.DeleteCarAsync(id);

                MessageBox.Show("Xóa xe thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa xe: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusy(false);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleBusy(true);

                string plateKeyword = txtSearchPlate.Text.Trim();
                int customerId = cbFilterCustomer.SelectedValue != null && cbFilterCustomer.SelectedValue is int
                    ? (int)cbFilterCustomer.SelectedValue
                    : 0;

                // Nếu không có bộ lọc nào, load tất cả
                if (string.IsNullOrWhiteSpace(plateKeyword) && customerId == 0)
                {
                    await LoadDataAsync();
                    return;
                }

                // Tìm kiếm theo khách hàng
                if (customerId > 0)
                {
                    var result = await _carService.GetByCustomerAsync(customerId);

                    // Nếu có cả biển số, lọc thêm
                    if (!string.IsNullOrWhiteSpace(plateKeyword))
                    {
                        result = result.Where(c => c.LicensePlate.Contains(plateKeyword, StringComparison.OrdinalIgnoreCase)).ToList();
                    }

                    dgvCars.DataSource = null;
                    dgvCars.DataSource = result;
                    SetUpGridView();
                    dgvCars.ClearSelection();
                }
                // Chỉ tìm theo biển số
                else if (!string.IsNullOrWhiteSpace(plateKeyword))
                {
                    var result = await _carService.SearchCarAsync(plateKeyword);
                    dgvCars.DataSource = null;
                    dgvCars.DataSource = result;
                    SetUpGridView();
                    dgvCars.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusy(false);
            }
        }

        private void txtSearchPlate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private async void btnReload_Click(object sender, EventArgs e)
        {
            txtSearchPlate.Clear();
            if (cbFilterCustomer.Items.Count > 0)
                cbFilterCustomer.SelectedIndex = 0;
            ClearInputs();
            await LoadDataAsync();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtCarId.Clear();
            txtLicensePlate.Clear();
            txtBrand.Clear();
            txtModel.Clear();
            nudYear.Value = DateTime.Now.Year;
            cbCustomer.SelectedIndex = -1;
            
            if (dgvCars.Rows.Count > 0)
                dgvCars.ClearSelection();
        }

        private void ToggleBusy(bool busy)
        {
            UseWaitCursor = busy;
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
            
            // Disable/enable input controls
            txtCarId.Enabled = !busy;
            txtLicensePlate.Enabled = !busy;
            txtBrand.Enabled = !busy;
            txtModel.Enabled = !busy;
            nudYear.Enabled = !busy;
            cbCustomer.Enabled = !busy;
            
            // Disable/enable search controls
            txtSearchPlate.Enabled = !busy;
            cbFilterCustomer.Enabled = !busy;
            
            // Disable/enable buttons
            btnAdd.Enabled = !busy;
            btnUpdate.Enabled = !busy;
            btnDelete.Enabled = !busy;
            btnSearch.Enabled = !busy;
            btnReload.Enabled = !busy;
            btnClear.Enabled = !busy;
            
            // Disable grid interaction
            dgvCars.Enabled = !busy;
        }
    }
}