using GaraApp.BLL;
using GaraApp.Entities;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaraApp.UI
{
    public partial class frmCustomer : Form
    {
        private readonly CustomerService _customerService = new CustomerService();

        public frmCustomer()
        {
            InitializeComponent();
            
            // Wire up events
            dgvCustomers.CellClick += dgvCustomers_CellClick;
            txtSearch.KeyDown += txtSearch_KeyDown;
            btnReload.Click += btnReload_Click;
        }

        private async void frmCustomer_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                ToggleBusy(true);
                
                dgvCustomers.AutoGenerateColumns = true;
                dgvCustomers.DataSource = null;
                dgvCustomers.DataSource = await _customerService.GetCustomersAsync();
                SetUpGridView();
                dgvCustomers.ClearSelection();
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

        private void SetUpGridView()
        {
            // Hide navigation property if present
            if (dgvCustomers.Columns["Cars"] != null) 
                dgvCustomers.Columns["Cars"].Visible = false;

            if (dgvCustomers.Columns["CustomerId"] != null)
            {
                dgvCustomers.Columns["CustomerId"].HeaderText = "Mã KH";
                dgvCustomers.Columns["CustomerId"].Width = 70;
            }
            if (dgvCustomers.Columns["FullName"] != null)
            {
                dgvCustomers.Columns["FullName"].HeaderText = "Họ tên";
                dgvCustomers.Columns["FullName"].Width = 150;
            }
            if (dgvCustomers.Columns["Phone"] != null)
            {
                dgvCustomers.Columns["Phone"].HeaderText = "SĐT";
                dgvCustomers.Columns["Phone"].Width = 120;
            }
            if (dgvCustomers.Columns["Address"] != null)
            {
                dgvCustomers.Columns["Address"].HeaderText = "Địa chỉ";
                dgvCustomers.Columns["Address"].Width = 200;
            }

            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;
            dgvCustomers.ReadOnly = true;
            dgvCustomers.AllowUserToAddRows = false;
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            try
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];

                txtID.Text = row.Cells["CustomerId"].Value?.ToString() ?? "";
                txtName.Text = row.Cells["FullName"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            try
            {
                ToggleBusy(true);

                Customer c = new Customer
                {
                    FullName = txtName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Address = txtAddress.Text.Trim()
                };

                await _customerService.AddCustomerAsync(c);

                MessageBox.Show("Thêm khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusy(false);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || !int.TryParse(txtID.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Chọn khách hàng cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            try
            {
                ToggleBusy(true);

                Customer c = new Customer
                {
                    CustomerId = id,
                    FullName = txtName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Address = txtAddress.Text.Trim()
                };

                await _customerService.UpdateCustomerAsync(c);

                MessageBox.Show("Cập nhật khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusy(false);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text) || !int.TryParse(txtID.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Chọn khách hàng cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Bạn có chắc muốn xóa khách hàng '{txtName.Text}' không?\n\nLưu ý: Khách hàng có xe hoặc lịch sử sửa chữa sẽ không thể xóa.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                ToggleBusy(true);
                
                await _customerService.DeleteCustomerAsync(id);

                MessageBox.Show("Xóa khách hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusy(false);
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                await LoadDataAsync();
                return;
            }

            try
            {
                ToggleBusy(true);
                
                var result = await _customerService.SearchCustomerAsync(keyword);
                dgvCustomers.DataSource = null;
                dgvCustomers.DataSource = result;
                SetUpGridView();
                dgvCustomers.ClearSelection();
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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
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
            txtSearch.Clear();
            ClearInputs();
            await LoadDataAsync();
        }

        private async void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtID.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            
            if (dgvCustomers.Rows.Count > 0)
                dgvCustomers.ClearSelection();
        }

        private void ToggleBusy(bool busy)
        {
            UseWaitCursor = busy;
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
            
            // Disable/enable input controls
            txtID.Enabled = !busy;
            txtName.Enabled = !busy;
            txtPhone.Enabled = !busy;
            txtAddress.Enabled = !busy;
            
            // Disable/enable search controls
            txtSearch.Enabled = !busy;
            
            // Disable/enable buttons
            btnAdd.Enabled = !busy;
            btnUpdate.Enabled = !busy;
            btnDelete.Enabled = !busy;
            btnSearch.Enabled = !busy;
            btnReload.Enabled = !busy;
            btnClear.Enabled = !busy;
            
            // Disable grid interaction
            dgvCustomers.Enabled = !busy;
        }
    }
}
