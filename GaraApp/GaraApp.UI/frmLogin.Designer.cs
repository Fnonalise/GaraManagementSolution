namespace GaraApp.UI
{
    partial class frmLogin
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlMain = new Panel();
            linkRegister = new LinkLabel();
            btnExit = new Button();
            btnLogin = new Button();
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
            pnlMain.Controls.Add(linkRegister);
            pnlMain.Controls.Add(btnExit);
            pnlMain.Controls.Add(btnLogin);
            pnlMain.Controls.Add(txtPassword);
            pnlMain.Controls.Add(lblPassword);
            pnlMain.Controls.Add(txtUsername);
            pnlMain.Controls.Add(lblUsername);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Location = new Point(12, 90);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(460, 310);
            pnlMain.TabIndex = 0;
            pnlMain.Paint += pnlMain_Paint;
            // 
            // linkRegister
            // 
            linkRegister.AutoSize = true;
            linkRegister.Font = new Font("Segoe UI", 9F);
            linkRegister.Location = new Point(150, 283);
            linkRegister.Name = "linkRegister";
            linkRegister.Size = new Size(162, 20);
            linkRegister.TabIndex = 5;
            linkRegister.TabStop = true;
            linkRegister.Text = "Chưa có tài khoản? Đăng ký";
            linkRegister.LinkClicked += linkRegister_LinkClicked;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(149, 165, 166);
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(240, 230);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(170, 40);
            btnExit.TabIndex = 4;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(41, 128, 185);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 230);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(170, 40);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(50, 182);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(360, 30);
            txtPassword.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.Location = new Point(50, 156);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(86, 23);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Mật khẩu:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.Location = new Point(50, 116);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(360, 30);
            txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F);
            lblUsername.Location = new Point(50, 90);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(128, 23);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Tên đăng nhập:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(41, 128, 185);
            lblTitle.Location = new Point(130, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG NHẬP";
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
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            ClientSize = new Size(484, 411);
            Controls.Add(pnlHeader);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập - GaraApp";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnExit;
        private Panel pnlHeader;
        private Label lblAppName;
        private LinkLabel linkRegister;
    }
}
