namespace MinhaApi.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public int Idade { get; set; }

        public int FilialId { get; set; }  
    }
}
