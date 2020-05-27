using System;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class AdminUser : UserControl
    {
        public AdminUser()
        {
            InitializeComponent();
            this.panel1.Controls.Add(new UserManage());

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(new SignIn());
        }
    }
}