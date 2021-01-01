using ProjetoMvp.CommerceContext.Domain.Entities;
using ProjetoMvp.Shared.Infra.Repositories;
using System;

namespace ProjetoMvp.CommerceContext.Domain.Repositories
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        bool EmailExists(string name, Guid? id = null);
    }
}
