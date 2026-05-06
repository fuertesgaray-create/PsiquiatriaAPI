using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsiquiatriaAPI.Data;

namespace PsiquiatriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportesController : ControllerBase
    {
        private readonly HospitalContext _context;

        public ReportesController(HospitalContext context)
        {
            _context = context;
        }

        // ======================================================
        // PUNTO 6 - JOIN DE 2 TABLAS (INTERNO)
        // Cita + Consulta
        // ======================================================

        [HttpGet("join2")]
        public async Task<IActionResult> Join2()
        {
            var datos = await (
                from c in _context.Citas
                join co in _context.Consultas
                on c.Codigo equals co.CodigoCita
                where c.Estado == "Activo" && co.Estado == "Activo"
                select new
                {
                    CodigoCita = c.Codigo,
                    CodigoPaciente = c.CodigoPaciente,
                    Observacion = co.Observacion,
                    Fecha = c.Fecha
                }
            ).ToListAsync();

            return Ok(datos);
        }

        // ======================================================
        // PUNTO 7 - JOIN DE 3 TABLAS (INTERNO)
        // Cita + Consulta + Tratamiento
        // ======================================================

        [HttpGet("join3")]
        public async Task<IActionResult> Join3()
        {
            var datos = await (
                from c in _context.Citas
                join co in _context.Consultas
                on c.Codigo equals co.CodigoCita
                join t in _context.Tratamientos
                on co.Codigo equals t.CodigoConsulta
                where c.Estado == "Activo" &&
                      co.Estado == "Activo" &&
                      t.Estado == "Activo"
                select new
                {
                    CodigoCita = c.Codigo,
                    CodigoPaciente = c.CodigoPaciente,
                    CodigoPsiquiatra = c.CodigoPsiquiatra,
                    Observacion = co.Observacion,
                    Tratamiento = t.Descripcion,
                    Fecha = c.Fecha
                }
            ).ToListAsync();

            return Ok(datos);
        }
    }
}