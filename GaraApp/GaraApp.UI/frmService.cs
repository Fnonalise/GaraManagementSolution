using GaraApp.BLL;
using GaraApp.Entities;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaraApp.UI
{
    public partial class frmService : Form
    {
        private readonly ServiceService _serviceService = new ServiceService();
        private int _selectedServiceId = 0;

        public frmService()
        {
            InitializeComponent();

            // Wire up events
            dataGridView1.CellClick += dataGridView1_CellClick;
            txtSearch.KeyDown += txtSearch_KeyDown;
            btnSearch.Click += btnSearch_Click;
            btnReload.Click += btnReload_Click;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
        }

        private async void frmService_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                ToggleBusy(true);

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = await _serviceService.GetServicesAsync();
                SetUpGridView();
                dataGridView1.ClearSelection();
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
            if (dataGridView1.Columns["ServiceId"] != null)
            {
                dataGridView1.Columns["ServiceId"].HeaderText = "Mã DV";
                dataGridView1.Columns["ServiceId"].Width = 80;
            }
            if (dataGridView1.Columns["ServiceName"] != null)
            {
                dataGridView1.Columns["ServiceName"].HeaderText = "Tên dịch vụ";
                dataGridView1.Columns["ServiceName"].Width = 300;
            }
            if (dataGridView1.Columns["BasePrice"] != null)
            {
                dataGridView1.Columns["BasePrice"].HeaderText = "Giá cơ bản";
                dataGridView1.Columns["BasePrice"].Width = 150;
                dataGridView1.Columns["BasePrice"].DefaultCellStyle.Format = "N0";
                dataGridView1.Columns["BasePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (row.Cells["ServiceId"].Value != null && int.TryParse(row.Cells["ServiceId"].Value.ToString(), out int serviceId))
                {
                    _selectedServiceId = serviceId;
                }
                else
                {
                    _selectedServiceId = 0;
                }

                txtServiceName.Text = row.Cells["ServiceName"].Value?.ToString() ?? "";

                // Handle BasePrice with NumericUpDown
                if (row.Cells["BasePrice"].Value != null && decimal.TryParse(row.Cells["BasePrice"].Value.ToString(), out decimal price))
                {
                    nudBasePrice.Value = price >= nudBasePrice.Minimum && price <= nudBasePrice.Maximum
                        ? price
                        : 0;
                }
                else
                {
                    nudBasePrice.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Keep this for Designer compatibility
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServiceName.Focus();
                return;
            }

            if (nudBasePrice.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập Giá dịch vụ hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudBasePrice.Focus();
                return;
            }

            try
            {
                ToggleBusy(true);

                var service = new Service
                {
                    ServiceName = txtServiceName.Text.Trim(),
                    BasePrice = nudBasePrice.Value
                };

                await _serviceService.AddServiceAsync(service);

                MessageBox.Show("Thêm dịch vụ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusy(false);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedServiceId <= 0)
            {
                MessageBox.Show("Chọn dịch vụ cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServiceName.Focus();
                return;
            }

            if (nudBasePrice.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập Giá dịch vụ hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudBasePrice.Focus();
                return;
            }

            try
            {
                ToggleBusy(true);

                var service = new Service
                {
                    ServiceId = _selectedServiceId,
                    ServiceName = txtServiceName.Text.Trim(),
                    BasePrice = nudBasePrice.Value
                };

                await _serviceService.UpdateServiceAsync(service);

                MessageBox.Show("Cập nhật dịch vụ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusy(false);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedServiceId <= 0)
            {
                MessageBox.Show("Chọn dịch vụ cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Bạn có chắc muốn xóa dịch vụ '{txtServiceName.Text}' không?\n\nLưu ý: Dịch vụ đã được sử dụng trong đơn sửa chữa sẽ không thể xóa.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                ToggleBusy(true);
                await _serviceService.DeleteServiceAsync(_selectedServiceId);

                MessageBox.Show("Xóa dịch vụ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var result = await _serviceService.SearchServiceAsync(keyword);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = result;
                SetUpGridView();
                dataGridView1.ClearSelection();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void lblKeyword_Click(object sender, EventArgs e)
        {
            // Keep this for Designer compatibility
        }

        private void ClearInputs()
        {
            _selectedServiceId = 0;
            txtServiceName.Clear();
            nudBasePrice.Value = 0;

            if (dataGridView1.Rows.Count > 0)
                dataGridView1.ClearSelection();
        }

        private void ToggleBusy(bool busy)
        {
            UseWaitCursor = busy;
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;

            // Disable/enable input controls
            txtServiceName.Enabled = !busy;
            nudBasePrice.Enabled = !busy;

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
            dataGridView1.Enabled = !busy;

            // Disable groupboxes
            grpSearch.Enabled = !busy;
            grpInfo.Enabled = !busy;
        }
    }
}
