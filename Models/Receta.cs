namespace PsiquiatriaAPI.Models
{
    public class Receta
    {
        public int Id { get; set; }
        public string Codigo { get; set; }

        public string CodigoTratamiento { get; set; }
        public string CodigoMedicamento { get; set; }

        public string Dosis { get; set; }
        public string Estado { get; set; } = "Activo";
    }
}
