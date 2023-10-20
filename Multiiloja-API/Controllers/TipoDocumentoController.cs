using Microsoft.AspNetCore.Mvc;
using Multiloja_BLL;
using Multiloja_BLL.Services.TipoDocumentoServices.Interfaces;
using Multiloja_BLL.ViewObjects;

namespace Multiiloja_BACK.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumentoService _service;

        public TipoDocumentoController(ITipoDocumentoService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public DefaultReturn<TipoDocumentoVO> FindById(int id)
        {
            return _service.FindById(id);
        }

        [HttpGet]
        public DefaultReturn<List<TipoDocumentoVO>> GetAll(int id)
        {
            return _service.GetAll(id);
        }
    }
}