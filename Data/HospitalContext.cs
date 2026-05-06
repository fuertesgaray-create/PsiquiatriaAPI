using Microsoft.EntityFrameworkCore;
using PsiquiatriaAPI.Models;

namespace PsiquiatriaAPI.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options) { }

        public DbSet<Cita> Citas { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<Derivacion> Derivaciones { get; set; }
    }
}