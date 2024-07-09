namespace MinhaApi.Models
{
    public class Plano
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public int FilialId { get; set; }
    }
}
