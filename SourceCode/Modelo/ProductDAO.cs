using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SourceCode.Modelo
{
    public class ProductDAO
    {
    //Obtener todos los productos de un negocio (segun id)
        public static List<Business> GetList(int qry)
        {
            try
            {
                string sql = $"SELECT p.idProduct, p.name FROM PRODUCT p WHERE idBusiness = {qry}";

                DataTable dt = ConnectionDB.ExecuteQuery(sql);

                List<Business> lista = new List<Business>();
                foreach (DataRow fila in dt.Rows)
                {
                    Business u = new Business();
                    u.id = Convert.ToInt32(fila[0]);
                    u.name = fila[1].ToString();
                    u.description = fila[2].ToString();

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
        public static DataTable SelectFromBusiness()
        {
            try
            {
                var dt = ConnectionDB.ExecuteQuery($"SELECT p.idProduct, p.name, b.name FROM PRODUCT p, " +
                                                   $"b BUSINESS WHERE p.idBusiness = b.idBusiness");
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