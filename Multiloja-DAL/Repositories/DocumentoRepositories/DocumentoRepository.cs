using Multiloja_DAL.Dapper.Interfaces;
using Multiloja_DAL.Models;
using Multiloja_DAL.Repositories.DocumentoRepositories.Interfaces;

namespace Multiloja_DAL.Repositories.DocumentoRepositories
{
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly IDataAccessDapper _dapper;

        public DocumentoRepository(IDataAccessDapper dapper)
        {
            _dapper = dapper;
        }

        public int Create(Documento obj)
        {
            try
            {
                var _sql = @"   INSERT INTO tb_documento
                                       (strDocumento
                                       ,idTipoDocumento)
                                VALUES
                                       (@strDocumento
                                       ,@idTipoDocumento);
                                SELECT SCOPE_IDENTITY();";

                var teste = _dapper.InsertReturnInt(_sql, new Documento
                {
                    strDocumento = obj.strDocumento,
                    idTipoDocumento = obj.idTipoDocumento
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
