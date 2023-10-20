using Multiloja_BLL.Converters;
using Multiloja_BLL.Services.TipoDocumentoServices.Interfaces;
using Multiloja_BLL.ViewObjects;
using Multiloja_DAL.Repositories.TipoDocumentoRepositories.Interfaces;

namespace Multiloja_BLL.Services.TipoDocumentoServices
{
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly ITipoDocumentoRepository _repository;
        private readonly TipoDocumentoConverter _converter;

        public TipoDocumentoService(
            ITipoDocumentoRepository repository
            )
        {
            _repository = repository;
            _converter = new TipoDocumentoConverter();
        }

        public DefaultReturn<TipoDocumentoVO> FindById(int id)
        {
            try
            {
                var retornoTipo = _repository.FindById(id);

                if (retornoTipo == null)
                    return new DefaultReturn<TipoDocumentoVO> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = "Tipo Documento não encontrado." };

                return new DefaultReturn<TipoDocumentoVO> { httpStatusCode = System.Net.HttpStatusCode.OK, obj = _converter.Parse(retornoTipo) };
            }
            catch (Exception ex)
            {
                return new DefaultReturn<TipoDocumentoVO> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = $"Erro: {ex.Message}." };
            }
        }

        public DefaultReturn<List<TipoDocumentoVO>> GetAll()
        {
            try
            {
                var retornoList = _repository.GetAll();

                if (retornoList == null || retornoList.Count <= 0)
                    return new DefaultReturn<List<TipoDocumentoVO>> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = "A lista está vazia." };

                return new DefaultReturn<List<TipoDocumentoVO>> { httpStatusCode = System.Net.HttpStatusCode.OK, obj = _converter.Parse(retornoList) };
            }
            catch (Exception ex)
            {
                return new DefaultReturn<List<TipoDocumentoVO>> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = $"Erro: {ex.Message}." };
            }
        }
    }
}
