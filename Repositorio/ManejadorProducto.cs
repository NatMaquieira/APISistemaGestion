using SistemaGestion.Modelos;
using System.Data;
using System.Data.SqlClient;


namespace SistemaGestion.Repositorio
{
    public class ManejadorProducto
    {
        private static string cadenaConexion = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Producto InsertarProducto(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Producto(Descripcion, Costo, PrecioVenta, Stock, IdUsuario) " +
                    "VALUES (@descripcion, @costo, @precioVenta, @stock, @idUsuario)", conn);
                SqlParameter nombreParam = new SqlParameter();
                nombreParam.ParameterName = "descripcion";
                nombreParam.SqlDbType = SqlDbType.VarChar;
                nombreParam.Value = producto.Descripcion;

                SqlParameter costoParam = new SqlParameter("costo", producto.Costo);
                SqlParameter precioVentaUsuParam = new SqlParameter("precioVenta", producto.PrecioDeVenta);
                SqlParameter stockParam = new SqlParameter("stock", producto.Stock);
                SqlParameter idUduarioParam = new SqlParameter("idUsuario", producto.IdUsuario);

                cmd.Parameters.Add(nombreParam);
                cmd.Parameters.Add(costoParam);
                cmd.Parameters.Add(precioVentaUsuParam);
                cmd.Parameters.Add(stockParam);
                cmd.Parameters.Add(idUduarioParam);

                conn.Open();
                cmd.ExecuteNonQuery();
                return null;
            }
        }

        public static Producto ModificarProducto(Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("UPDATE Producto" +
                    "SET Costo = @costo," +
                    "SET PrecioVenta = @precioVenta," +
                    "SET Stock = @stock) " +
                    "Set IdUsuario = @idUsuario" +
                    "WHERE Descripcion = @descripcion", conn);

                comando.Parameters.AddWithValue("@id", producto.Id);
                comando.Parameters.AddWithValue("@descripciones", producto.Descripcion);
                comando.Parameters.AddWithValue("@costo", producto.Costo);
                comando.Parameters.AddWithValue("@precioVenta", producto.PrecioDeVenta);
                comando.Parameters.AddWithValue("@stock", producto.Stock);
                comando.Parameters.AddWithValue("@idUsuario", producto.IdUsuario);
                conn.Open();
                return comando.ExecuteNonQuery();
            }
        }
        public static int EliminarProducto(int id)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("DELETE FROM Producto" +
                    "WHERE id=@id", conn);
                comando.Parameters.AddWithValue("@id", id);
                conn.Open();
                return comando.ExecuteNonQuery();

            }
        }
    }
}
