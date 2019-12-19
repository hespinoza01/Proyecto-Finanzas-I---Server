namespace Financecalc_Server.Models
{
    public class Cuenta
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Subclasificacion Subclasification { get; set; }
        public string Document { get; set; }
    }
}