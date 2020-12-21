using Flunt.Notifications;
using Flunt.Validations;
using ProjetoMvp.Shared.Domain.Commands;
using System;

namespace ProjetoMvp.CommerceContext.Domain.Commands
{
    public class UpdateCommerceCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid SiteId { get; set; }
        public string SiteDomain { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public UpdateCommerceCommand()
        {

        }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotEmpty(Id, nameof(Id), "Id é obrigatório.")

                .IsNotNullOrEmpty(Name, nameof(Name), "Nome é obrigatório.")
                .HasMinLen(Name, 3, nameof(Name), "Nome deve ter no mínimo 3 caracteres.")
                .HasMaxLen(Name, 50, nameof(Name), "Nome deve ter no máximo 50 caracteres.")

                .IsNotEmpty(SiteId, nameof(SiteId), "SiteId é obrigatório.")
                .IsNotNullOrEmpty(SiteDomain, nameof(SiteDomain), "Domínio é obrigatório.")

                .IsNotNullOrEmpty(Country, nameof(Country), "País é obrigatório.")
                .HasMinLen(Country, 3, nameof(Country), "País deve ter no mínimo 3 caracteres.")
                .HasMaxLen(Country, 50, nameof(Country), "País deve ter no máximo 50 caracteres.")

                .IsNotNullOrEmpty(State, nameof(State), "Estado é obrigatório.")
                .HasMinLen(State, 3, nameof(State), "Estado deve ter no mínimo 3 caracteres.")
                .HasMaxLen(State, 50, nameof(State), "Estado deve ter no máximo 50 caracteres.")

                .IsNotNullOrEmpty(City, nameof(City), "Cidade é obrigatória.")
                .HasMinLen(City, 3, nameof(City), "Cidade deve ter no mínimo 3 caracteres.")
                .HasMaxLen(City, 50, nameof(City), "Cidade deve ter no máximo 50 caracteres.")
            );
        }
    }
}
