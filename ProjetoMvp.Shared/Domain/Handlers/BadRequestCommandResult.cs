using Flunt.Notifications;
using System.Net;

namespace ProjetoMvp.Shared.Domain.Handlers
{
    public class BadRequestCommandResult : CommandResult
    {
        public BadRequestCommandResult(string message)
            : base(false, message)
        {
            StatusCode = HttpStatusCode.OK;
        }

        public BadRequestCommandResult(string message, Notifiable notifiable)
            : base(false, message, notifiable)
        {
            StatusCode = HttpStatusCode.BadRequest;
        }

        public BadRequestCommandResult(string message, object resultObject)
            : base(false, message, resultObject)
        {
            StatusCode = HttpStatusCode.OK;
        }
    }
}
