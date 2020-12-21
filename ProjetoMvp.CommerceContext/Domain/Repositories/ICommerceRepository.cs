using ProjetoMvp.CommerceContext.Domain.Entities;
using ProjetoMvp.Shared.Infra.Repositories;
using System;

namespace ProjetoMvp.CommerceContext.Domain.Repositories
{
    public interface ICommerceRepository : IRepositoryBase<Commerce>
    {
        /// <summary>
        /// Check if name exists. If id is sent, it means that
        /// will check entities that are not the id.
        /// </summary>
        /// <param name="name">Commerce name</param>
        /// <param name="id">Id to ignore search.</param>
        /// <returns></returns>
        bool NameExists(string name, Guid? id = null);
        /// <summary>
        /// Check if site domain exists. If id is sent, it means that
        /// will check entities that are not the id.
        /// </summary>
        /// <param name="siteDomain">Site Domain</param>
        /// <param name="id">Id to ignore search.</param>
        /// <returns></returns>
        bool DomainExists(string siteDomain, Guid? id = null);
    }
}
