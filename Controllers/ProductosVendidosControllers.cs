using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Modelos;
using SistemaGestion.Repositorio;

namespace SistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosVendidosController : ControllerBase
    {
        [HttpGet("{idUsuario}")]
        public ProductoVendido TraerProductosVendidos(int idUsuario)
        {
            return ManejadorProductoVendido.obtenerProductosVendidos(idUsuario);
        }
    }
}
