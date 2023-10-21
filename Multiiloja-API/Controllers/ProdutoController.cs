using Microsoft.AspNetCore.Mvc;
using Multiloja_BLL;
using Multiloja_BLL.Services.ProdutoServices.Interfaces;
using Multiloja_BLL.ViewObjects;

namespace Multiiloja_BACK.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public DefaultReturn<ProdutoVO> FindById(int id)
        {
            return _service.FindById(id);
        }

        [HttpGet("ids/{ids}")]
        public DefaultReturn<List<ProdutoVO>> FindByIds(string ids)
        {
            return _service.FindByIds(ids);
        }

        [HttpPost]
        public DefaultReturn<int> Post([FromBody] ProdutoVO contato)
        {
            return _service.Create(contato);
        }

        [HttpGet]
        public DefaultReturn<List<ProdutoVO>> GetAll()
        {
            return _service.GetAll();
        }
    }
}