using Flunt.Notifications;
using ProjetoMvp.CommerceContext.Domain.Commands;
using ProjetoMvp.CommerceContext.Domain.Entities;
using ProjetoMvp.CommerceContext.Domain.Repositories;
using ProjetoMvp.CommerceContext.Domain.ValueObjects;
using ProjetoMvp.Shared.Domain.Handlers;
using System;

namespace ProjetoMvp.CommerceContext.Domain.Handlers
{
    public class CreateAccountHandler : Notifiable,
        IHandler<CreateAccountCommand>
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public ICommandResult Handle(CreateAccountCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new BadRequestCommandResult("Não foi possível cadastrar.", command);
            }

            if (_accountRepository.EmailExists(command.Email))
            {
                AddNotification("Email", "Este e-mail já está em uso.");
            }

            var age = new Age(command.Age);
            var email = new Email(command.Email);
            var password = new Password(command.Password);

            var account = new Account(age, email, password);

            AddNotifications(account);

            if (Invalid)
                return new BadRequestCommandResult("Não foi possível cadastrar.", this);

            _accountRepository.Save(account);
            _accountRepository.SaveChanges();

            return new SuccessCommandResult("Conta cadastrada com sucesso.",
                new CreateAccountResult(account.Id));
        }

        public class CreateAccountResult : ICommandResultObject
        {
            public Guid Id { get; private set; }

            public CreateAccountResult(Guid id)
            {
                Id = id;
            }
        }
    }
}
