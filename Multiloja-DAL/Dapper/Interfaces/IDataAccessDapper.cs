namespace Multiloja_DAL.Dapper.Interfaces
{
    public interface IDataAccessDapper
    {
        int InsertReturnInt<T>(string _sql, T? _param = default);
        List<T> Select<T>(string _sql, object _parm = default);
        bool UpdateOrDelete<T>(string _sql, T? _parm = default);
    }
}
