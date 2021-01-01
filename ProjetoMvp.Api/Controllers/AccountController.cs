using Microsoft.AspNetCore.Mvc;
using ProjetoMvp.CommerceContext.Domain.Commands;
using ProjetoMvp.CommerceContext.Domain.Handlers;
using ProjetoMvp.Shared.Domain.Handlers;
using System;

namespace ProjetoMvp.Api.Controllers
{
    [Route("accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IHandler<CreateAccountCommand> _createAccount;

        public AccountController(IHandler<CreateAccountCommand> createAccount)
        {
            _createAccount = createAccount;
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public IActionResult Create([FromBody] CreateAccountCommand command)
        {
            var result = _createAccount.Handle(command);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            var createdEntity = (CreateAccountResult)result.Result;

            var createdUri = new Uri($"{Request.Path}/{createdEntity.Id}", UriKind.Relative);

            return Created(createdUri, result);
        }
    }
}
