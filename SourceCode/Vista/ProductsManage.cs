using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SourceCode.Modelo;

namespace SourceCode
{
    public partial class ProductsManage : UserControl
    {
    
        private List<Business> business;
        private List<Product> products;
        private int businessId = 0;
        private string removeTextInit = "";
        public ProductsManage()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = ProductDAO.SelectFromProduct();
            removeTextInit = this.label5.Text;
            
            business = BusinessDAO.GetList();
            var names = new object[business.Count];
            int n = 0;
            foreach (var i in business)
            {
                names[n] = i.id+" - "+i.name;
                n++;
            }
            this.comboBox1.Items.AddRange(names);
            this.comboBox2.Items.AddRange(names);

        }
        
        private  void  resetComboBox3()
        {
            products = ProductDAO.GetList(businessId);
            var names = new object[products.Count];
            int n = 0;
            foreach (var i in products)
            {
                names[n] = i.id+" - "+i.name;
                n++;
            }

            this.comboBox3.SelectedIndex = -1;
            this.comboBox3.Items.Clear();
            this.comboBox3.Items.AddRange(names);
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == -1)
            {
                businessId = 0;
                return;
            }
            businessId = business[this.comboBox1.SelectedIndex].id;
            products = ProductDAO.GetList(businessId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!this.textBox1.Text.Equals("") && this.comboBox1.SelectedIndex != -1)
            {
                ProductDAO.AddNew($"{businessId},'{this.textBox1.Text}'");
                this.textBox1.Text = "";
                this.dataGridView1.DataSource = ProductDAO.SelectFromProduct();
                this.comboBox1.SelectedIndex = -1;
            }else
                MessageBox.Show("Completa los campos");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox2.SelectedIndex == -1)
            {
                businessId = 0;
                this.comboBox3.SelectedIndex = -1;
                this.comboBox3.Items.Clear();
                return;
            }
            businessId = business[this.comboBox2.SelectedIndex].id;
            products = ProductDAO.GetList(businessId);
            resetComboBox3();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = this.comboBox3.SelectedIndex;
            if (num == -1)
            {
                this.label5.Text = removeTextInit;
            }else
                this.label5.Text = $"Producto:\nid: {products[num].id}\nnombre: {products[num].name}" +
                                   $"\nnegocio: {business[this.comboBox2.SelectedIndex].name}";   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = this.comboBox3.SelectedIndex;
            if (num != -1 && businessId != 0)
            {
                ProductDAO.RemoveProduct(products[num].id);
                resetComboBox3();
                this.comboBox2.SelectedIndex = -1;
                this.dataGridView1.DataSource = ProductDAO.SelectFromProduct();
            }
            else
                MessageBox.Show("Selecciona una opcion antes de eliminar");
        }
        

    }
}