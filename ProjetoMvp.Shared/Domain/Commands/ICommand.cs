using Flunt.Notifications;
using System.Collections.Generic;

namespace ProjetoMvp.Shared.Domain.Commands
{
    public interface ICommand
    {
        IReadOnlyCollection<Notification> Notifications { get; }

        void Validate();
    }
}
