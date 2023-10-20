using Multiloja_BLL.Converters.Converter;
using Multiloja_BLL.ViewObjects;
using Multiloja_DAL.Models;

namespace Multiloja_BLL.Converters
{
    public class CarrinhoConverter : IConverter<CarrinhoVO, Carrinho>, IConverter<Carrinho, CarrinhoVO>
    {
        public Carrinho Parse(CarrinhoVO origin)
        {
            if (origin == null) return null;

            return new Carrinho()
            {
                idCarrinho = origin.CarrinhoId,
                idProduto = origin.ProdutoId,
                dtDataCriacao = origin.DataCriacao,
                idStatus = origin.StatusId,
                idCliente = origin.ClienteId,
                strCodigoCarrinho = origin.CodigoCarrinho
            };
        }

        public List<Carrinho> Parse(List<CarrinhoVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public CarrinhoVO Parse(Carrinho origin)
        {
            if (origin == null) return null;

            return new CarrinhoVO()
            {
                CarrinhoId = origin.idCarrinho,
                ProdutoId = origin.idProduto,
                DataCriacao = origin.dtDataCriacao,
                StatusId = origin.idStatus,
                ClienteId = origin.idCliente,
                CodigoCarrinho = origin.strCodigoCarrinho
            };
        }

        public List<CarrinhoVO> Parse(List<Carrinho> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
