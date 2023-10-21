using Microsoft.AspNetCore.Mvc;
using Multiloja_BLL;
using Multiloja_BLL.Services.CarrinhoServices.Interfaces;
using Multiloja_BLL.ViewObjects;

namespace Multiiloja_BACK.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoService _service;

        public CarrinhoController(ICarrinhoService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public DefaultReturn<List<CarrinhoVO>> FindByClienteId(int id)
        {
            return _service.FindByClienteId(id);
        }

        [HttpPost]
        public DefaultReturn<int> Post([FromBody] CarrinhoVO contato)
        {
            return _service.Create(contato);
        }

        [HttpPut("{idCarrinho}")]
        public DefaultReturn<bool> Delete(string idCarrinho)
        {
            return _service.Delete(idCarrinho);
        }
    }
}