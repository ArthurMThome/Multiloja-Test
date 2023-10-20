using Multiloja_BLL.ViewObjects;

namespace Multiloja_BLL.Services.ClienteServices.Interfaces
{
    public interface IClienteService
    {
        DefaultReturn<int> Create(ClienteVO obj);
        DefaultReturn<List<ClienteVO>> GetAll();
    }
}
