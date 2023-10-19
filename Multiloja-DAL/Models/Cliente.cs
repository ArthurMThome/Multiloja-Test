namespace Multiloja_DAL.Models
{
    public class Cliente
    {
        public int idCliente { get; set; }

        public int idDocumento { get; set; }

        public string strPrimeiroNome { get; set; }

        public string strUltimoNome { get; set; }

        public string strCelular { get; set; }

        public string strEmail { get; set; }

        public DateTime dtDataNascimento { get; set; }

        public int idStatus { get; set; }

        public DateTime dtDataCriacao { get; set; }

        public DateTime dtDataAlterado { get; set; }

        public int idCarrinho { get; set; }


        public Documento Documento { get; set; }

        public Carrinho Carrinho { get; set; }

        public Status Status { get; set; }
    }
}
