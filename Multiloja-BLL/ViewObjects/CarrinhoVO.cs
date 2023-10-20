namespace Multiloja_BLL.ViewObjects
{
    public class CarrinhoVO
    {
        public int CarrinhoId { get; set; }

        public int ProdutoId { get; set; }

        public DateTime DataCriacao { get; set; }

        public int StatusId { get; set; }

        public int ClienteId { get; set; }

        public string CodigoCarrinho { get; set; }
    }
}
