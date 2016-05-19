using CommandAndQuery.Command.Interfaces;

namespace CommandAndQuery.Command.CommandHandlers
{
    public abstract class CommandHandler<TMessage, TResult> 
        : ICommandHandler<TMessage, TResult>
        where TMessage : ICommand<TResult>
    {
        public abstract TResult Handle(TMessage command);
    }
}