using Multiloja_BLL.Converters.Converter;
using Multiloja_BLL.ViewObjects;
using Multiloja_DAL.Models;

namespace Multiloja_BLL.Converters
{
    public class ClienteConverter : IConverter<ClienteVO, Cliente>, IConverter<Cliente, ClienteVO>
    {
        public Cliente Parse(ClienteVO origin)
        {
            if (origin == null) return null;

            return new Cliente()
            {
                idCliente = origin.ClienteId,
                strDocumento = origin.Documento,
                strPrimeiroNome = origin.PrimeiroNome,
                strUltimoNome = origin.UltimoNome,
                strCelular = origin.Celular,
                strEmail = origin.Email,
                dtDataNascimento = origin.DataNascimento,
                idStatus = origin.StatusId,
                dtDataCriacao = origin.DataCriacao,
                dtDataAlterado = origin.DataAlterado
            };
        }

        public List<Cliente> Parse(List<ClienteVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public ClienteVO Parse(Cliente origin)
        {
            if (origin == null) return null;

            return new ClienteVO()
            {
                ClienteId = origin.idCliente,
                Documento = origin.strDocumento,
                PrimeiroNome = origin.strPrimeiroNome,
                UltimoNome = origin.strUltimoNome,
                Celular = origin.strCelular,
                Email = origin.strEmail,
                DataNascimento = origin.dtDataNascimento,
                StatusId = origin.idStatus,
                DataCriacao = origin.dtDataCriacao,
                DataAlterado = origin.dtDataAlterado
            };
        }

        public List<ClienteVO> Parse(List<Cliente> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
