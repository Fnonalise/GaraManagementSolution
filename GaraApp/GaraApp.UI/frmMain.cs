using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaraApp.UI
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();

            IsMdiContainer = true;
            
            // Hiển thị thông tin người dùng đã đăng nhập
            this.Text = $"Hệ thống quản lý Gara - Người dùng: {frmLogin.LoggedInFullName} ({frmLogin.LoggedInRole})";
        }

        // Thoát
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // =========================
        // OPEN CHILD FORM (chống trùng)
        // =========================
        private void OpenChildForm(Form childform)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == childform.GetType())
                {
                    f.Activate();
                    return;
                }
            }

            childform.MdiParent = this;
            childform.Show();
        }
        // =========================
        // MENU CLICK EVENTS
        // =========================
        private void mnuCustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCustomer());
        }

        private void mnuCars_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmCar());
        }

        private void mnuParts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPart());
        }

        private void mnuServices_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmService());
        }

        private void mnuRepairOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmRepairOrder());
        }

        private void mnuRevenue_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmReportRevenue());
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
