namespace PsiquiatriaAPI.Models
{
    public class Cita
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        public string CodigoPaciente { get; set; }
        public string CodigoPsiquiatra { get; set; }

        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = "Activo";
    }
}