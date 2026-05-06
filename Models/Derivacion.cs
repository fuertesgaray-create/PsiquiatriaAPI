namespace PsiquiatriaAPI.Models
{
    public class Derivacion
    {
        public int Id { get; set; }

        public string Codigo { get; set; }   // Identificador único

        public string CodigoPaciente { get; set; }  // viene de Pacientes

        public string EspecialidadOrigen { get; set; }  // Ej: Medicina General
        public string EspecialidadDestino { get; set; } = "Psiquiatria";

        public DateTime Fecha { get; set; }

        public string Estado { get; set; } = "Activo";
    }
}
