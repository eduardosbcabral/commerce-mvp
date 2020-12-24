using Flunt.Notifications;
using ProjetoMvp.CommerceContext.Domain.Commands;
using ProjetoMvp.CommerceContext.Domain.Repositories;
using ProjetoMvp.Shared.Domain.Handlers;

namespace ProjetoMvp.CommerceContext.Domain.Handlers
{
    public class DeleteCommerceHandler : Notifiable,
        IHandler<DeleteCommerceCommand>
    {
        private readonly ICommerceRepository _commerceRepository;

        public DeleteCommerceHandler(ICommerceRepository commerceRepository)
        {
            _commerceRepository = commerceRepository;
        }

        public ICommandResult Handle(DeleteCommerceCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new BadRequestCommandResult("Não foi possível remover o comércio.", this);
            }

            var commerce = _commerceRepository.GetById(command.Id);
            if(commerce is null)
            {
                return new NotFoundCommandResult("Não foi possível encontrar o comércio.");
            }

            commerce.Inactivate();

            _commerceRepository.Update(commerce);
            _commerceRepository.SaveChanges();

            return new SuccessCommandResult("Comércio removido com sucesso.");
        }
    }
}
