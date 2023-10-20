using Multiloja_DAL.Models;

namespace Multiloja_DAL.Repositories.DocumentoRepositories.Interfaces
{
    public interface IDocumentoRepository
    {
        int Create(Documento obj);
        Documento FindById(int id);
    }
}
