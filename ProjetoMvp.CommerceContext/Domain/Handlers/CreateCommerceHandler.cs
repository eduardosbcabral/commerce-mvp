using Flunt.Notifications;
using ProjetoMvp.CommerceContext.Domain.Commands;
using ProjetoMvp.CommerceContext.Domain.Entities;
using ProjetoMvp.CommerceContext.Domain.Repositories;
using ProjetoMvp.CommerceContext.Domain.ValueObjects;
using ProjetoMvp.Shared.Domain.Handlers;
using System;

namespace ProjetoMvp.CommerceContext.Domain.Handlers
{
    public class CreateCommerceHandler : Notifiable,
        IHandler<CreateCommerceCommand>
    {
        private readonly ICommerceRepository _commerceRepository;

        public CreateCommerceHandler(
            ICommerceRepository commerceRepository)
        {
            _commerceRepository = commerceRepository;
        }

        public ICommandResult Handle(CreateCommerceCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new BadRequestCommandResult("Não foi possível cadastrar o comércio.", command);
            }

            if (_commerceRepository.NameExists(command.Name))
            {
                AddNotification("Name", "Este nome já está em uso.");
            }

            if (_commerceRepository.DomainExists(command.SiteDomain))
            {
                AddNotification("Domain", "Este domínio já está em uso.");
            }

            var address = new Address(command.Country, command.State, command.City, command.ZipCode, command.Street);
            var site = new Site(command.SiteDomain);

            var commerce = new Commerce(command.Name, site, address);

            // Agrupar as validações
            AddNotifications(address, site, commerce);

            if (Invalid)
                return new BadRequestCommandResult("Não foi possível cadastrar o comércio.", this);

            _commerceRepository.Save(commerce);
            _commerceRepository.SaveChanges();

            return new SuccessCommandResult("Comércio cadastrado com sucesso.", 
                new CreateCommerceResult(commerce.Id));
        }
    }

    public class CreateCommerceResult : ICommandResultObject
    {
        public Guid Id { get; private set; }

        public CreateCommerceResult(Guid id)
        {
            Id = id;
        }
    }
}
