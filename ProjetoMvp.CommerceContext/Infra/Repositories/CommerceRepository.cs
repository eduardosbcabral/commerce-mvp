using Microsoft.EntityFrameworkCore;
using ProjetoMvp.CommerceContext.Domain.Entities;
using ProjetoMvp.CommerceContext.Domain.Repositories;
using ProjetoMvp.Shared.Infra.Repositories;
using System.Linq;

namespace ProjetoMvp.CommerceContext.Infra.Repositories
{
    public class CommerceRepository : RepositoryBase<CommerceDbContext, Commerce>, ICommerceRepository
    {
        public CommerceRepository(CommerceDbContext context) : base(context)
        {
        }

        public bool DomainExists(string siteDomain)
        {
            //return DbSet
            //    .AsNoTracking()
            //    .Where(x => x.Site.Domain == siteDomain)
            //    .Any();
            return false;
        }

        public bool NameExists(string name)
        {
            return DbSet
                .AsNoTracking()
                .Where(x => x.Name == name)
                .Any();
        }
    }
}
