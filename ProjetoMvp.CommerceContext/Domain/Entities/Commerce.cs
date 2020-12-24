using Flunt.Validations;
using ProjetoMvp.CommerceContext.Domain.ValueObjects;
using ProjetoMvp.Shared.Domain.Entities;
using System;

namespace ProjetoMvp.CommerceContext.Domain.Entities
{
    public class Commerce : Entity
    {
        public string Name { get; private set; }

        public Address Address { get; private set; }

        public int SiteId { get; private set; }
        public Site Site { get; private set; }

        public Commerce() { }

        public Commerce(string name, Site site, Address address)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(name, nameof(Name), "Nome é obrigatório.")
                .Join(address, site)
            );

            if (Valid)
            {
                Name = name;
                Site = site;
                Address = address;
            }
        }

        public void Update(string name, Site site, Address address)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(name, nameof(Name), "Nome é obrigatório.")
                .Join(address, site)
            );

            if (Valid)
            {
                Name = name;
                Site = site;
                Address = address;
            }
        }

        public void Activate()
        {
            Active = true;
        }

        public void Inactivate()
        {
            Active = false;
        }
    }
}
