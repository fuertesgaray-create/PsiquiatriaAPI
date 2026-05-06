namespace PsiquiatriaAPI.Models
{
    public class Tratamiento
    {
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string CodigoConsulta { get; set; }  // relación lógica

        public string Descripcion { get; set; }

        public string Estado { get; set; } = "Activo";
    }
}
