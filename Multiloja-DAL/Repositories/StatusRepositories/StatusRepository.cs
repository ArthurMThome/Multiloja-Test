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

        public int Create(Status obj)
        {
            try
            {
                var _sql = "INSERT INTO tb_status (strStatus,strDescricao) VALUES ( @strStatus,@strDescricao);";

                var teste = _dapper.InsertReturnInt(_sql, new Status
                {
                    strStatus = obj.strStatus,
                    strDescricao = obj.strDescricao
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
