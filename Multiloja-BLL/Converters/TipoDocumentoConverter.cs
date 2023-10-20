using Multiloja_BLL.Converters.Converter;
using Multiloja_BLL.ViewObjects;
using Multiloja_DAL.Models;

namespace Multiloja_BLL.Converters
{
    public class TipoDocumentoConverter : IConverter<TipoDocumentoVO, TipoDocumento>, IConverter<TipoDocumento, TipoDocumentoVO>
    {
        public TipoDocumento Parse(TipoDocumentoVO origin)
        {
            if (origin == null) return null;

            return new TipoDocumento()
            {
                idTipoDocumento = origin.TipoDocumentoId,
                strTipoDocumento = origin.TipoDocumento,
                strDescricao = origin.Descricao
            };
        }

        public List<TipoDocumento> Parse(List<TipoDocumentoVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public TipoDocumentoVO Parse(TipoDocumento origin)
        {
            if (origin == null) return null;

            return new TipoDocumentoVO()
            {
                TipoDocumentoId = origin.idTipoDocumento,
                TipoDocumento = origin.strTipoDocumento,
                Descricao = origin.strDescricao
            };
        }

        public List<TipoDocumentoVO> Parse(List<TipoDocumento> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
