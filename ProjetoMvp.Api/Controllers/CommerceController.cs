using Microsoft.AspNetCore.Mvc;
using ProjetoMvp.CommerceContext.Domain.Commands;
using ProjetoMvp.CommerceContext.Domain.Handlers;
using ProjetoMvp.CommerceContext.Domain.Repositories;
using ProjetoMvp.Shared.Domain.Handlers;
using System;
using System.Net;

namespace ProjetoMvp.Api.Controllers
{
    [Route("commerces")]
    public class CommerceController : ControllerBase
    {
        private readonly IHandler<CreateCommerceCommand> _createCommerce;
        private readonly IHandler<UpdateCommerceCommand> _updateCommerce;
        private readonly IHandler<DeleteCommerceCommand> _deleteCommerce;

        private readonly ICommerceRepository _commerceRepository;

        public CommerceController(
            IHandler<CreateCommerceCommand> createCommerce,
            IHandler<UpdateCommerceCommand> updateCommerce,
            IHandler<DeleteCommerceCommand> deleteCommerce,
            ICommerceRepository commerceRepository)
        {
            _createCommerce = createCommerce;
            _updateCommerce = updateCommerce;
            _deleteCommerce = deleteCommerce;
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
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
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

        [HttpPatch("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Update))]
        public IActionResult Update(Guid id, [FromBody] UpdateCommerceCommand command)
        {
            command.Id = id;

            var result = _updateCommerce.Handle(command);

            if (!result.Success)
            {
                if (result.StatusCode == HttpStatusCode.BadRequest)
                {
                    return BadRequest(result);
                }

                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound(result);
                }
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public IActionResult Delete(Guid id)
        {
            var command = new DeleteCommerceCommand()
            {
                Id = id
            };

            var result = _deleteCommerce.Handle(command);

            if (!result.Success)
            {
                if (result.StatusCode == HttpStatusCode.BadRequest)
                {
                    return BadRequest(result);
                }

                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound(result);
                }
            }

            return Ok(result);
        }
    }
}
