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

        public int Create(TipoDocumento obj)
        {
            try
            {
                var _sql = "INSERT INTO tb_tipo_documento (strTipoDocumento,strDescricao) VALUES ( @strTipoDocumento,@strDescricao); SELECT SCOPE_IDENTITY();";

                return _dapper.InsertReturnInt(_sql, new TipoDocumento
                {
                    strTipoDocumento = obj.strTipoDocumento,
                    strDescricao = obj.strDescricao
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
