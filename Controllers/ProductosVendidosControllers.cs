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
        public ProductoVendido Obtener(int idUsuario)
        {
            return ManejadorProductoVendido.obtenerProductosVendidos(idUsuario);
        }
    }
}
