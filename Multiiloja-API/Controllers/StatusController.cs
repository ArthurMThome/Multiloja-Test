using Microsoft.AspNetCore.Mvc;
using Multiloja_BLL;
using Multiloja_BLL.Services.StatusServices.Interfaces;
using Multiloja_BLL.ViewObjects;

namespace Multiiloja_BACK.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _service;

        public StatusController(IStatusService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public DefaultReturn<StatusVO> FindById(int id)
        {
            return _service.FindById(id);
        }
    }
}