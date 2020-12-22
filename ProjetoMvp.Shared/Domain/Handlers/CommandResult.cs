using Flunt.Notifications;
using System.Collections.Generic;

namespace ProjetoMvp.Shared.Domain.Handlers
{
    public class CommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IList<Notification> Notifications { get; private set; }
        public object Result { get; private set; }

        public CommandResult()
        {

        }

        public CommandResult(bool success, string message) 
        {
            Success = success;
            Message = message;
        }

        public CommandResult(bool success, string message, Notifiable notifiable)
        {
            Success = success;
            Message = message;
            Notifications = (IList<Notification>)notifiable?.Notifications;
        }

        public CommandResult(bool success, string message, object resultObject)
        {
            Success = success;
            Message = message;
            Result = resultObject;
        }
    }
}
