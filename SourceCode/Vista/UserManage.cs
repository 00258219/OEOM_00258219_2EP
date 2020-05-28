using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SourceCode.Modelo;

namespace SourceCode
{
    public partial class UserManage : UserControl
    {
        private List<User> users;
        private string removeTextInit = "";
        public UserManage()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = UserDAO.SelectFromUsuario();
            users = UserDAO.GetList();
            removeTextInit = this.label5.Text;
            
            var bools = new object[] {false, true};
            this.comboBox1.Items.AddRange(bools);

            resetComboBox2();

        }

        private  void  resetComboBox2()
        {
            users = UserDAO.GetList();
            var usersnames = new object[users.Count];
            int n = 0;
            foreach (var i in users)
            {
                usersnames[n] = i.id+" - "+i.username+" admin("+i.admin+")";
                n++;
            }

            this.comboBox2.SelectedIndex = -1;
            this.comboBox2.Items.Clear();
            this.comboBox2.Items.AddRange(usersnames);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.textBox1.Text.Equals("") && !this.textBox2.Text.Equals("") && this.comboBox1.SelectedIndex != -1)
            {
                foreach (var i in CurrentUser.Usersname)
                {
                    if (i.Equals(this.textBox2.Text))
                    {
                        MessageBox.Show("No puedes agregar un nombre de usuario que ya agregaste!");
                        return;
                    }
                }
                UserDAO.AddNew($"'{this.textBox1.Text}', '{this.textBox2.Text}', '{this.textBox2.Text}', " +
                               $"{this.comboBox1.SelectedItem}");
                CurrentUser.AddUsername(this.textBox2.Text);
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.comboBox1.SelectedIndex = -1;
                this.dataGridView1.DataSource = UserDAO.SelectFromUsuario();
                resetComboBox2();
            }else
                MessageBox.Show("Completa los campos");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = this.comboBox2.SelectedIndex;
            if (num == -1)
            {
                this.label5.Text = removeTextInit;
            }else
                this.label5.Text = $"Usuario:\nid: {users[num].id}\nusername: {users[num].username}" +
                               $"\nadmin: {users[num].admin}\nnombre: {users[num].fullname}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = this.comboBox2.SelectedIndex;
            if (num != -1)
            {
                UserDAO.RemoveUser(users[num].id);
                resetComboBox2();
                this.dataGridView1.DataSource = UserDAO.SelectFromUsuario();
            }else
                MessageBox.Show("Selecciona una opcion antes de eliminar");
        }
    }
}