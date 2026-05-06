using Microsoft.AspNetCore.Mvc;
using PsiquiatriaAPI.Data;
using PsiquiatriaAPI.Models;

namespace PsiquiatriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TratamientosController : ControllerBase
    {
        private readonly HospitalContext _context;

        public TratamientosController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Tratamientos.Where(x => x.Estado == "Activo"));
        }

        [HttpPost]
        public IActionResult Post(Tratamiento tratamiento)
        {
            tratamiento.Estado = "Activo";
            _context.Tratamientos.Add(tratamiento);
            _context.SaveChanges();
            return Ok(tratamiento);
        }
    }
}