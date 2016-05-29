using MediatR;

namespace CommandAndQuery.Command.Interfaces
{
    public interface ICommandHandler<in TCommand, out TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
    {
        TResult Handle(TCommand command);
    }
}