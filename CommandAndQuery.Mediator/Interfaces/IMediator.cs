using System.Windows.Input;
using CommandAndQuery.Command.Interfaces;
using CommandAndQuery.Domain.Models;
using CommandAndQuery.Query.Interfaces;

namespace CommandAndQuery.Mediator.Interfaces
{
    public interface IMediator
    {
        TResponse Request<TResponse>(IQuery<TResponse> query);
        TResult Send<TResult>(ICommand<TResult> command);
    }
}