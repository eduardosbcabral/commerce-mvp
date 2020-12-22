using Microsoft.AspNetCore.Mvc;
using ProjetoMvp.CommerceContext.Domain.Commands;
using ProjetoMvp.CommerceContext.Domain.Handlers;
using ProjetoMvp.CommerceContext.Domain.Repositories;
using ProjetoMvp.Shared.Domain.Handlers;
using System;

namespace ProjetoMvp.Api.Controllers
{
    [Route("commerces")]
    public class CommerceController : ControllerBase
    {
        private readonly IHandler<CreateCommerceCommand> _createCommerce;
        private readonly IHandler<UpdateCommerceCommand> _updateCommerce;

        private readonly ICommerceRepository _commerceRepository;

        public CommerceController(
            IHandler<CreateCommerceCommand> createCommerce,
            IHandler<UpdateCommerceCommand> updateCommerce,
            ICommerceRepository commerceRepository)
        {
            _createCommerce = createCommerce;
            _updateCommerce = updateCommerce;
            _commerceRepository = commerceRepository;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var result = _commerceRepository.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCommerceCommand command)
        {
            var result = _createCommerce.Handle(command);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            var createdEntity = (CreateCommerceResult)result.Result;

            var createdUri = new Uri($"{Request.Path}/{createdEntity.Id}", UriKind.Relative);

            return Created(createdUri, result);
        }

        [HttpPost("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateCommerceCommand command)
        {
            command.Id = id;

            var result = _updateCommerce.Handle(command);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
