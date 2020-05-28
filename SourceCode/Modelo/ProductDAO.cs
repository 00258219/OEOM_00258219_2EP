using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SourceCode.Modelo
{
    public class ProductDAO
    {
    //Obtener todos los productos de un negocio (segun id)
        public static List<Product> GetList(int qry)
        {
            try
            {
                string sql = $"SELECT * FROM PRODUCT WHERE idBusiness = {qry}";

                DataTable dt = ConnectionDB.ExecuteQuery(sql);

                List<Product> lista = new List<Product>();
                foreach (DataRow fila in dt.Rows)
                {
                    Product u = new Product();
                    u.id = Convert.ToInt32(fila[0]);
                    u.name = fila[2].ToString();
                    u.idBusiness = Convert.ToInt32(fila[1]);

                    lista.Add(u);
                }
                return lista;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar datos");
                return null;
            }
        }
        
        //Obtener todos los productos
        public static List<Product> GetListComplete()
        {
            try
            {
                string sql = $"SELECT * FROM PRODUCT";

                DataTable dt = ConnectionDB.ExecuteQuery(sql);

                List<Product> lista = new List<Product>();
                foreach (DataRow fila in dt.Rows)
                {
                    Product u = new Product();
                    u.id = Convert.ToInt32(fila[0]);
                    u.name = fila[2].ToString();
                    u.idBusiness = Convert.ToInt32(fila[1]);

                    lista.Add(u);
                }
                return lista;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar datos");
                return null;
            }
        }
        
        //Obtener todos los productos de todos los negocio (unico query que cambie o es "propio") 
        public static DataTable SelectFromProduct()
        {
            try
            {
                var dt = ConnectionDB.ExecuteQuery($"SELECT p.idProduct, p.name, b.name AS \"negocio\" FROM PRODUCT p, " +
                                                   $"BUSINESS b WHERE p.idBusiness = b.idBusiness");
                return  dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos");
                return null;
            }
        }
        
        //Agregar producto (necesita que existan negocios)
        public static void AddNew(string qry)
        {
            try
            {
                string sql = String.Format("INSERT INTO PRODUCT(idBusiness, name) " +
                                           $"values({qry});");
                //VVALUES(1, 'Pizza 4');
            
                ConnectionDB.ExecuteNonQuery(sql);
                MessageBox.Show("Producto agregado");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al crear Producto");
            }
        }
        
        //Eliminar un producto (por id)
        public static void RemoveProduct(int qry)
        {
            try
            {
                string sql = String.Format($"DELETE FROM PRODUCT WHERE idProduct = {qry}");

                ConnectionDB.ExecuteNonQuery(sql);
                MessageBox.Show("Tu Producto fue eliminado");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al eliminar Producto");
            }
        }
        
    }
}