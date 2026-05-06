using Microsoft.AspNetCore.Mvc;
using PsiquiatriaAPI.Data;
using PsiquiatriaAPI.Models;

namespace PsiquiatriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitasController : ControllerBase
    {
        private readonly HospitalContext _context;

        public CitasController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Citas.Where(x => x.Estado == "Activo"));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Cita cita)
        {
            cita.Estado = "Activo";
            _context.Citas.Add(cita);
            _context.SaveChanges();
            return Ok(cita);
        }

        [HttpDelete("{codigo}")]
        public IActionResult Delete(string codigo)
        {
            var cita = _context.Citas.FirstOrDefault(x => x.Codigo == codigo);
            if (cita == null) return NotFound();

            cita.Estado = "Inactivo";
            _context.SaveChanges();

            return Ok();
        }
    }
}