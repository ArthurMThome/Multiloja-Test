using Multiloja_BLL.Converters;
using Multiloja_BLL.Services.ClienteServices.Interfaces;
using Multiloja_BLL.ViewObjects;
using Multiloja_DAL.Repositories.ClienteRepositories.Interfaces;

namespace Multiloja_BLL.Services.ClienteServices
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly ClienteConverter _converter;

        public ClienteService(
            IClienteRepository repository
            )
        {
            _repository = repository;
            _converter = new ClienteConverter();
        }

        public DefaultReturn<int> Create(ClienteVO obj)
        {
            try
            {
                var retornoInt = _repository.Create(_converter.Parse(obj));

                if (retornoInt <= 0)
                    return new DefaultReturn<int> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = "Ocorreu um erro ao criar cliente." };

                return new DefaultReturn<int> { httpStatusCode = System.Net.HttpStatusCode.OK, obj = retornoInt };
            }
            catch (Exception ex)
            {
                return new DefaultReturn<int> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = $"Erro: {ex.Message}." };
            }
        }

        public DefaultReturn<List<ClienteVO>> GetAll()
        {
            try
            {
                var retornoList = _repository.GetAll();

                if (retornoList == null || retornoList.Count <= 0)
                    return new DefaultReturn<List<ClienteVO>> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = "A lista está vazia." };

                return new DefaultReturn<List<ClienteVO>> { httpStatusCode = System.Net.HttpStatusCode.OK, obj = _converter.Parse(retornoList) };
            }
            catch (Exception ex)
            {
                return new DefaultReturn<List<ClienteVO>> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = $"Erro: {ex.Message}." };
            }
        }
    }
}
