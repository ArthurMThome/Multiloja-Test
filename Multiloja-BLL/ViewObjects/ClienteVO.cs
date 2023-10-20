namespace Multiloja_BLL.ViewObjects
{
    public class ClienteVO
    {
        public int ClienteId { get; set; }

        public int DocumentoId { get; set; }

        public string PrimeiroNome { get; set; }

        public string UltimoNome { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public int StatusId { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAlterado { get; set; }
    }
}
