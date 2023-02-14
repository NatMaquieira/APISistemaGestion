using SistemaGestion.Modelos;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestion.Repositorio
{
    public class ManejadorUsuario
    {
        private static string cadenaConexion = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static int InsertarUsuario(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Usuario(Nombre, Apellido, NombreUsuario, Contraseña, Mail) " +
                    "VALUES (@nombre, @apellido, @nombreUsuario, @contrasena, @mail)", conn);
                SqlParameter nombreParam = new SqlParameter();
                nombreParam.ParameterName = "nombre";
                nombreParam.SqlDbType = SqlDbType.VarChar;
                nombreParam.Value = usuario.Nombre;

                SqlParameter apellidoParam = new SqlParameter("apellido", usuario.Apellido);
                SqlParameter nombreUsuParam = new SqlParameter("nombreUsuario", usuario.NombreDeUsuario);
                SqlParameter passwParam = new SqlParameter("contrasena", usuario.Contraseña);
                SqlParameter mailParam = new SqlParameter("mail", usuario.Mail);

                cmd.Parameters.Add(nombreParam);
                cmd.Parameters.Add(apellidoParam);
                cmd.Parameters.Add(nombreUsuParam);
                cmd.Parameters.Add(passwParam);
                cmd.Parameters.Add(mailParam);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static Usuario ModificarUsuario(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Usuario" +
                    "SET Nombre = @nombre," +
                    "SET Apellido = @Apellido," +
                    "SET Contraseña = @contrasena," +
                    "SET Mail = @mail) " +
                    "WHERE NombreUsuario = @nombreUsuario", conn);

                cmd.Parameters.AddWithValue("@id", usuario.Id);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@contrasena", usuario.Contraseña);
                cmd.Parameters.AddWithValue("@mail", usuario.Mail);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static Usuario Login(string mail, string passw)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Usuario WHERE Mail = @mail AND Contraseña = @passw", conn);

                //Se utiliza SQL Parameter para reemplazar los @ de la consulta
                SqlParameter parameterMail = new SqlParameter();
                parameterMail.ParameterName = "mail";
                parameterMail.SqlValue = SqlDbType.VarChar;
                parameterMail.Value = mail;

                SqlParameter parameterContrasena = new SqlParameter();
                parameterContrasena.ParameterName = "passw";
                parameterContrasena.SqlValue = SqlDbType.VarChar;
                parameterContrasena.Value = passw;

                //Se aplica los parámetros al comando
                command.Parameters.Add(parameterMail);
                command.Parameters.Add(parameterContrasena);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        Usuario usuarioEncontrado = new Usuario();
                        reader.Read();
                        usuarioEncontrado.Nombre = reader.GetString(1);
                        usuarioEncontrado.Apellido = reader.GetString(2);
                        usuarioEncontrado.NombreDeUsuario = reader.GetString(3);
                        usuarioEncontrado.Mail = reader.GetString(5);
                        return usuarioEncontrado;
                    }
                }
                //En caso de que la consulta este vacía retornara un Usuario vacio
                return null;
            }
        }
    }
}