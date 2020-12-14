using ProjetoMvp.Shared.Domain.Handlers;

namespace ProjetoMvp.CommerceContext.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public CommandResult()
        {

        }

        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
