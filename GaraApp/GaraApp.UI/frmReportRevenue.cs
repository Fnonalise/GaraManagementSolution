using GaraApp.BLL;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaraApp.UI
{
    public partial class frmReportRevenue : Form
    {
        private readonly ReportService _reportService = new ReportService();

        public frmReportRevenue()
        {
            InitializeComponent();

            // Wire up events
            btnRun.Click += btnRun_Click;

            // Set date format
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = "dd/MM/yyyy";
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = "dd/MM/yyyy";

            // Set default date range (current month)
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;
        }

        private async void frmReportRevenue_Load(object sender, EventArgs e)
        {
            // Auto-run report on load
            await RunReportAsync();
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            await RunReportAsync();
        }

        private async Task RunReportAsync()
        {
            if (dtpFrom.Value > dtpTo.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ToggleBusy(true);

                var from = dtpFrom.Value.Date;
                var to = dtpTo.Value.Date;

                var data = await _reportService.GetRevenueByDayAsync(from, to);

                // Bind to grid
                dgvRevenue.AutoGenerateColumns = true;
                dgvRevenue.DataSource = null;
                dgvRevenue.DataSource = data;
                SetUpGridView();

                // Calculate summary
                if (data.Count > 0)
                {
                    int totalOrders = data.Sum(x => x.Orders);
                    decimal totalRevenue = data.Sum(x => x.Revenue);

                    lblSumOrders.Text = $"Tổng phiếu: {totalOrders}";
                    lblSumRevenue.Text = $"Tổng doanh thu: {totalRevenue:N0} VNĐ";
                }
                else
                {
                    lblSumOrders.Text = "Tổng phiếu: 0";
                    lblSumRevenue.Text = "Tổng doanh thu: 0 VNĐ";
                    MessageBox.Show("Không có dữ liệu trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chạy báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusy(false);
            }
        }

        private void SetUpGridView()
        {
            if (dgvRevenue.Columns["Day"] != null)
            {
                dgvRevenue.Columns["Day"].HeaderText = "Ngày";
                dgvRevenue.Columns["Day"].Width = 150;
                dgvRevenue.Columns["Day"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvRevenue.Columns["Orders"] != null)
            {
                dgvRevenue.Columns["Orders"].HeaderText = "Số phiếu";
                dgvRevenue.Columns["Orders"].Width = 100;
                dgvRevenue.Columns["Orders"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvRevenue.Columns["Revenue"] != null)
            {
                dgvRevenue.Columns["Revenue"].HeaderText = "Doanh thu (VNĐ)";
                dgvRevenue.Columns["Revenue"].Width = 200;
                dgvRevenue.Columns["Revenue"].DefaultCellStyle.Format = "N0";
                dgvRevenue.Columns["Revenue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            dgvRevenue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRevenue.MultiSelect = false;
            dgvRevenue.ReadOnly = true;
            dgvRevenue.AllowUserToAddRows = false;
            dgvRevenue.RowHeadersVisible = false;
        }

        private void ToggleBusy(bool busy)
        {
            UseWaitCursor = busy;
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;

            dtpFrom.Enabled = !busy;
            dtpTo.Enabled = !busy;
            btnRun.Enabled = !busy;
            dgvRevenue.Enabled = !busy;
        }
    }
}
