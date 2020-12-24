using Flunt.Notifications;
using Flunt.Validations;
using ProjetoMvp.Shared.Domain.Commands;
using System;

namespace ProjetoMvp.CommerceContext.Domain.Commands
{
    public class DeleteCommerceCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotEmpty(Id, nameof(Id), "Id é obrigatório.")
            );
        }
    }
}
