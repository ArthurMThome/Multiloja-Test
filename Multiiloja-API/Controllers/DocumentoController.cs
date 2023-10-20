using Microsoft.AspNetCore.Mvc;
using Multiloja_BLL;
using Multiloja_BLL.Services.DocumentoServices.Interfaces;
using Multiloja_BLL.ViewObjects;

namespace Multiiloja_BACK.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentoController : ControllerBase
    {
        private readonly IDocumentoService _service;

        public DocumentoController(IDocumentoService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public DefaultReturn<DocumentoVO> FindById(int id)
        {
            return _service.FindById(id);
        }

        [HttpPost]
        public DefaultReturn<int> Post([FromBody] DocumentoVO contato)
        {
            return _service.Create(contato);
        }
    }
}