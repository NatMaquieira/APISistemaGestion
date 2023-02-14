namespace SistemaGestion.Modelos
{
    public class Producto
    {
        private long _id;
        private string _descripcion;
        private decimal _costo;
        private decimal _precioVenta;
        private int _stock;
        private long _idUsuario;

        public Producto()
        {
            _id = 0;
            _descripcion = string.Empty;
            _costo = 0;
            _precioVenta = 0;
            _stock = 0;
            _idUsuario = 0;
        }

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public decimal Costo
        {
            get { return _costo; }
            set { _costo = value; }
        }

        public decimal PrecioDeVenta
        {
            get { return _precioVenta; }
            set { _precioVenta = value; }
        }

        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        public long IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }
    }
}
