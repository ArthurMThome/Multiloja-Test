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

                return _dapper.InsertReturnInt(_sql, new Documento
                {
                    strDocumento = obj.strDocumento,
                    idTipoDocumento = obj.idTipoDocumento
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Documento FindById(int id)
        {
            try
            {
                var _sql = @"   SELECT idDocumento
                                    ,strDocumento
                                    ,idTipoDocumento
                                FROM tb_documento
                                WHERE idDocumento = @idDocumento";

                return _dapper.Select<Documento>(_sql, new Documento
                {
                    idDocumento = id
                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
