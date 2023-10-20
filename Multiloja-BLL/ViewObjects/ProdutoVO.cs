namespace Multiloja_BLL.ViewObjects
{
    public class ProdutoVO
    {
        public int ProdutoId { get; set; }

        public string Sku { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public Decimal Valor { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAlterado { get; set; }

        public int StatusId { get; set; }

        public int Quantidade { get; set; }
    }
}
