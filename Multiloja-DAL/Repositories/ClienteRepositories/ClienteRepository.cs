﻿using Multiloja_DAL.Dapper.Interfaces;
using Multiloja_DAL.Models;
using Multiloja_DAL.Repositories.ClienteRepositories.Interfaces;

namespace Multiloja_DAL.Repositories.ClienteRepositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IDataAccessDapper _dapper;

        public ClienteRepository(IDataAccessDapper dapper)
        {
            _dapper = dapper;
        }

        public int Create(Cliente obj)
        {
            try
            {
                var _sql = @"   INSERT INTO tb_cliente
                                       (strDocumento
                                       ,strPrimeiroNome
                                       ,strUltimoNome
                                       ,strCelular
                                       ,strEmail
                                       ,dtDataNascimento
                                       ,idStatus
                                       ,dtDataAlterado)
                                VALUES
                                       (@strDocumento
                                       ,@strPrimeiroNome
                                       ,@strUltimoNome
                                       ,@strCelular
                                       ,@strEmail
                                       ,@dtDataNascimento
                                       ,1
                                       ,@dtDataAlterado);
                                SELECT SCOPE_IDENTITY();";

                return _dapper.InsertReturnInt(_sql, new Cliente
                {
                    strDocumento = obj.strDocumento,
                    strPrimeiroNome = obj.strPrimeiroNome,
                    strUltimoNome = obj.strUltimoNome,
                    strCelular = obj.strCelular,
                    strEmail = obj.strEmail,
                    dtDataNascimento = obj.dtDataNascimento,
                    dtDataAlterado = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> GetAll()
        {
            try
            {
                var _sql = @"   SELECT idCliente
                                      ,strDocumento
                                      ,strPrimeiroNome
                                      ,strUltimoNome
                                      ,strCelular
                                      ,strEmail
                                      ,dtDataNascimento
                                      ,idStatus
                                      ,dtDataCriacao
                                      ,dtDataAlterado
                                FROM tb_cliente
                                ORDER BY idCliente DESC";

                return _dapper.Select<Cliente>(_sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
