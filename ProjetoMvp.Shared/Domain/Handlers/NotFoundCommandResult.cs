using Flunt.Notifications;
using System.Net;

namespace ProjetoMvp.Shared.Domain.Handlers
{
    public class NotFoundCommandResult : CommandResult
    {
        public NotFoundCommandResult(bool success, string message)
            : base(success, message)
        {
            StatusCode = HttpStatusCode.NotFound;
        }

        public NotFoundCommandResult(bool success, string message, Notifiable notifiable)
            : base(success, message, notifiable)
        {
            StatusCode = HttpStatusCode.NotFound;
        }

        public NotFoundCommandResult(bool success, string message, object resultObject)
            : base(success, message, resultObject)
        {
            StatusCode = HttpStatusCode.NotFound;
        }
    }
}