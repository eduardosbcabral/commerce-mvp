using Flunt.Notifications;
using ProjetoMvp.Shared.Domain.Commands;
using ProjetoMvp.Shared.Domain.Handlers;
using System.Collections.Generic;

namespace ProjetoMvp.CommerceContext.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IList<Notification> Notifications { get; private set; }

        public CommandResult()
        {

        }

        public CommandResult(bool success, string message, Notifiable notifiable = null) 
        {
            Success = success;
            Message = message;
            Notifications = (IList<Notification>)notifiable?.Notifications;
        }
    }
}
