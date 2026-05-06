using Microsoft.AspNetCore.Mvc;
using PsiquiatriaAPI.Data;
using PsiquiatriaAPI.Models;

namespace PsiquiatriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecetasController : ControllerBase
    {
        private readonly HospitalContext _context;

        public RecetasController(HospitalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Recetas.Where(x => x.Estado == "Activo"));
        }

        [HttpPost]
        public IActionResult Post(Receta receta)
        {
            receta.Estado = "Activo";
            _context.Recetas.Add(receta);
            _context.SaveChanges();
            return Ok(receta);
        }
    }
}