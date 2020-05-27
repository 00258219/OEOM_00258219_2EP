using System;
using System.Windows.Forms;

namespace SourceCode
{
    public sealed partial class SignIn : UserControl
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(new NormalUser());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(new UpdatePassword());
        }
    }
}