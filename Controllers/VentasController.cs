using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Modelos;
using SistemaGestion.Repositorio;

namespace SistemaGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        [HttpGet]
        public Ventas TraerVentas()
        {
            return ManejadorVentas.obtenerVentas();
        }
    }
}
