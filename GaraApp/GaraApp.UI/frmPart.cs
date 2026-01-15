using GaraApp.BLL;
using GaraApp.Entities;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaraApp.UI
{
    public partial class frmPart : Form
    {
        private readonly PartService _partService = new PartService();

        public frmPart()
        {
            InitializeComponent();

            // Wire up events
            dgvParts.CellClick += dgvParts_CellClick;
            txtSearch.KeyDown += txtSearch_KeyDown;
            btnSearch.Click += btnSearch_Click;
            btnReload.Click += btnReload_Click;
            btnLowStock.Click += btnLowStock_Click;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnClear.Click += btnClear_Click;
        }

        private async void frmPart_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                ToggleBusy(true);

                dgvParts.AutoGenerateColumns = true;
                dgvParts.DataSource = null;
                dgvParts.DataSource = await _partService.GetPartsAsync();
                SetUpGridView();
                dgvParts.ClearSelection();
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
            if (dgvParts.Columns["PartId"] != null)
            {
                dgvParts.Columns["PartId"].HeaderText = "Mã PT";
                dgvParts.Columns["PartId"].Width = 70;
            }
            if (dgvParts.Columns["PartName"] != null)
            {
                dgvParts.Columns["PartName"].HeaderText = "Tên phụ tùng";
                dgvParts.Columns["PartName"].Width = 200;
            }
            if (dgvParts.Columns["Unit"] != null)
            {
                dgvParts.Columns["Unit"].HeaderText = "Đơn vị";
                dgvParts.Columns["Unit"].Width = 80;
            }
            if (dgvParts.Columns["UnitPrice"] != null)
            {
                dgvParts.Columns["UnitPrice"].HeaderText = "Đơn giá";
                dgvParts.Columns["UnitPrice"].Width = 120;
                dgvParts.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";
                dgvParts.Columns["UnitPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvParts.Columns["StockQty"] != null)
            {
                dgvParts.Columns["StockQty"].HeaderText = "Tồn kho";
                dgvParts.Columns["StockQty"].Width = 90;
                dgvParts.Columns["StockQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (dgvParts.Columns["MinQty"] != null)
            {
                dgvParts.Columns["MinQty"].HeaderText = "Min";
                dgvParts.Columns["MinQty"].Width = 70;
                dgvParts.Columns["MinQty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dgvParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParts.MultiSelect = false;
            dgvParts.ReadOnly = true;
            dgvParts.AllowUserToAddRows = false;
        }

        private void dgvParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow row = dgvParts.Rows[e.RowIndex];

                txtPartId.Text = row.Cells["PartId"].Value?.ToString() ?? "";
                txtPartName.Text = row.Cells["PartName"].Value?.ToString() ?? "";
                txtUnit.Text = row.Cells["Unit"].Value?.ToString() ?? "";

                // Handle UnitPrice with NumericUpDown
                if (row.Cells["UnitPrice"].Value != null && decimal.TryParse(row.Cells["UnitPrice"].Value.ToString(), out decimal price))
                {
                    nudUnitPrice.Value = price >= nudUnitPrice.Minimum && price <= nudUnitPrice.Maximum 
                        ? price 
                        : 0;
                }
                else
                {
                    nudUnitPrice.Value = 0;
                }

                // Handle StockQty with NumericUpDown
                if (row.Cells["StockQty"].Value != null && int.TryParse(row.Cells["StockQty"].Value.ToString(), out int stockQty))
                {
                    nudStockQty.Value = stockQty >= 0 ? stockQty : 0;
                }
                else
                {
                    nudStockQty.Value = 0;
                }

                // Handle MinQty with NumericUpDown
                if (row.Cells["MinQty"].Value != null && int.TryParse(row.Cells["MinQty"].Value.ToString(), out int minQty))
                {
                    nudMinQty.Value = minQty >= 0 ? minQty : 0;
                }
                else
                {
                    nudMinQty.Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn dòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvParts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Keep this for Designer compatibility
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPartName.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên phụ tùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPartName.Focus();
                return;
            }

            if (nudUnitPrice.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập Đơn giá hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudUnitPrice.Focus();
                return;
            }

            try
            {
                ToggleBusy(true);

                var part = new Part
                {
                    PartName = txtPartName.Text.Trim(),
                    Unit = string.IsNullOrWhiteSpace(txtUnit.Text) ? "pcs" : txtUnit.Text.Trim(),
                    UnitPrice = nudUnitPrice.Value,
                    StockQty = (int)nudStockQty.Value,
                    MinQty = (int)nudMinQty.Value
                };

                await _partService.AddPartAsync(part);

                MessageBox.Show("Thêm phụ tùng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm phụ tùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusy(false);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPartId.Text) || !int.TryParse(txtPartId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Chọn phụ tùng cần sửa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPartName.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên phụ tùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPartName.Focus();
                return;
            }

            if (nudUnitPrice.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập Đơn giá hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudUnitPrice.Focus();
                return;
            }

            try
            {
                ToggleBusy(true);

                var part = new Part
                {
                    PartId = id,
                    PartName = txtPartName.Text.Trim(),
                    Unit = string.IsNullOrWhiteSpace(txtUnit.Text) ? "pcs" : txtUnit.Text.Trim(),
                    UnitPrice = nudUnitPrice.Value,
                    StockQty = (int)nudStockQty.Value,
                    MinQty = (int)nudMinQty.Value
                };

                await _partService.UpdatePartAsync(part);

                MessageBox.Show("Cập nhật phụ tùng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật phụ tùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusy(false);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPartId.Text) || !int.TryParse(txtPartId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Chọn phụ tùng cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"Bạn có chắc muốn xóa phụ tùng '{txtPartName.Text}' không?\n\nLưu ý: Phụ tùng đã được sử dụng trong đơn sửa chữa sẽ không thể xóa.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            try
            {
                ToggleBusy(true);
                await _partService.DeletePartAsync(id);

                MessageBox.Show("Xóa phụ tùng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa phụ tùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                var result = await _partService.SearchPartAsync(keyword);
                dgvParts.DataSource = null;
                dgvParts.DataSource = result;
                SetUpGridView();
                dgvParts.ClearSelection();
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

        private async void btnLowStock_Click(object sender, EventArgs e)
        {
            try
            {
                ToggleBusy(true);

                var result = await _partService.GetLowStockAsync();
                dgvParts.DataSource = null;
                dgvParts.DataSource = result;
                SetUpGridView();
                dgvParts.ClearSelection();

                if (result.Count == 0)
                {
                    MessageBox.Show("Không có phụ tùng nào có tồn kho thấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Có {result.Count} phụ tùng có tồn kho thấp hơn mức tối thiểu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra tồn kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ClearInputs()
        {
            txtPartId.Clear();
            txtPartName.Clear();
            txtUnit.Text = "pcs";
            nudUnitPrice.Value = 0;
            nudStockQty.Value = 0;
            nudMinQty.Value = 0;

            if (dgvParts.Rows.Count > 0)
                dgvParts.ClearSelection();
        }

        private void ToggleBusy(bool busy)
        {
            UseWaitCursor = busy;
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;

            // Disable/enable input controls
            txtPartId.Enabled = !busy;
            txtPartName.Enabled = !busy;
            txtUnit.Enabled = !busy;
            nudUnitPrice.Enabled = !busy;
            nudStockQty.Enabled = !busy;
            nudMinQty.Enabled = !busy;

            // Disable/enable search controls
            txtSearch.Enabled = !busy;

            // Disable/enable buttons
            btnAdd.Enabled = !busy;
            btnUpdate.Enabled = !busy;
            btnDelete.Enabled = !busy;
            btnSearch.Enabled = !busy;
            btnReload.Enabled = !busy;
            btnLowStock.Enabled = !busy;
            btnClear.Enabled = !busy;

            // Disable grid interaction
            dgvParts.Enabled = !busy;
        }
    }
}
