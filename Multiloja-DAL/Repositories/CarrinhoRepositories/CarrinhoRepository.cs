using Multiloja_DAL.Dapper.Interfaces;
using Multiloja_DAL.Models;
using Multiloja_DAL.Repositories.CarrinhoRepositories.Interfaces;

namespace Multiloja_DAL.Repositories.CarrinhoRepositories
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly IDataAccessDapper _dapper;

        public CarrinhoRepository(IDataAccessDapper dapper)
        {
            _dapper = dapper;
        }

        public int Create(Carrinho obj)
        {
            try
            {
                var _sql = @"   INSERT INTO tb_carrinho
                                       (idProduto
                                       ,idStatus
                                       ,idCliente
                                       ,strCodigoCarrinho)
                                 VALUES
                                       (@idProduto
                                       ,1
                                       ,@idCliente
                                       ,@strCodigoCarrinho)
                                SELECT SCOPE_IDENTITY();";


                return _dapper.InsertReturnInt(_sql, new Carrinho 
                { 
                    idProduto = obj.idProduto,
                    idCliente = obj.idCliente,
                    strCodigoCarrinho = obj.strCodigoCarrinho
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
