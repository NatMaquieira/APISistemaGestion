using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Modelos;
using SistemaGestion.Repositorio;

namespace SistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpPost]
        public void CrearProducto(Producto producto)
        {
            ManejadorProducto.InsertarProducto(producto);
        }

        [HttpGet]
        public void ModificarProducto(Producto producto)
        {
            ManejadorProducto.ModificarProducto(producto);
        }

        [HttpGet]
        public void TraerProductos()
        {
            ManejadorProducto.obtenerProductos();
        }

        [HttpDelete]
        public void EliminarProducto(int id) 
        {
            ManejadorProductoVendido.EliminarProductoVendido(id);
            ManejadorProducto.EliminarProducto(id);
        }

    }
}
