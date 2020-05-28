using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SourceCode.Modelo;

namespace SourceCode
{
    public sealed partial class SignIn : UserControl
    {
        
        private List<User> users;
        public SignIn()
        {
            InitializeComponent();
            users = UserDAO.GetList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean aFlag = true;
            foreach (var i in users)
            {
                if (i.username.Equals(this.textBox1.Text) && i.password.Equals(this.textBox2.Text))
                {
                    aFlag = false;
                    if (i.admin)
                    {
                        CurrentUser.User = i;
                        this.Controls.Clear();
                        this.Controls.Add(new AdminUser());
                    }
                    else
                    {
                        CurrentUser.User = i;
                        this.Controls.Clear();
                        this.Controls.Add(new NormalUser());
                    }
                }
            }
            if(aFlag)
                MessageBox.Show("El usuario o la contraseña no es correcta \nIntenta de nuevo");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(new UpdatePassword());
        }
    }
}