using System;
using System.Windows.Forms;
using SourceCode.Modelo;

namespace SourceCode
{
    public partial class AdminUser : UserControl
    {
    
        private UserControl current;
        public AdminUser()
        {
            InitializeComponent();
            current = new UserManage();
            this.panel1.Controls.Add(current);

            this.label1.Text = $"Usuario:\n{CurrentUser.User.username}";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(new SignIn());
            CurrentUser.User = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (current is UserManage) return;
            current = new UserManage();
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(current);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (current is BusinessManage) return;
            current = new BusinessManage();
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(current);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (current is ProductsManage) return;
            current = new ProductsManage();
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(current);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (current is OrdersHistory) return;
            current = new OrdersHistory();
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(current);
        }
    }
}