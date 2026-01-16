namespace GaraApp.UI
{
    partial class frmRegister
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlMain = new Panel();
            chkIsAdmin = new CheckBox();
            btnCancel = new Button();
            btnRegister = new Button();
            txtConfirmPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            lblTitle = new Label();
            pnlHeader = new Panel();
            lblAppName = new Label();
            pnlMain.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(chkIsAdmin);
            pnlMain.Controls.Add(btnCancel);
            pnlMain.Controls.Add(btnRegister);
            pnlMain.Controls.Add(txtConfirmPassword);
            pnlMain.Controls.Add(lblConfirmPassword);
            pnlMain.Controls.Add(txtFullName);
            pnlMain.Controls.Add(lblFullName);
            pnlMain.Controls.Add(txtPassword);
            pnlMain.Controls.Add(lblPassword);
            pnlMain.Controls.Add(txtUsername);
            pnlMain.Controls.Add(lblUsername);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Location = new Point(12, 90);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(460, 420);
            pnlMain.TabIndex = 0;
            // 
            // chkIsAdmin
            // 
            chkIsAdmin.AutoSize = true;
            chkIsAdmin.Location = new Point(50, 320);
            chkIsAdmin.Name = "chkIsAdmin";
            chkIsAdmin.Size = new Size(201, 24);
            chkIsAdmin.TabIndex = 5;
            chkIsAdmin.Text = "Đăng ký với quyền Admin";
            chkIsAdmin.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(149, 165, 166);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(240, 360);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(170, 40);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(41, 128, 185);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(50, 360);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(170, 40);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Đăng ký";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtConfirmPassword.Location = new Point(50, 278);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.Size = new Size(360, 30);
            txtConfirmPassword.TabIndex = 4;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 10F);
            lblConfirmPassword.Location = new Point(50, 252);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(162, 23);
            lblConfirmPassword.TabIndex = 8;
            lblConfirmPassword.Text = "Xác nhận mật khẩu:";
            lblConfirmPassword.Click += lblConfirmPassword_Click;
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.Location = new Point(50, 212);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(360, 30);
            txtFullName.TabIndex = 3;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 10F);
            lblFullName.Location = new Point(50, 186);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(66, 23);
            lblFullName.TabIndex = 6;
            lblFullName.Text = "Họ tên:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(50, 146);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(360, 30);
            txtPassword.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.Location = new Point(50, 120);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(86, 23);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(50, 80);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(360, 30);
            txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F);
            lblUsername.Location = new Point(50, 54);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(128, 23);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Tên đăng nhập:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(41, 128, 185);
            lblTitle.Location = new Point(152, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(151, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG KÝ";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(41, 128, 185);
            pnlHeader.Controls.Add(lblAppName);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(484, 80);
            pnlHeader.TabIndex = 1;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(65, 20);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(361, 37);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "HỆ THỐNG QUẢN LÝ GARA";
            // 
            // frmRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(484, 521);
            Controls.Add(pnlHeader);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký tài khoản - GaraApp";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.CheckBox chkIsAdmin;
    }
}
