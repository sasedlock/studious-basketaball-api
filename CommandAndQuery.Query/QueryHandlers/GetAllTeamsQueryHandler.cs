using System.Collections;
using System.Collections.Generic;
using CommandAndQuery.Data;
using CommandAndQuery.Domain.Models;
using CommandAndQuery.Query.Interfaces;

namespace CommandAndQuery.Query.QueryHandlers
{
    public class GetAllTeamsQueryHandler : QueryHandler<GetAllTeamsQuery, IEnumerable<BasketballTeam>>
    {
        private readonly IRepository<BasketballTeam> _repository;

        public GetAllTeamsQueryHandler(IRepository<BasketballTeam> repository)
        {
            _repository = repository;
        }

        public override IEnumerable<BasketballTeam> Handle(GetAllTeamsQuery query)
        {
            return _repository.GetAll();
        }
    }

    public class GetAllTeamsQuery : IQuery<IEnumerable<BasketballTeam>>
    {
        public int UserId { get; set; }
    }
}