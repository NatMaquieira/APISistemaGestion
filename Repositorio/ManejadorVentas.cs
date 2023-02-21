using SistemaGestion.Modelos;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestion.Repositorio
{
    internal class manejadorVentas
    {
        public static string cadenaConexion = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        //Creo el metodo para obtener las ventas
        public List<Venta> obtenerVentas()
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand($"select * from Ventas", conn);
                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Venta ventaTemporal = new Venta();
                        ventaTemporal.Id = reader.GetInt64(0);
                        ventaTemporal.Comentario = reader.GetString(1);
                        ventaTemporal.IdUsuario = reader.GetInt64(2);
                        return ManejadorProductoVendido.obtenerProductosVendidos(ventaTemporal.IdUsuario);
                        ventas.Add(ventaTemporal);
                    }
                }
                return ventas;
            }
        }
}
