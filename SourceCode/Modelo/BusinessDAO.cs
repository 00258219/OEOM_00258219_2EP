using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SourceCode.Modelo
{
    public class BusinessDAO
    {
        //Obtener todos los negocios
        public static List<Business> GetList()
        {
            try
            {
                string sql = "SELECT * FROM BUSINESS";

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
        
        //Obtener todos los negocios
        public static DataTable SelectFromBusiness()
        {
            try
            {
                var dt = ConnectionDB.ExecuteQuery("SELECT * FROM BUSINESS;");
                return  dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos");
                return null;
            }
        }
        
        //Agregar negocio
        public static void AddNew(string qry)
        {
            try
            {
                string sql = String.Format("INSERT INTO BUSINESS(name, description) " +
                                           $"values({qry});");
                //VALUES ('Pizza hut', 'Venta de pizzas y pastas');
            
                ConnectionDB.ExecuteNonQuery(sql);
                MessageBox.Show("Negocio agregado");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al crear Negocio");
            }
        }
        
        //Eliminar un negocio (por id)
        public static void RemoveBusiness(int qry)
        {
            try
            {
                string sql = String.Format($"DELETE FROM BUSINESS WHERE idBusiness = {qry}");

                ConnectionDB.ExecuteNonQuery(sql);
                MessageBox.Show("Tu Negocio fue eliminado");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al eliminar Negocio");
            }
        }
        
    }
}