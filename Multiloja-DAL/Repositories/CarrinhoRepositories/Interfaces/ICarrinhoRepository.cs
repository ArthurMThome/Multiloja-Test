﻿using Multiloja_DAL.Models;

namespace Multiloja_DAL.Repositories.CarrinhoRepositories.Interfaces
{
    public interface ICarrinhoRepository
    {
        int Create(Carrinho obj);
        List<Carrinho> FindByClienteId(int id);
        bool Update(string ids);
    }
}
