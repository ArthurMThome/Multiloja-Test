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
                                       ,@strCodigoCarrinho);
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

        public List<Carrinho> FindByClienteId(int id)
        {
            try
            {   
                var _sql = @"   SELECT idCarrinho
                                    ,idProduto
                                    ,dtDataCriacao
                                    ,idStatus
                                    ,idCliente
                                    ,strCodigoCarrinho
                                FROM tb_carrinho
                                WHERE idCliente = @idCliente
                                AND idStatus = 1";


                return _dapper.Select<Carrinho>(_sql, new Carrinho { idCliente = @id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(int idCarrinho)
        {
            try
            {
                var _sql = @"   UPDATE tb_carrinho
                                SET 
                                    idStatus = 2
                                WHERE idCarrinho = @idCarrinho;";

                return _dapper.UpdateOrDelete<Carrinho>(_sql, new Carrinho { idCarrinho = idCarrinho });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
