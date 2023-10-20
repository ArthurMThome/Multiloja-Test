using Multiloja_DAL.Models;

namespace Multiloja_DAL.Repositories.StatusRepositories.Interfaces
{
    public interface IStatusRepository
    {
        int Create(Status obj);
    }
}
