using Multiloja_BLL.Converters.Converter;
using Multiloja_BLL.ViewObjects;
using Multiloja_DAL.Models;

namespace Multiloja_BLL.Converters
{
    public class StatusConverter : IConverter<StatusVO, Status>, IConverter<Status, StatusVO>
    {
        public Status Parse(StatusVO origin)
        {
            if (origin == null) return null;

            return new Status()
            {
                idStatus = origin.StatusId,
                strStatus = origin.Status,
                strDescricao = origin.Descricao
            };
        }

        public List<Status> Parse(List<StatusVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public StatusVO Parse(Status origin)
        {
            if (origin == null) return null;

            return new StatusVO()
            {
                StatusId = origin.idStatus,
                Status = origin.strStatus,
                Descricao = origin.strDescricao
            };
        }

        public List<StatusVO> Parse(List<Status> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

