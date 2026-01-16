using System;
using System.Windows.Forms;

namespace GaraApp.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // TEST: M? form test hash tr??c ?? ki?m tra
            // Uncomment dòng này ?? test
            // Application.Run(new frmTestHash());
            // return;
            
            // Hi?n th? form ??ng nh?p tr??c
            using (var loginForm = new frmLogin())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // N?u ??ng nh?p thành công, m? form chính
                    Application.Run(new frmMain());
                }
                else
                {
                    // N?u ng??i dùng thoát form login, thoát ?ng d?ng
                    Application.Exit();
                }
            }
        }
    }
}
