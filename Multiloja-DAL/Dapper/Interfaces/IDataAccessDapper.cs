namespace Multiloja_DAL.Dapper.Interfaces
{
    public interface IDataAccessDapper
    {
        int InsertReturnInt<T>(string _sql, T? _param = default);
    }
}
