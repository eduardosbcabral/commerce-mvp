using Flunt.Notifications;
using System.Net;

namespace ProjetoMvp.Shared.Domain.Handlers
{
    public class BadRequestCommandResult : CommandResult
    {
        public BadRequestCommandResult(bool success, string message)
            : base(success, message)
        {
            StatusCode = HttpStatusCode.OK;
        }

        public BadRequestCommandResult(bool success, string message, Notifiable notifiable)
            : base(success, message, notifiable)
        {
            StatusCode = HttpStatusCode.BadRequest;
        }

        public BadRequestCommandResult(bool success, string message, object resultObject)
            : base(success, message, resultObject)
        {
            StatusCode = HttpStatusCode.OK;
        }
    }
}
