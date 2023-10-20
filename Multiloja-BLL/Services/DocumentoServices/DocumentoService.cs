using Multiloja_BLL.Converters;
using Multiloja_BLL.Services.DocumentoServices.Interfaces;
using Multiloja_BLL.ViewObjects;
using Multiloja_DAL.Repositories.CarrinhoRepositories.Interfaces;
using Multiloja_DAL.Repositories.DocumentoRepositories.Interfaces;

namespace Multiloja_BLL.Services.DocumentoServices
{
    public class DocumentoService : IDocumentoService
    {
        private readonly IDocumentoRepository _repository;
        private readonly DocumentoConverter _converter;

        public DocumentoService(
            IDocumentoRepository repository
            )
        {
            _repository = repository;
            _converter = new DocumentoConverter();
        }

        public DefaultReturn<int> Create(DocumentoVO obj)
        {
            try
            {
                var retornoInt = _repository.Create(_converter.Parse(obj));

                if (retornoInt <= 0)
                    return new DefaultReturn<int> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = "Ocorreu um erro ao criar documento." };

                return new DefaultReturn<int> { httpStatusCode = System.Net.HttpStatusCode.OK, obj = retornoInt };
            }
            catch (Exception ex)
            {
                return new DefaultReturn<int> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = $"Erro: {ex.Message}." };
            }
        }

        public DefaultReturn<DocumentoVO> FindById(int id)
        {
            try
            {
                var retornoTipo = _repository.FindById(id);

                if (retornoTipo == null)
                    return new DefaultReturn<DocumentoVO> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = "Documento não encontrado." };

                return new DefaultReturn<DocumentoVO> { httpStatusCode = System.Net.HttpStatusCode.OK, obj = _converter.Parse(retornoTipo) };
            }
            catch (Exception ex)
            {
                return new DefaultReturn<DocumentoVO> { httpStatusCode = System.Net.HttpStatusCode.BadRequest, msg = $"Erro: {ex.Message}." };
            }
        }
    }
}
