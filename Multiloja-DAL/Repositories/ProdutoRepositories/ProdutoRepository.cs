using Multiloja_DAL.Dapper.Interfaces;
using Multiloja_DAL.Models;
using Multiloja_DAL.Repositories.ProdutoRepositories.Interfaces;

namespace Multiloja_DAL.Repositories.ProdutoRepositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IDataAccessDapper _dapper;

        public ProdutoRepository(IDataAccessDapper dapper)
        {
            _dapper = dapper;
        }

        public int Create(Produto obj)
        {
            try
            {
                var _sql = @"   INSERT INTO tb_produto
                                    (strSKU
                                    ,strTitulo
                                    ,strDescricao
                                    ,decValor
                                    ,dtDataAlterado
                                    ,idStatus
                                    ,intQuantidade)
                                VALUES
                                    (@strSKU
                                    ,@strTitulo
                                    ,@strDescricao
                                    ,@decValor
                                    ,@dtDataAlterado
                                    ,1
                                    ,@intQuantidade)";

                var teste = _dapper.InsertReturnInt(_sql, new Produto
                {
                    strSku = obj.strSku,
                    strTitulo = obj.strTitulo,
                    strDescricao = obj.strDescricao,
                    decValor = obj.decValor,
                    dtDataAlterado = obj.dtDataAlterado,
                    intQuantidade = obj.intQuantidade
                });

                return teste;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
