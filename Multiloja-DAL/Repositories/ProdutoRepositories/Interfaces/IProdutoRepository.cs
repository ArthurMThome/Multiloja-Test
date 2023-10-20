using Multiloja_DAL.Models;

namespace Multiloja_DAL.Repositories.ProdutoRepositories.Interfaces
{
    public interface IProdutoRepository
    {
        int Create(Produto obj);
    }
}
