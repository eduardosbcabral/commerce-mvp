using Microsoft.EntityFrameworkCore;
using ProjetoMvp.Shared.Domain.Entities;
using System;
using System.Linq;

namespace ProjetoMvp.Shared.Infra.Repositories
{
    public class RepositoryBase<TContext, TEntity> : IRepositoryBase<TEntity> where TEntity : Entity where TContext : DbContext
    {
        protected readonly TContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(TContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Save(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
