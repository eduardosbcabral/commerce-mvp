using ProjetoMvp.CommerceContext.Domain.Entities;

namespace ProjetoMvp.CommerceContext.Domain.Repositories
{
    public interface ICommerceRepository
    {
        bool NameExists(string v);
        bool DomainExists(string siteDomain);
        void Save(Commerce commerce);
    }
}
