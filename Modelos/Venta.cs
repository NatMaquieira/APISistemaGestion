namespace SistemaGestion.Modelos
{
    public class Venta
    {
        private int _id;
        private string _comentario;
        private int _idUsuario;

        public Venta()
        {
            _id = 0;
            _comentario = string.Empty;
            _idUsuario = 0;
        }

        public int Id
        { get { return _id; } set { _id = value; } }

        public string Comentario
        { get { return _comentario; } set { _comentario = value; } }

        public int IdUsuario
        { get { return _idUsuario; } set { _idUsuario = value; } }


    }
}
