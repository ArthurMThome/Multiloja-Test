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
                    dtDataAlterado = DateTime.Now,
                    intQuantidade = obj.intQuantidade
                });

                return teste;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Produto FindById(int id)
        {
            try
            {
                var _sql = @"   SELECT idProduto
                                    ,strSku
                                    ,strTitulo
                                    ,strDescricao
                                    ,decValor
                                    ,dtDataCriacao
                                    ,dtDataAlterado
                                    ,idStatus
                                    ,intQuantidade
                                FROM tb_produto
                                WHERE idProduto = @idProduto";

                return _dapper.Select<Produto>(_sql, new Produto
                {
                    idProduto = id
                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Produto> GetAll()
        {
            try
            {
                var _sql = @"   SELECT idProduto
                                    ,strSku
                                    ,strTitulo
                                    ,strDescricao
                                    ,decValor
                                    ,dtDataCriacao
                                    ,dtDataAlterado
                                    ,idStatus
                                    ,intQuantidade
                                FROM tb_produto";

                return _dapper.Select<Produto>(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
