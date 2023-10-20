using Dapper;
using Multiloja_DAL.Dapper.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace Multiloja_DAL.Dapper
{
    public class DataAccessDapper : IDataAccessDapper
    {
        private const string connectionString = "Data Source=ARTHURTHOME\\SQLEXPRESS;Initial Catalog=multiloja;Trusted_Connection=True;User Id=sa;Password=teste123";

        private SqlTransaction myTransaction;

        public List<T> Select<T>(string _sql, object _parm = default)
        {
            SqlConnection _con = new SqlConnection(connectionString);

            try
            {
                var dt = new List<T>();

                using (_con)
                {
                    _con.Open();
                    dt = _con.Query<T>(_sql, _parm).ToList();
                }
                return dt;
            }
            catch (SqlException sqlEx)
            {
                // Mensagem de que deu erro
                throw sqlEx;
            }
            catch (Exception ex)
            {
                // Mensagem de que deu erro
                throw ex;
            }
            finally
            {
                _con.Close();
                _con.Dispose();
            }
        }

        public bool UpdateOrDelete<T>(string _sql, T? _parm = default)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                var dt = new bool();

                using (con)
                {
                    con.Open();
                    if (con.Execute(_sql, _parm) > 0)
                        dt = true;
                    else
                        dt = false;
                }
                return dt;
            }
            catch (SqlException sqlEx)
            {
                // Mensagem de que deu erro
                throw sqlEx;
            }
            catch (Exception ex)
            {
                // Mensagem de que deu erro
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public void Insert<T>(string _sql, T? _parm = default)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                using (con)
                {
                    con.Open();
                    con.Query<int>(_sql, _parm);
                }
            }
            catch (SqlException sqlEx)
            {
                // Mensagem de que deu erro
                throw sqlEx;
            }
            catch (Exception ex)
            {
                // Mensagem de que deu erro
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public int InsertReturnInt<T>(string _sql, T? _parm = default)
        {
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                var intUltimoInserido = new int();

                using (con)
                {
                    con.Open();

                    var retorno = con.ExecuteScalar(_sql, _parm)?.ToString();

                    if(retorno != null)
                        intUltimoInserido = int.Parse(retorno);
                }
                return intUltimoInserido;
            }

            catch (SqlException sqlEx)
            {
                // Mensagem de que deu erro
                throw sqlEx;
            }
            catch (Exception ex)
            {
                // Mensagem de que deu erro
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}