using System.Collections;
using System.Collections.Generic;
using CommandAndQuery.Domain.Interfaces;

namespace CommandAndQuery.Data
{
    public interface IRepository<T> where T : IModel
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T model);
        void Edit(T model);
        void SaveChanges();
        T AddPlayerToTeam(int teamId, int playerId);
    }
}