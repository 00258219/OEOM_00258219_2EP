using System.Windows.Forms;
using SourceCode.Modelo;

namespace SourceCode
{
    public partial class OrdersHistory : UserControl
    {
        public OrdersHistory()
        {
            InitializeComponent();
            dataGridView1.DataSource = OrderDAO.SelectFromOrder();
        }
    }
}