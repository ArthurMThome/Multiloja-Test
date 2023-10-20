using Multiloja_BLL.Converters;
using Multiloja_BLL.Services.StatusServices.Interfaces;
using Multiloja_BLL.ViewObjects;
using Multiloja_DAL.Repositories.StatusRepositories.Interfaces;

namespace Multiloja_BLL.Services.StatusServices
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _repository;
        private readonly StatusConverter _converter;

        public StatusService(
            IStatusRepository repository
            )
        {
            _repository = repository;
            _converter = new StatusConverter();
        }

        public DefaultReturn<StatusVO> FindById(int id)
        {
            try
            {
                var retornoTipo = _repository.FindById(id);

                if (retornoTipo == null)
                    return new DefaultReturn<StatusVO> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = "Status não encontrado." };

                return new DefaultReturn<StatusVO> { httpStatusCode = System.Net.HttpStatusCode.OK, obj = _converter.Parse(retornoTipo) };
            }
            catch (Exception ex)
            {
                return new DefaultReturn<StatusVO> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = $"Erro: {ex.Message}." };
            }
        }
    }
}
