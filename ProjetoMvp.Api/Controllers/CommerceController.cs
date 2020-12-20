using Microsoft.AspNetCore.Mvc;
using ProjetoMvp.CommerceContext.Domain.Commands;
using ProjetoMvp.CommerceContext.Domain.Repositories;
using ProjetoMvp.Shared.Domain.Handlers;

namespace ProjetoMvp.Api.Controllers
{
    [Route("commerces")]
    public class CommerceController : ControllerBase
    {
        private readonly IHandler<CreateCommerceCommand> _createCommerce;

        private readonly ICommerceRepository _commerceRepository;

        public CommerceController(
            IHandler<CreateCommerceCommand> createCommerce,
            ICommerceRepository commerceRepository)
        {
            _createCommerce = createCommerce;
            _commerceRepository = commerceRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _commerceRepository.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCommerceCommand command)
        {
            var result = _createCommerce.Handle(command);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
