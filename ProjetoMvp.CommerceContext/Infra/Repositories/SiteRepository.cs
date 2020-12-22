using Microsoft.EntityFrameworkCore;
using ProjetoMvp.CommerceContext.Domain.Entities;
using ProjetoMvp.CommerceContext.Domain.Repositories;
using ProjetoMvp.Shared.Infra.Repositories;
using System;
using System.Linq;

namespace ProjetoMvp.CommerceContext.Infra.Repositories
{
    public class SiteRepository : RepositoryBase<CommerceDbContext, Site>, ISiteRepository
    {
        public SiteRepository(CommerceDbContext context) : base(context)
        {
        }
    }
}
