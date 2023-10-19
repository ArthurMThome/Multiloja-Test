namespace Multiloja_DAL.Models
{
    public class Produto
    {
        public int idProduto { get; set; }

        public string strSKU { get; set; }

        public string strTitulo { get; set; }

        public string strDescricao { get; set; }

        public Decimal decValor { get; set; }

        public DateTime dtDataCriacao { get; set; }

        public DateTime dtDataAlteracao { get; set; }

        public int idStatus { get; set; }


        public Status Status { get; set; }
    }
}
