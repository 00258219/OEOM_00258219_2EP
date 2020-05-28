using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SourceCode.Modelo
{
    public static class UserDAO
    {
        //Obtener todos los usuarios
        public static List<User> GetList()
        {
            try
            {
                string sql = "select * from APPUSER";

                DataTable dt = ConnectionDB.ExecuteQuery(sql);

                List<User> lista = new List<User>();
                foreach (DataRow fila in dt.Rows)
                {
                    User u = new User();
                    u.id = Convert.ToInt32(fila[0]);
                    u.fullname = fila[1].ToString();
                    u.username = fila[2].ToString();
                    u.password = fila[3].ToString();
                    u.admin = Convert.ToBoolean(fila[4].ToString());

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
        
        //Obtener todas las direcciones de un usuario (segun id)
        public static List<Addres> GetAddressList()
        {
            try
            {
                string sql = $"SELECT ad.idAddress, ad.address FROM ADDRESS ad WHERE idUser = {CurrentUser.User.id}";

                DataTable dt = ConnectionDB.ExecuteQuery(sql);

                List<Addres> lista = new List<Addres>();
                foreach (DataRow fila in dt.Rows)
                {
                    Addres u = new Addres();
                    u.id = Convert.ToInt32(fila[0]);
                    u.address = fila[1].ToString();
                    u.idUser = CurrentUser.User.id;

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
        
        //Obtener todas las direcciones de un usuario (segun id)
        public static DataTable SelectAddressFromUsuario()
        {
            try
            {
                var dt = ConnectionDB.ExecuteQuery($"SELECT ad.idAddress, ad.address FROM ADDRESS ad WHERE idUser = {CurrentUser.User.id}");
                return  dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos");
                return null;
            }
        }
        
        //Obtener todos los usuarios
        public static DataTable SelectFromUsuario()
        {
            try
            {
                var dt = ConnectionDB.ExecuteQuery("SELECT * FROM APPUSER;");
                return  dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos");
                return null;
            }
        }
        
        //Agregar usuario
        public static void AddNew(string qry)
        {
            try
            {
                string sql = String.Format("INSERT INTO APPUSER(fullname, username, password, userType) " +
                                           $"values({qry});");
                //VALUES('Walter Morales', 'wmorales', 'admin', true);
            
                ConnectionDB.ExecuteNonQuery(sql);
                MessageBox.Show("Usuario agregado");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al crear usuario");
            }
        }
        
        //Agregar direccion
        public static void AddAddress(string qry)
        {
            try
            {
                string sql = String.Format("INSERT INTO ADDRESS(idUser, address) " +
                                           $"values({CurrentUser.User.id}, '{qry}');");
                //VALUES(1, 'Residencia X, Casa Y, Santa Tecla, La Libertad');

                ConnectionDB.ExecuteNonQuery(sql);
                MessageBox.Show("Tu nueva dirección fue agregada");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al crear dirección");
            }
        }
        
        //Actualizar contrasena usuario
        public static void UpdatePassword(string qry)
        {
            try
            {
                string sql = String.Format($"UPDATE APPUSER SET password = '{qry}' WHERE idUser = {CurrentUser.User.id}");

                ConnectionDB.ExecuteNonQuery(sql);
                MessageBox.Show("Tu contraseña fue actualizada");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al actualizar contraseña");
            }
        }
        
        //Actualizar direccion de usuario
        public static void UpdateAddress(string qry, int ida)
        {
            try
            {
                string sql = String.Format($"UPDATE ADDRESS SET address = '{qry}' WHERE idAddress = {ida}");

                ConnectionDB.ExecuteNonQuery(sql);
                MessageBox.Show("Tu dirección fue actualizada");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al actualizar dirección");
            }
        }
        
        //Eliminar un ususario (por id)
        public static void RemoveUser(int qry)
        {
            try
            {
                string sql = String.Format($"DELETE FROM APPUSER WHERE idUser = {qry}");

                ConnectionDB.ExecuteNonQuery(sql);
                MessageBox.Show("Tu usuario fue eliminado");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al eliminar usuario");
            }
        }
        
        //Eliminar una direccion (por id)
        public static void RemoveAddress(int qry)
        {
            try
            {
                string sql = String.Format($"DELETE FROM ADDRESS WHERE idAddress = {qry}");

                ConnectionDB.ExecuteNonQuery(sql);
                MessageBox.Show("Tu dirección fue eliminado");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al eliminar dirección");
            }
        }

        
    }
}