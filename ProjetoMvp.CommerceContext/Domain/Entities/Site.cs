﻿using Flunt.Validations;
using ProjetoMvp.Shared.Domain.Entities;

namespace ProjetoMvp.CommerceContext.Domain.Entities
{
    public class Site : Entity
    {
        public string Domain { get; private set; }

        public Commerce Commerce { get; private set; }

        protected Site() { }

        public Site(string domain)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(domain, nameof(Domain), "O domínio é obrigatório.")
            );

            if (Valid)
            {
                Domain = domain;
            }
        }

        public void Update(string domain)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(domain, nameof(Domain), "O domínio é obrigatório.")
            );

            Domain = domain;
        }
    }
}
