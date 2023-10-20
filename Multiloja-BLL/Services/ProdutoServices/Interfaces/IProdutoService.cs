using Multiloja_BLL.ViewObjects;

namespace Multiloja_BLL.Services.ProdutoServices.Interfaces
{
    public interface IProdutoService
    {
        DefaultReturn<ProdutoVO> FindById(int id);
        DefaultReturn<int> Create(ProdutoVO obj);
        DefaultReturn<List<ProdutoVO>> GetAll();
    }
}
