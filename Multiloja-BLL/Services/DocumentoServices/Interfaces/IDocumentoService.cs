using Multiloja_BLL.ViewObjects;

namespace Multiloja_BLL.Services.DocumentoServices.Interfaces
{
    public interface IDocumentoService
    {
        DefaultReturn<int> Create(DocumentoVO obj);
        DefaultReturn<DocumentoVO> FindById(int id);
    }
}
