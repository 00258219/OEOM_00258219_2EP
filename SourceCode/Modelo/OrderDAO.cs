using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SourceCode.Modelo
{
    public class OrderDAO
    {
        //Obtener todas las ordenes de un cliente (segun id)
        public static List<Order> GetList()
        {
            try
            { 
                string sql = "SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, "+ 
                "ad.address FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au WHERE ao.idProduct = pr.idProduct " +
                $"AND ao.idAddress = ad.idAddress AND ad.idUser = au.idUser AND au.idUser = {CurrentUser.User.id};";

                DataTable dt = ConnectionDB.ExecuteQuery(sql);

                List<Order> lista = new List<Order>();
                foreach (DataRow fila in dt.Rows)
                {
                    Order u = new Order();
                    u.id = Convert.ToInt32(fila[0]);
                    u.date = Convert.ToDateTime(fila[1]);
                    u.idProduct = Convert.ToInt32(fila[2]);
                    u.idAddres = Convert.ToInt32(fila[3]);

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
        
        //Obtener todas las ordenes de un cliente (segun id)
        public static DataTable SelectOrderUserFromOrder()
        {
            try
            { 
                var dt = ConnectionDB.ExecuteQuery("SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, "+ 
                "ad.address FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au WHERE ao.idProduct = pr.idProduct " +
                $"AND ao.idAddress = ad.idAddress AND ad.idUser = au.idUser AND au.idUser = {CurrentUser.User.id};");
                
                return  dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos");
                return null;
            }
        }
        
        //Obtener todas las ordenes
        public static DataTable SelectFromOrder()
        {
            try
            { 
                var dt = ConnectionDB.ExecuteQuery("SELECT ao.idOrder, ao.createDate, pr.name, au.fullname, "+
                 "ad.address FROM APPORDER ao, ADDRESS ad, PRODUCT pr, APPUSER au WHERE " +
                 "ao.idProduct = pr.idProduct AND ao.idAddress = ad.idAddress AND ad.idUser = au.idUser;");
                
                return  dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos");
                return null;
            }
        }
        
        //Agregar orden (necesita que existan direcciones, productos), en C# tomar la fecha del sistema para el date
        public static void AddNew(string qry)
        {
            try
            {
                string sql = String.Format("INSERT INTO APPORDER(createDate, idProduct, idAddress) " +
                                           $"values({qry});");
                //VALUES('26-05-2020', 1, 1);
            
                ConnectionDB.ExecuteNonQuery(sql);
                MessageBox.Show("Orden agregada");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al crear orden");
            }
        }
        
        //Eliminar una orden (por id)
        public static void RemoveOrder(int qry)
        {
            try
            {
                string sql = String.Format($"DELETE FROM APPORDER WHERE idOrder = {qry}");

                ConnectionDB.ExecuteNonQuery(sql);
                MessageBox.Show("Tu orden fue eliminada");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al eliminar orden");
            }
        }
        
    }
}