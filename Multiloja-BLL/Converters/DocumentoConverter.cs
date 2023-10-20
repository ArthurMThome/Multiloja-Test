using Multiloja_BLL.Converters.Converter;
using Multiloja_BLL.ViewObjects;
using Multiloja_DAL.Models;

namespace Multiloja_BLL.Converters
{
    public class DocumentoConverter : IConverter<DocumentoVO, Documento>, IConverter<Documento, DocumentoVO>
    {
        public Documento Parse(DocumentoVO origin)
        {
            if (origin == null) return null;

            return new Documento()
            {
                idDocumento = origin.DocumentoId,
                strDocumento = origin.Documento,
                idTipoDocumento = origin.TipoDocumentoId
            };
        }

        public List<Documento> Parse(List<DocumentoVO> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }

        public DocumentoVO Parse(Documento origin)
        {
            if (origin == null) return null;

            return new DocumentoVO()
            {
                DocumentoId = origin.idDocumento,
                Documento = origin.strDocumento,
                TipoDocumentoId = origin.idTipoDocumento
            };
        }

        public List<DocumentoVO> Parse(List<Documento> origin)
        {
            if (origin == null) return null;

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}

