using Flunt.Notifications;
using System.Net;

namespace ProjetoMvp.Shared.Domain.Handlers
{
    public class NotFoundCommandResult : CommandResult
    {
        public NotFoundCommandResult(string message)
            : base(false, message)
        {
            StatusCode = HttpStatusCode.NotFound;
        }

        public NotFoundCommandResult(string message, Notifiable notifiable)
            : base(false, message, notifiable)
        {
            StatusCode = HttpStatusCode.NotFound;
        }

        public NotFoundCommandResult(string message, object resultObject)
            : base(false, message, resultObject)
        {
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}