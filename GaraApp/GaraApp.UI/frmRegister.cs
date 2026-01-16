using GaraApp.BLL;
using GaraApp.Entities;
using System;
using System.Windows.Forms;

namespace GaraApp.UI
{
    public partial class frmRegister : Form
    {
        private readonly UserService _userService = new UserService();

        public frmRegister()
        {
            InitializeComponent();
            SetVietnameseText();
        }

        private void SetVietnameseText()
        {
            // Set all Vietnamese text here to ensure proper encoding
            this.Text = "Đăng ký tài khoản - GaraApp";
            lblAppName.Text = "HỆ THỐNG QUẢN LÝ GARA";
            lblTitle.Text = "ĐĂNG KÝ";
            lblUsername.Text = "Tên đăng nhập:";
            lblPassword.Text = "Mật khẩu:";
            lblFullName.Text = "Họ tên:";
            lblConfirmPassword.Text = "Xác nhận mật khẩu:";
            chkIsAdmin.Text = "Đăng ký với quyền Admin";
            btnRegister.Text = "Đăng ký";
            btnCancel.Text = "Hủy";
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (txtUsername.Text.Length < 3)
            {
                MessageBox.Show("Tên đăng nhập phải có ít nhất 3 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            try
            {
                ToggleBusy(true);

                var newUser = new User
                {
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text, // Will be hashed by UserService
                    FullName = txtFullName.Text.Trim(),
                    Role = chkIsAdmin.Checked ? "Admin" : "User",
                    IsActive = true
                };

                await _userService.CreateUserAsync(newUser);

                MessageBox.Show(
                    $"Đăng ký thành công!\n\n" +
                    $"Username: {newUser.Username}\n" +
                    $"Họ tên: {newUser.FullName}\n" +
                    $"Vai trò: {newUser.Role}\n\n" +
                    $"Bạn có thể đăng nhập ngay bây giờ!",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đăng ký:\n\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusy(false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ToggleBusy(bool busy)
        {
            UseWaitCursor = busy;
            Cursor = busy ? Cursors.WaitCursor : Cursors.Default;

            txtUsername.Enabled = !busy;
            txtPassword.Enabled = !busy;
            txtConfirmPassword.Enabled = !busy;
            txtFullName.Enabled = !busy;
            chkIsAdmin.Enabled = !busy;
            btnRegister.Enabled = !busy;
            btnCancel.Enabled = !busy;
        }

        private void lblConfirmPassword_Click(object sender, EventArgs e)
        {

        }
    }
}
