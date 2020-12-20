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
