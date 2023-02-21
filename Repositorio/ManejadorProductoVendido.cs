namespace SistemaGestion.Repositorio
{


    public class ManejadorProductoVendido
    {
        private static string cadenaConexion = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Obtengo todos los productos vendidos
        public List<Producto> obtenerProductosVendidos(int idUsuario)
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand($"SELECT * FROM ProductoVendido WHERE IdUsuario = '{idUsuario}'", conn);
                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        manejadorProducto.obtenerProductos();
                    }
                }
                return productos;
            }
        }

        //Elimino un producto mediante el id
        public static int EliminarProductoVendido(int id)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("DELETE FROM ProductoVendido" +
                    "WHERE idProducto=@id", conn);
                comando.Parameters.AddWithValue("@id", id);
                conn.Open();
                return comando.ExecuteNonQuery();
            }
        }
    
        //Genero un nuevo registro a partir de la generacion de una venta
        public static ProductoVendido InsertarProductoVendido(int IdVenta, Producto producto)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO ProductoVendido (idProducto, Stock, idVenta) " +
                "VALUES (@idProducto, @Stock, @idVenta)", conn);
                SqlParameter nombreParam = new SqlParameter();
                nombreParam.ParameterName = "idVenta";
                nombreParam.SqlDbType = SqlDbType.VarChar;
                nombreParam.Value = ProductoVendido.idVenta;

                SqlParameter idProductoParam = new SqlParameter("idProducto", ProductoVendido.idProducto);
                SqlParameter stockParam = new SqlParameter("stock", ProductoVendido.Stock);
                SqlParameter idVentaParam = new SqlParameter("idVenta", producto.IdUsuario);

                cmd.Parameters.Add(idProductoParam);
                cmd.Parameters.Add(stockParam);
                cmd.Parameters.Add(idVentaParam);

                conn.Open();
                cmd.ExecuteNonQuery();
                return null;
            }
            
        }
    }
}
