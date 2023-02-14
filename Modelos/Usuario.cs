namespace SistemaGestion.Modelos
{
    public class Usuario
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _nombreUsuario;
        private string _contraseña;
        private string _mail;

        public Usuario()
        {
            _id = 0;
            _nombre = string.Empty;
            _apellido = string.Empty;
            _nombreUsuario = string.Empty;
            _contraseña = string.Empty;
            _mail = string.Empty;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string NombreDeUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }
    }
}
