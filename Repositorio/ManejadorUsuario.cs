using SistemaGestion.Modelos;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestion.Repositorio
{
    public class ManejadorUsuario
    {
        //Cadena de conexion a la base de datos
        private static string cadenaConexion = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        //Creo el metodo para poder consultar los datos del usuario
        public static Usuario obtenerUsuario(string nombreUsuario)
        {

            Usuario usuario = new Usuario();
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {

                SqlCommand comando = new SqlCommand($"SELECT * FROM Usuario WHERE NombreUsuario='{nombreUsuario}' ", conn);
                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    usuario.Id = reader.GetInt64(0);
                    usuario.Nombre = reader.GetString(1);
                    usuario.Apellido = reader.GetString(2);
                    usuario.NombreDeUsuario = reader.GetString(3);
                    usuario.Contraseña = reader.GetString(4);
                    usuario.Mail = reader.GetString(5);

                }
            }
            return usuario;
        }

        // Creo el metodo para que se pueda crear un nuevo usuario
        public static int InsertarUsuario(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                //reviso que el usuario a crear no exista
                if(ManejadorUsuario.obtenerUsuario is null)
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
        }

        //Creo el metodo para modificar un usuario existente
        public static Usuario ModificarUsuario(Usuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Usuario" +
                    "SET Nombre = @nombre," +
                    "Apellido = @Apellido," +
                    "Contraseña = @contrasena," +
                    "NombreUsuario = @nombreUsuario," +
                    "Mail = @mail) " +
                    "WHERE id = @id", conn);

                cmd.Parameters.AddWithValue("@id", usuario.Id);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@nombreUsuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@contrasena", usuario.Contraseña);
                cmd.Parameters.AddWithValue("@mail", usuario.Mail);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        //Creo el metodo para realizar la eliminacion fisica de un usuario
        public static int EliminarUsuario(int id)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("DELETE FROM Usuario" +
                    "WHERE id=@id", conn);
                comando.Parameters.AddWithValue("@id", id);
                conn.Open();
                return comando.ExecuteNonQuery();
            }
        }

        // Creo el metodo de inicio de sesion
        public static Usuario Login(string mail, string passw)
        {
            using (SqlConnection conn = new SqlConnection(cadenaConexion))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Usuario WHERE Mail = @mail AND Contraseña = @passw", conn);

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
                    else
                    {
                        //en caso que la consulta sea vacia se mostrara el siguiente mensaje
                        console.writeline("El usuario o la clave enviada son incorrectos");
                    }
                }
                return null;
            }
        }
    }
}
