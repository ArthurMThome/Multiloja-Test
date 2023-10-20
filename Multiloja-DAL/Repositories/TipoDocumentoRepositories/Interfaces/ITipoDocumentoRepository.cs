using Multiloja_DAL.Models;

namespace Multiloja_DAL.Repositories.TipoDocumentoRepositories.Interfaces
{
    public interface ITipoDocumentoRepository
    {
        TipoDocumento FindById(int id);
        List<TipoDocumento> GetAll();
    }
}
