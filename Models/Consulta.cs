namespace PsiquiatriaAPI.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        public string CodigoCita { get; set; }
        public string Observacion { get; set; }

        public string Estado { get; set; } = "Activo";
    }
}
