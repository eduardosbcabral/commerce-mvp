using Flunt.Notifications;
using System.Net;

namespace ProjetoMvp.Shared.Domain.Handlers
{
    public class SuccessCommandResult : CommandResult
    {
        public SuccessCommandResult(string message)
            : base(true, message)
        {
            StatusCode = HttpStatusCode.OK;
        }

        public SuccessCommandResult(string message, Notifiable notifiable)
            : base(true, message, notifiable)
        {
            StatusCode = HttpStatusCode.OK;
        }

        public SuccessCommandResult(string message, object resultObject)
            : base(true, message, resultObject)
        {
            StatusCode = HttpStatusCode.OK;
        }
    }
}
