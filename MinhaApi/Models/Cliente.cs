namespace MinhaApi.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public int Idade { get; set; }
        public int PlanoId { get; set; }
    }
}
