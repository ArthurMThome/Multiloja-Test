using Multiloja_BLL.Converters;
using Multiloja_BLL.Services.ProdutoServices.Interfaces;
using Multiloja_BLL.ViewObjects;
using Multiloja_DAL.Repositories.ProdutoRepositories.Interfaces;

namespace Multiloja_BLL.Services.ProdutoServices
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        private readonly ProdutoConverter _converter;

        public ProdutoService(
            IProdutoRepository repository
            )
        {
            _repository = repository;
            _converter = new ProdutoConverter();
        }

        public DefaultReturn<int> Create(ProdutoVO obj)
        {
            try
            {
                var retornoInt = _repository.Create(_converter.Parse(obj));

                return new DefaultReturn<int> { httpStatusCode = System.Net.HttpStatusCode.OK, msg = "Produto criado com sucesso." };
            }
            catch (Exception ex)
            {
                return new DefaultReturn<int> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = $"Erro: {ex.Message}." };
            }
        }

        public DefaultReturn<ProdutoVO> FindById(int id)
        {
            try
            {
                var retornoTipo = _repository.FindById(id);

                if (retornoTipo == null)
                    return new DefaultReturn<ProdutoVO> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = "Produto não encontrado." };

                return new DefaultReturn<ProdutoVO> { httpStatusCode = System.Net.HttpStatusCode.OK, obj = _converter.Parse(retornoTipo) };
            }
            catch (Exception ex)
            {
                return new DefaultReturn<ProdutoVO> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = $"Erro: {ex.Message}." };
            }
        }

        public DefaultReturn<List<ProdutoVO>> GetAll()
        {
            try
            {
                var retornoList = _repository.GetAll();

                if (retornoList == null || retornoList.Count <= 0)
                    return new DefaultReturn<List<ProdutoVO>> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = "A lista está vazia." };

                return new DefaultReturn<List<ProdutoVO>> { httpStatusCode = System.Net.HttpStatusCode.OK, obj = _converter.Parse(retornoList) };
            }
            catch (Exception ex)
            {
                return new DefaultReturn<List<ProdutoVO>> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = $"Erro: {ex.Message}." };
            }
        }
    }
}
