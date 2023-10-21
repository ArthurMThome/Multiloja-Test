using Multiloja_BLL.Converters;
using Multiloja_BLL.Services.CarrinhoServices.Interfaces;
using Multiloja_BLL.ViewObjects;
using Multiloja_DAL.Repositories.CarrinhoRepositories.Interfaces;

namespace Multiloja_BLL.Services.CarrinhoServices
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly ICarrinhoRepository _repository;
        private readonly CarrinhoConverter _converter;

        public CarrinhoService(
            ICarrinhoRepository repository
            )
        {
            _repository = repository;
            _converter = new CarrinhoConverter();
        }

        public DefaultReturn<int> Create(CarrinhoVO obj)
        {
            try
            {
                var retornoInt = _repository.Create(_converter.Parse(obj));

                if(retornoInt <= 0)
                    return new DefaultReturn<int> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = "Ocorreu um erro ao criar carrinho." };

                return new DefaultReturn<int> { httpStatusCode = System.Net.HttpStatusCode.OK, obj = retornoInt };
            }
            catch (Exception ex)
            {
                return new DefaultReturn<int> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = $"Erro: {ex.Message}." };
            }
        }

        public DefaultReturn<List<CarrinhoVO>> FindByClienteId(int id)
        {
            try
            {
                var retornoList = _repository.FindByClienteId(id);

                if(retornoList == null || retornoList.Count <= 0)
                    return new DefaultReturn<List<CarrinhoVO>> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = "Carrinho desse cliente não existe." };

                return new DefaultReturn<List<CarrinhoVO>> { httpStatusCode = System.Net.HttpStatusCode.OK, obj = _converter.Parse(retornoList) };
            }
            catch (Exception ex)
            {
                return new DefaultReturn<List<CarrinhoVO>> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = $"Erro: {ex.Message}." };
            }
        }

        public DefaultReturn<bool> Delete(string idCarrinho)
        {
            try
            {
                var retornoBool = _repository.Update(idCarrinho);

                if (!retornoBool)
                    return new DefaultReturn<bool> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = "Erro ao excluir produto do carrinho." };

                return new DefaultReturn<bool> { httpStatusCode = System.Net.HttpStatusCode.OK, obj = retornoBool };
            }
            catch (Exception ex)
            {
                return new DefaultReturn<bool> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = $"Erro: {ex.Message}." };
            }
        }
    }
}
