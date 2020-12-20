using ProjetoMvp.Shared.Domain.Entities;
using System;
using System.Linq;

namespace ProjetoMvp.Shared.Infra.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();

        void Save(TEntity obj);
        void Update(TEntity obj);
        void Remove(Guid id);
        int SaveChanges();
    }
}
