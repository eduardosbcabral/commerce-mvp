using ProjetoMvp.CommerceContext.Domain.Entities;
using ProjetoMvp.Shared.Infra.Repositories;

namespace ProjetoMvp.CommerceContext.Domain.Repositories
{
    public interface ICommerceRepository : IRepositoryBase<Commerce>
    {
        bool NameExists(string name);
        bool DomainExists(string siteDomain);
    }
}
