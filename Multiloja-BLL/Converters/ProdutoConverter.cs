using Multiloja_BLL.Converters.Converter;
using Multiloja_BLL.ViewObjects;
using Multiloja_DAL.Models;

namespace Multiloja_BLL.Converters
{
    public class ProdutoConverter : IConverter<ProdutoVO, Produto>, IConverter<Produto, ProdutoVO>
    {
        public Produto Parse(ProdutoVO origin)
        {
            if (origin == null) return null;

            return new Produto()
            {
                idProduto = origin.ProdutoId,
                strSku = origin.Sku,
                strTitulo = origin.Titulo,
                strDescricao = origin.Descricao,
                decValor = origin.Valor,
                dtDataCriacao = origin.DataCriacao,
                dtDataAlterado = origin.DataAlterado,
                idStatus = origin.StatusId,
                intQuantidade = origin.Quantidade
            };
        }

        public List<Produto> Parse(List<ProdutoVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public ProdutoVO Parse(Produto origin)
        {
            if (origin == null) return null;

            return new ProdutoVO()
            {
                ProdutoId = origin.idProduto,
                Sku = origin.strSku,
                Titulo = origin.strTitulo,
                Descricao = origin.strDescricao,
                Valor = origin.decValor,
                DataCriacao = origin.dtDataCriacao,
                DataAlterado = origin.dtDataAlterado,
                StatusId = origin.idStatus,
                Quantidade = origin.intQuantidade
            };
        }

        public List<ProdutoVO> Parse(List<Produto> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

