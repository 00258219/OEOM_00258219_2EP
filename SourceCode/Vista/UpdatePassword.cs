using System;
using System.Windows.Forms;

namespace SourceCode
{
    public partial class UpdatePassword : UserControl
    {
        public UpdatePassword()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(new SignIn());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(new SignIn());
        }
    }
}