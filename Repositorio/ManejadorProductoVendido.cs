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
}
