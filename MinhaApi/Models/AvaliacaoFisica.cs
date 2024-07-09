using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaApi.Models
{
    public class AvaliacaoFisica
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int InstrutorId { get; set; }
        public string NomeSala { get; set; }
        public DateTime Horario { get; set; }
       //[NotMapped]
        [ForeignKey("AlunoId")]
       public  Cliente? Cliente { get; set; }
       // [NotMapped]
        [ForeignKey("InstrutorId")]
       public  Instrutor? Instrutor { get; set; }

    }
}
