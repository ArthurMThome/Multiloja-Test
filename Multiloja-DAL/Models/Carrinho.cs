namespace Multiloja_DAL.Models
{
    public class Carrinho
    {
        public int idCarrinho { get; set; }

        public int idProduto { get; set; }

        public DateTime dtDataCriacao { get; set; }

        public int idStatus { get; set; }

        public int idCliente { get; set; }

        public string strCodigoCarrinho { get; set; }
    }
}
