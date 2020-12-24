using Flunt.Notifications;
using System.Net;

namespace ProjetoMvp.Shared.Domain.Handlers
{
    public class SuccessCommandResult : CommandResult
    {
        public SuccessCommandResult(bool success, string message)
            : base(success, message)
        {
            StatusCode = HttpStatusCode.OK;
        }

        public SuccessCommandResult(bool success, string message, Notifiable notifiable)
            : base(success, message, notifiable)
        {
            StatusCode = HttpStatusCode.OK;
        }

        public SuccessCommandResult(bool success, string message, object resultObject)
            : base(success, message, resultObject)
        {
            StatusCode = HttpStatusCode.OK;
        }
    }
}
