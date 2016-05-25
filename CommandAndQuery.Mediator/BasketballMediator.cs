using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CommandAndQuery.Command.CommandHandlers;
using CommandAndQuery.Command.Interfaces;
using CommandAndQuery.Domain.Models;
using CommandAndQuery.Mediator.Interfaces;
using CommandAndQuery.Query.Interfaces;

namespace CommandAndQuery.Mediator
{
    public class BasketballMediator : IMediator
    {
        public TResult Send<TResult>(ICommand<TResult> command)
        {
            throw new NotImplementedException();
        }

        public TResponse Request<TResponse>(IQuery<TResponse> query)
        {
            throw new NotImplementedException();
        }
    }
}
