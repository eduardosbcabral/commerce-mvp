using Microsoft.EntityFrameworkCore;
using ProjetoMvp.CommerceContext.Domain.Entities;
using ProjetoMvp.CommerceContext.Domain.Repositories;
using ProjetoMvp.Shared.Infra.Repositories;
using System;
using System.Linq;

namespace ProjetoMvp.CommerceContext.Infra.Repositories
{
    public class AccountRepository : RepositoryBase<CommerceDbContext, Account>, IAccountRepository
    {
        public AccountRepository(CommerceDbContext context) : base(context)
        {
        }

        public bool EmailExists(string email, Guid? id = null)
        {
            var query = DbSet
                .AsNoTracking()
                .Where(x => x.Email.Address == email);

            if (id != null)
            {
                query = query.Where(x => x.Id != id);
            }

            return query.Any();
        }
    }
}
