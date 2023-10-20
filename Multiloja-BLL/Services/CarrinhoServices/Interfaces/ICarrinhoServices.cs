using Multiloja_BLL.ViewObjects;

namespace Multiloja_BLL.Services.CarrinhoServices.Interfaces
{
    public interface ICarrinhoServices
    {
        DefaultReturn<int> Create(CarrinhoVO obj);
        DefaultReturn<List<CarrinhoVO>> FindByClienteId(int id);
        DefaultReturn<bool> Delete(int idCarrinho);
    }
}
