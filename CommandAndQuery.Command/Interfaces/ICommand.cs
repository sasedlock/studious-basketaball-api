using MediatR;

namespace CommandAndQuery.Command.Interfaces
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
         
    }
}