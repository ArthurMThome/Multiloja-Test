using Multiloja_DAL.Dapper.Interfaces;
using Multiloja_DAL.Models;
using Multiloja_DAL.Repositories.StatusRepositories.Interfaces;

namespace Multiloja_DAL.Repositories.StatusRepositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly IDataAccessDapper _dapper;

        public StatusRepository(IDataAccessDapper dapper)
        {
            _dapper = dapper;
        }

        public Status FindById(int id)
        {
            try
            {
                var _sql = @"   SELECT idStatus
                                    ,strStatus
                                    ,strDescricao
                                FROM tb_status
                                WHERE idStatus = @idStatus";

                return _dapper.Select<Status>(_sql, new Status
                {
                    idStatus = id
                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
