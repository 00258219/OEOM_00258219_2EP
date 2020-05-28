using System.Data;
using Npgsql;

namespace SourceCode.Modelo
{
    public static class ConnectionDB
    {
        
        private static readonly string sConnection =
            "Host=127.0.0.1;Port=5432;User Id=postgres;Password=123;Database=Parcial2;";

        public static DataTable ExecuteQuery(string query)
        {
            var connection = new NpgsqlConnection(sConnection);
            var ds = new DataSet();

            connection.Open();

            var da = new NpgsqlDataAdapter(query, connection);
            da.Fill(ds);

            connection.Close();
            return ds.Tables[0];
        }

        public static void ExecuteNonQuery(string act)
        {
            var connection = new NpgsqlConnection(sConnection);
            connection.Open();

            var command = new NpgsqlCommand(act, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}