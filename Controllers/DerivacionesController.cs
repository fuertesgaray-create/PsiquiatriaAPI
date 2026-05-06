using Microsoft.AspNetCore.Mvc;
using PsiquiatriaAPI.Data;
using PsiquiatriaAPI.Models;

namespace PsiquiatriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DerivacionesController : ControllerBase
    {
        private readonly HospitalContext _context;

        public DerivacionesController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Derivaciones.Where(x => x.Estado == "Activo"));
        }

        [HttpPost]
        public IActionResult Post(Derivacion derivacion)
        {
            derivacion.Estado = "Activo";
            _context.Derivaciones.Add(derivacion);
            _context.SaveChanges();
            return Ok(derivacion);
        }
    }
}