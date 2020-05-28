using System;
using System.Windows.Forms;
using SourceCode.Modelo;

namespace SourceCode
{
    public partial class NormalUser : UserControl
    {
    
        private UserControl current;
        public NormalUser()
        {
            InitializeComponent();
            current = new AccountManage();
            this.panel1.Controls.Add(current);
            
            this.label1.Text = $"Usuario:\n{CurrentUser.User.username}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(new SignIn());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (current is AccountManage) return;
            current = new AccountManage();
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(current);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (current is OrdersManage) return;
            current = new OrdersManage();
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(current);
        }
    }
}