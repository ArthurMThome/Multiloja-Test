using Multiloja_DAL.Dapper.Interfaces;
using Multiloja_DAL.Models;
using Multiloja_DAL.Repositories.TipoDocumentoRepositories.Interfaces;

namespace Multiloja_DAL.Repositories.TipoDocumentoRepositories
{
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        private readonly IDataAccessDapper _dapper;

        public TipoDocumentoRepository(IDataAccessDapper dapper)
        {
            _dapper = dapper;
        }

        public TipoDocumento FindById(int id)
        {
            try
            {
                var _sql = @"   SELECT idTipoDocumento
                                    ,strTipoDocumento
                                    ,strDescricao
                                FROM tb_tipo_documento
                                WHERE idTipoDocumento = @idTipoDocumento";

                return _dapper.Select<TipoDocumento>(_sql, new TipoDocumento
                {
                    idTipoDocumento = id
                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoDocumento> GetAll()
        {
            try
            {
                var _sql = @"   SELECT idTipoDocumento
                                    ,strTipoDocumento
                                    ,strDescricao
                                FROM tb_tipo_documento";

                return _dapper.Select<TipoDocumento>(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
