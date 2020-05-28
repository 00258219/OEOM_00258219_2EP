using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SourceCode.Modelo;

namespace SourceCode
{
    public partial class BusinessManage : UserControl
    {
    
        private List<Business> business;
        private string removeTextInit = "";
        public BusinessManage()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = BusinessDAO.SelectFromBusiness();
            business = BusinessDAO.GetList();
            removeTextInit = this.label5.Text;
            resetComboBox2();
        }
        
        private  void  resetComboBox2()
        {
            business = BusinessDAO.GetList();
            var names = new object[business.Count];
            int n = 0;
            foreach (var i in business)
            {
                names[n] = i.id+" - "+i.name;
                n++;
            }

            this.comboBox2.SelectedIndex = -1;
            this.comboBox2.Items.Clear();
            this.comboBox2.Items.AddRange(names);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.textBox1.Text.Equals("") && !this.textBox2.Text.Equals(""))
            {
                BusinessDAO.AddNew($"'{this.textBox1.Text}','{this.textBox2.Text}'");
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.dataGridView1.DataSource = BusinessDAO.SelectFromBusiness();
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
                this.label5.Text = $"Negocio:\nid: {business[num].id}\nnombre: {business[num].name}";        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = this.comboBox2.SelectedIndex;
            if (num != -1)
            {
                BusinessDAO.RemoveBusiness(business[num].id);
                resetComboBox2();
                this.dataGridView1.DataSource = BusinessDAO.SelectFromBusiness();
            }else
                MessageBox.Show("Selecciona una opcion antes de eliminar");
        }
    }
}