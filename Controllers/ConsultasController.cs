using Microsoft.AspNetCore.Mvc;
using PsiquiatriaAPI.Data;
using PsiquiatriaAPI.Models;

namespace PsiquiatriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultasController : ControllerBase
    {
        private readonly HospitalContext _context;

        public ConsultasController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Consultas.Where(x => x.Estado == "Activo"));
        }

        [HttpPost]
        public IActionResult Post(Consulta consulta)
        {
            consulta.Estado = "Activo";
            _context.Consultas.Add(consulta);
            _context.SaveChanges();
            return Ok(consulta);
        }
    }
}