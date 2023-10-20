using Microsoft.AspNetCore.Mvc;
using Multiloja_BLL;
using Multiloja_BLL.Services.ClienteServices.Interfaces;
using Multiloja_BLL.ViewObjects;

namespace Multiiloja_BACK.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpPost]
        public DefaultReturn<int> Post([FromBody] ClienteVO contato)
        {
            return _service.Create(contato);
        }

        [HttpGet]
        public DefaultReturn<List<ClienteVO>> GetAll()
        {
            return _service.GetAll();
        }
    }
}