using ProjetoMvp.Shared.Domain.Commands;

namespace ProjetoMvp.Shared.Domain.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
