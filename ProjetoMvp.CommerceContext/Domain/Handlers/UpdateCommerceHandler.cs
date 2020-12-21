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
        private readonly ISiteRepository _siteRepository;

        public UpdateCommerceHandler(
            ICommerceRepository commerceRepository,
            ISiteRepository siteRepository)
        {
            _commerceRepository = commerceRepository;
            _siteRepository = siteRepository;
        }

        public ICommandResult Handle(UpdateCommerceCommand command)
        {
            // Fail Fast Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return Failure();
            }

            if (_commerceRepository.NameExists(command.Name, command.Id))
            {
                AddNotification("Name", "Este nome já está em uso.");
                return Failure();
            }

            if (_commerceRepository.DomainExists(command.SiteDomain, command.Id))
            {
                AddNotification("Domain", "Este domínio já está em uso.");
                return Failure();
            }

            var address = new Address(command.Country, command.State, command.City, command.ZipCode, command.Street);

            var site = _siteRepository.GetById(command.SiteId);
            if (site is null)
            {
                AddNotification("Site", "Não foi possível encontrar o site.");
                return Failure();
            }

            var commerce = _commerceRepository.GetById(command.Id);
            if(commerce is null)
            {
                AddNotification("Commerce", "Não foi possível encontrar o comércio.");
                return Failure();
            }

            commerce.Update(command.Name, site, address);

            // Agrupar as validações
            AddNotifications(address, site, commerce);

            if (Invalid)
                return Failure();

            _commerceRepository.Update(commerce);
            _commerceRepository.SaveChanges();

            return new CommandResult(true, "Comércio atualizado com sucesso.");
        }

        private CommandResult Failure()
        {
            return new CommandResult(false, "Não foi possível atualizar o comércio.");
        }
    }
}
