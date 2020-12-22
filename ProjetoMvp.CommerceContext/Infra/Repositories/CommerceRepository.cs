using Microsoft.EntityFrameworkCore;
using ProjetoMvp.CommerceContext.Domain.Entities;
using ProjetoMvp.CommerceContext.Domain.Repositories;
using ProjetoMvp.Shared.Infra.Repositories;
using System;
using System.Linq;

namespace ProjetoMvp.CommerceContext.Infra.Repositories
{
    public class CommerceRepository : RepositoryBase<CommerceDbContext, Commerce>, ICommerceRepository
    {
        public CommerceRepository(CommerceDbContext context) : base(context)
        {
        }

        public override Commerce GetById(Guid id)
        {
            return DbSet.AsQueryable()
                .Include(x => x.Site)
                .SingleOrDefault(x => x.Id == id);
        }

        public bool DomainExists(string siteDomain, Guid? id = null)
        {
            var query = DbSet
                .AsNoTracking()
                .Where(x => x.Site.Domain == siteDomain);

            if (id != null)
            {
                query = query.Where(x => x.Id != id);
            }

            return query.Any();
        }

        public bool NameExists(string name, Guid? id = null)
        {
            var query = DbSet
                .AsNoTracking()
                .Where(x => x.Name == name);

            if(id != null)
            {
                query = query.Where(x => x.Id != id);
            }

            return query.Any();
        }
    }
}
