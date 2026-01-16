using GaraApp.BLL;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace GaraApp.UI
{
    public partial class frmLogin : Form
    {
        private readonly UserService _userService = new UserService();

        public static int LoggedInUserId { get; private set; }
        public static string LoggedInUsername { get; private set; } = "";
        public static string LoggedInFullName { get; private set; } = "";
        public static string LoggedInRole { get; private set; } = "";

        public frmLogin()
        {
            InitializeComponent();

            txtUsername.KeyDown += TxtUsername_KeyDown;
            txtPassword.KeyDown += TxtPassword_KeyDown;
        }

        private void TxtUsername_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void TxtPassword_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                ToggleBusy(true);

                var user = await _userService.AuthenticateAsync(username, password);

                if (user == null)
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                // Save logged in user info
                LoggedInUserId = user.UserId;
                LoggedInUsername = user.Username;
                LoggedInFullName = user.FullName;
                LoggedInRole = user.Role;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đăng nhập:\n\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ToggleBusy(false);
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var registerForm = new frmRegister())
            {
                if (registerForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập với tài khoản vừa tạo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
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
            btnLogin.Enabled = !busy;
            btnExit.Enabled = !busy;
            linkRegister.Enabled = !busy;
        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
