using System.Net;

namespace ProjetoMvp.Shared.Domain.Handlers
{
    public interface ICommandResult
    {
        bool Success { get; }
        string Message { get; }
        object Result { get; }
        HttpStatusCode StatusCode { get; }
    }
}
