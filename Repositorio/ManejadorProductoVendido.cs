namespace SistemaGestion.Repositorio
{


    public class ManejadorProductoVendido
    {
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
    }
     
    public List<Producto> obtenerProductosVendidos(int idUsuario)
    {
         List<Producto> productos = new List<Producto>();
         using (SqlConnection conn = new SqlConnection(cadenaConexion))
         {
            SqlCommand comando = new SqlCommand($"select Producto.Id, Producto.Descripciones, Producto.Costo, Producto.PrecioVenta, Producto.Stock, Producto.IdUsuario from ProductoVendido left join Producto on IdProducto = Producto.Id where IdUsuario = '{idUsuario}'", conn);
            conn.Open();
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                  while (reader.Read())
                  {
                     Producto productoTemporal = new Producto();
                     productoTemporal.Id = reader.GetInt64(0);
                     productoTemporal.Descripcion = reader.GetString(1);
                     productoTemporal.Costo = reader.GetDecimal(2);
                     productoTemporal.PrecioDeVenta = reader.GetDecimal(3);
                     productoTemporal.Stock = reader.GetInt32(4);
                     productoTemporal.IdUsuario = reader.GetInt64(5);

                     productos.Add(productoTemporal);
                  }
            }
                return productos;
      }
}
