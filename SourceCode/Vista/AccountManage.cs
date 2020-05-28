using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SourceCode.Modelo;

namespace SourceCode
{
    public partial class AccountManage : UserControl
    {
        
        private List<Addres> address = new List<Addres>();
        public AccountManage()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = UserDAO.SelectAddressFromUsuario();
            resetComboBox1();
            resetComboBox2();

        }
        
        private  void  resetComboBox1()
        {
            address = UserDAO.GetAddressList();
            var names = new object[address.Count];
            int n = 0;
            foreach (var i in address)
            {
                names[n] = i.id+" - "+i.address;
                n++;
            }

            this.comboBox1.SelectedIndex = -1;
            this.comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(names);
        }
        
        private  void  resetComboBox2()
        {
            address = UserDAO.GetAddressList();
            var names = new object[address.Count];
            int n = 0;
            foreach (var i in address)
            {
                names[n] = i.id+" - "+i.address;
                n++;
            }

            this.comboBox2.SelectedIndex = -1;
            this.comboBox2.Items.Clear();
            this.comboBox2.Items.AddRange(names);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.textBox1.Text.Equals(""))
            {
                UserDAO.UpdatePassword(this.textBox1.Text);
                this.textBox1.Text = "";
            }else
                MessageBox.Show("Completa todos los campos");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!this.textBox2.Text.Equals(""))
            {
                UserDAO.AddAddress(this.textBox2.Text);
                this.textBox2.Text = "";
                resetComboBox1();
                resetComboBox2();
                this.dataGridView1.DataSource = UserDAO.SelectAddressFromUsuario();
            }else
                MessageBox.Show("Completa todos los campos");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int num = this.comboBox1.SelectedIndex;
            if (num != -1)
            {
                UserDAO.RemoveAddress(address[num].id);
                resetComboBox1();
                resetComboBox2();
                this.dataGridView1.DataSource = UserDAO.SelectAddressFromUsuario();
            }else
                MessageBox.Show("Selecciona una opcion antes de eliminar");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int num = this.comboBox2.SelectedIndex;

            if (!this.textBox3.Text.Equals("") && num != -1)
            {
                UserDAO.UpdateAddress(this.textBox3.Text, address[num].id);
                this.textBox3.Text = "";
                resetComboBox1();
                resetComboBox2();
                this.dataGridView1.DataSource = UserDAO.SelectAddressFromUsuario();
            }else
                MessageBox.Show("Completa todos los campos");
        }
    }
}