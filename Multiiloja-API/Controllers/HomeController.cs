using Microsoft.AspNetCore.Mvc;
using Multiloja_DAL.Models;
using Multiloja_DAL.Repositories.CarrinhoRepositories.Interfaces;
using Multiloja_DAL.Repositories.ClienteRepositories.Interfaces;

namespace Multiiloja_BACK.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarrinhoRepository _repository;
        private readonly IClienteRepository _repositoryC;

        public HomeController(ICarrinhoRepository repository, IClienteRepository repositoryC)
        {
            _repository = repository;
            _repositoryC = repositoryC;
        }

        public IActionResult Index()
        {
            var clienteId = _repositoryC.Create(new Cliente
            {
                idDocumento = 1,
                strPrimeiroNome = "Arthur",
                strUltimoNome = "Thomé",
                strCelular = "992013017",
                strEmail = "arthurthome02@gmail.com",
                dtDataNascimento = DateTime.Now,
                dtDataAlterado = DateTime.Now
            });

            _repository.Create(new Carrinho
            {
                idProduto = 1,
                idCliente = clienteId,
                strCodigoCarrinho = "123abc"
            });

            return null;
        }        
    }
}