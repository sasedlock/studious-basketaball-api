using System.Security.Policy;
using CommandAndQuery.Data;
using CommandAndQuery.Domain.Models;
using CommandAndQuery.Query.Interfaces;

namespace CommandAndQuery.Query.QueryHandlers
{
    public class GetTeamByIdQueryHandler : QueryHandler<GetTeamByIdQuery, BasketballTeam>
    {
        private readonly IRepository<BasketballTeam> _repository;

        public GetTeamByIdQueryHandler(IRepository<BasketballTeam> repository)
        {
            _repository = repository;
        }

        public override BasketballTeam Handle(GetTeamByIdQuery query)
        {
            return _repository.GetById(query.TeamId);
        }
    }

    public class GetTeamByIdQuery : IQuery<BasketballTeam>
    {
        public int TeamId;
    }
}