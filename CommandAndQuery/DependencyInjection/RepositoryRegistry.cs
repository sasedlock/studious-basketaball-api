using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommandAndQuery.Data;
using CommandAndQuery.Data.Repositories;
using CommandAndQuery.Domain.Models;
using StructureMap;

namespace CommandAndQuery.DependencyInjection
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            For<IRepository<Player>>().Use<PlayerRepository>();
            For<IRepository<BasketballTeam>>().Use<BasketballTeamRepository>();
        }
    }
}