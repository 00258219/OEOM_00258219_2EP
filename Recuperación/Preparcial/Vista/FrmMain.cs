using Preparcial.Modelo;
using Preparcial.Controlador;
using System.Windows.Forms;
using System.Linq;
using System;

namespace Preparcial.Vista
{
    public partial class FrmMain : Form
    {
        //10 Correcion: Inicializar variable
        private Usuario u = null;

        public FrmMain(Usuario u)
        {
            InitializeComponent();
            this.u = u;
            
            //6 Correcion: el text no correspondia a la accion.
            this.groupBox3.Text = "Actualizar Stock";
        }

        private void bttnCreateUser_Click(object sender, EventArgs e)
        {
            if (!txtNewUser.Text.Equals(""))
            {
                ControladorUsuario.CrearUsuario(txtNewUser.Text);
                ActualizarCrearUsuario();
                
            }
        }

        private void ActualizarCrearUsuario()
        {
            dgvCreateUser.DataSource = ControladorUsuario.GetUsuariosTable();
        }

        private void ActualizarInventario()
        {
            dgvInventary.DataSource = ControladorInventario.GetProductosTable();
        }

        private void ActualizarOrdenes()
        {
            dgvAllOrders.DataSource = ControladorPedido.GetPedidosTable();
        }

        private void ActualizarOrdenesUsuario()
        {
            dgvMyOrders.DataSource = ControladorPedido.GetPedidosUsuarioTable(u.IdUsuario);
            //Correcion: Inicializar variable
            cmbProductMakeOrder.DataSource = null;
            cmbProductMakeOrder.ValueMember = "idarticulo";
            cmbProductMakeOrder.DisplayMember = "producto";
            cmbProductMakeOrder.DataSource = ControladorInventario.GetProductos();
        }

        private void bttnAddInventary_Click(object sender, EventArgs e)
        {
            //5 Correcion: Si almenos uno esta vacio debe saltar el mensaje, no si todos estan vacios.
            if (txtProductNameInventary.Text.Equals("") ||
                txtDescriptionInventary.Text.Equals("") ||
                txtPriceInventary.Text.Equals("") ||
                txtStockInventary.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {
                //9 Correcion: Buenas practicas (pasa la linea)
                ControladorInventario.AnadirProducto(txtProductNameInventary.Text,
                    txtDescriptionInventary.Text,
                    txtPriceInventary.Text, txtStockInventary.Text);

                ActualizarInventario();
            }
        }

        private void bttnDeleteInventary_Click(object sender, EventArgs e)
        {
            if(txtDeleteInventary.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {
                ControladorInventario.EliminarProducto(txtDeleteInventary.Text);
                ActualizarInventario();
            }
        }

        private void bttnUpdateStockInventary_Click(object sender, EventArgs e)
        {
            // 8 Correcion: aqui debe ser un 'or' para que ningun campo quede vacio
            if (txtUpdateStockIdInventary.Text.Equals("") || txtUpdateStockInventary.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {
                ControladorInventario.ActualizarProducto(txtUpdateStockIdInventary.Text, txtUpdateStockInventary.Text);
                ActualizarInventario();
            }
        }

        private void bttnMakeOrder_Click(object sender, EventArgs e)
        {
            if (txtMakeOrderQuantity.Text.Equals(""))
                MessageBox.Show("No puede dejar campos vacios");
            else
            {
                //Correcion: Buenas practicas (pasa la linea)
                ControladorPedido.HacerPedido(u.IdUsuario, cmbProductMakeOrder.SelectedValue.ToString(), 
                    txtMakeOrderQuantity.Text);
                ActualizarOrdenesUsuario();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name.Equals("createNewUserTab") && u.Admin)
                ActualizarCrearUsuario();

            else if (tabControl1.SelectedTab.Name.Equals("inventaryTab") && u.Admin)
                ActualizarInventario();

            else if (tabControl1.SelectedTab.Name.Equals("createOrderTab") && !u.Admin)
                ActualizarOrdenesUsuario();

            else if (tabControl1.SelectedTab.Name.Equals("viewOrdersTab") && u.Admin)
                ActualizarOrdenes();
            //4 Correcion: En ninguno de los casos al volver al 'generalTab' debe apararecer un mensaje
            else if (tabControl1.SelectedTab.Name.Equals("generalTab"))
                return;
            
            else
            {
                MessageBox.Show("No tiene permisos para ver esta pestana");
                tabControl1.SelectedTab = tabControl1.TabPages[0];
            }

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Correcion: Buenas practicas
            Application.Exit();
        }
    }
}
