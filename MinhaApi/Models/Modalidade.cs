namespace MinhaApi.Models
{
    public class Modalidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public int InstrutorId { get; set; } 
    }
}
