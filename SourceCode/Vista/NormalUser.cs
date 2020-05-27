using System;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class NormalUser : UserControl
    {
        public NormalUser()
        {
            InitializeComponent();
            this.panel1.Controls.Add(new AccountManage());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(new SignIn());
        }
    }
}