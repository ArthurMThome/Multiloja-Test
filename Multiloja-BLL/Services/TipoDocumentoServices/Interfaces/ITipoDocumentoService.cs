using Multiloja_BLL.ViewObjects;

namespace Multiloja_BLL.Services.TipoDocumentoServices.Interfaces
{
    public interface ITipoDocumentoService
    {
        DefaultReturn<TipoDocumentoVO> FindById(int id);
        DefaultReturn<List<TipoDocumentoVO>> GetAll();
    }
}
