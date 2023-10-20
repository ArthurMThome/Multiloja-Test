using Multiloja_DAL.Models;

namespace Multiloja_DAL.Repositories.ClienteRepositories.Interfaces
{
    public interface IClienteRepository
    {
        int Create(Cliente obj);
        List<Cliente> GetAll();
    }
}
