using Flunt.Notifications;
using ProjetoMvp.CommerceContext.Domain.Commands;
using ProjetoMvp.CommerceContext.Domain.Entities;
using ProjetoMvp.CommerceContext.Domain.Repositories;
using ProjetoMvp.CommerceContext.Domain.ValueObjects;
using ProjetoMvp.Shared.Domain.Handlers;

namespace ProjetoMvp.CommerceContext.Domain.Handlers
{
    public class UpdateCommerceHandler : Notifiable,
        IHandler<UpdateCommerceCommand>
    {
        private readonly ICommerceRepository _commerceRepository;

        public UpdateCommerceHandler(ICommerceRepository commerceRepository)
        {
            _commerceRepository = commerceRepository;
        }

        public ICommandResult Handle(UpdateCommerceCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new BadRequestCommandResult("Não foi possível atualizar o comércio.", this);
            }

            if (_commerceRepository.NameExists(command.Name, command.Id))
            {
                AddNotification("Name", "Este nome já está em uso.");
            }

            if (_commerceRepository.DomainExists(command.SiteDomain, command.Id))
            {
                AddNotification("Domain", "Este domínio já está em uso.");
            }

            var address = new Address(command.Country, command.State, command.City, command.ZipCode, command.Street);

            AddNotifications(address, this);

            if (Invalid)
                return new BadRequestCommandResult("Não foi possível atualizar o comércio.", this);

            var commerce = _commerceRepository.GetById(command.Id);
            if (commerce is null)
            {
                AddNotification("Commerce", "Não foi possível encontrar o comércio.");
                return new NotFoundCommandResult("Não foi possível atualizar o comércio.", this);
            }

            var site = commerce.Site;
            site.Update(command.SiteDomain);

            commerce.Update(command.Name, site, address);

            // Agrupar as validações
            AddNotifications(address, site, commerce);

            if (Invalid)
                return new BadRequestCommandResult("Não foi possível atualizar o comércio.", this);

            _commerceRepository.Update(commerce);
            _commerceRepository.SaveChanges();

            return new SuccessCommandResult("Comércio atualizado com sucesso.");
        }
    }
}
