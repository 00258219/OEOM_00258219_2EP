using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SourceCode.Modelo;

namespace SourceCode
{
    public partial class UpdatePassword : UserControl
    {
        private List<User> users;
        public UpdatePassword()
        {
            InitializeComponent();
            users = UserDAO.GetList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.Controls.Add(new SignIn());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean aFlag = true;
            foreach (var i in users)
            {
                if (i.username.Equals(this.textBox1.Text) && i.password.Equals(this.textBox2.Text)
                                                          && !this.textBox3.Text.Equals(""))
                {
                    aFlag = false;
                    CurrentUser.User = i;//senkar
                    UserDAO.UpdatePassword(this.textBox3.Text);
                    this.Controls.Clear();
                    this.Controls.Add(new SignIn());
                    CurrentUser.User = null;
                }
            }
            if(aFlag)
                MessageBox.Show("Completa los campos o el usuario/contraseña es incorrecta\nIntenta de nuevo");
        }
    }
}