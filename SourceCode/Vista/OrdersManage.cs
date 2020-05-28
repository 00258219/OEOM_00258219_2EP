using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SourceCode.Modelo;

namespace SourceCode
{
    public partial class OrdersManage : UserControl
    {
        
        private List<Addres> addreses = new List<Addres>();
        private List<Product> productos = new List<Product>();
        private List<Order> orders = new List<Order>();
        private string removeTextInit = "";
        public OrdersManage()
        {
            InitializeComponent();
            removeTextInit = this.label5.Text;
            this.dataGridView1.DataSource = OrderDAO.SelectOrderUserFromOrder();
            resetComboBox1();
            resetComboBox2();
            resetComboBox3();
        }
        
        private  void  resetComboBox1()
        {
            addreses = UserDAO.GetAddressList();
            var names = new object[addreses.Count];
            int n = 0;
            foreach (var i in addreses)
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
            productos = ProductDAO.GetListComplete();
            var names = new object[productos.Count];
            int n = 0;
            foreach (var i in productos)
            {
                names[n] = i.id+" - "+i.name;
                n++;
            }

            this.comboBox2.SelectedIndex = -1;
            this.comboBox2.Items.Clear();
            this.comboBox2.Items.AddRange(names);
        }
        
        private  void  resetComboBox3()
        {
            orders = OrderDAO.GetList();
            var names = new object[orders.Count];
            int n = 0;
            foreach (var i in orders)
            {
                names[n] = i.id+" - "+i.product+" ("+i.date+")";
                n++;
            }

            this.comboBox3.SelectedIndex = -1;
            this.comboBox3.Items.Clear();
            this.comboBox3.Items.AddRange(names);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex != -1 && this.comboBox2.SelectedIndex != -1)
            {
                OrderDAO.AddNew(productos[this.comboBox2.SelectedIndex].id+", "+addreses[this.comboBox1.SelectedIndex].id);
                this.dataGridView1.DataSource = OrderDAO.SelectOrderUserFromOrder();
                resetComboBox1();
                resetComboBox2();
                resetComboBox3();
            }else
                MessageBox.Show("Selecciona todas las opciones");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = this.comboBox3.SelectedIndex;
            if (num == -1)
            {
                this.label5.Text = removeTextInit;
            }else
                this.label5.Text = $"Orden:\nid: {orders[num].id}\nproducto: {orders[num].product}" +
                                   $"\ndate: {orders[num].date}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = this.comboBox3.SelectedIndex;
            if (num != -1)
            {
                OrderDAO.RemoveOrder(orders[num].id);
                this.dataGridView1.DataSource = OrderDAO.SelectOrderUserFromOrder();
                resetComboBox1();
                resetComboBox2();
                resetComboBox3();
            }else
                MessageBox.Show("Selecciona una opcion antes de eliminar");        }
    }
}