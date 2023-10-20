using Multiloja_BLL.ViewObjects;

namespace Multiloja_BLL.Services.StatusServices.Interfaces
{
    public interface IStatusService
    {
        DefaultReturn<StatusVO> FindById(int id);
    }
}
