using Multiloja_DAL.Models;

namespace Multiloja_DAL.Repositories.ProdutoRepositories.Interfaces
{
    public interface IProdutoRepository
    {
        int Create(Produto obj);
        Produto FindById(int id);
        List<Produto> FindByIds(string ids);
        List<Produto> GetAll();
    }
}
