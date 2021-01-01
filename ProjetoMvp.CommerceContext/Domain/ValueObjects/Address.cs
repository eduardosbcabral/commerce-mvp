using Flunt.Validations;
using ProjetoMvp.Shared.Domain.ValueObjects;
using System.Collections.Generic;

namespace ProjetoMvp.CommerceContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Country { get; private set; }

        protected Address() { }

        public Address(string country, string state, string city, string zipCode, string street)
        {
            AddNotifications(new Contract()
                .IsNotNull(country, nameof(Country), "País é obrigatório.")
                .HasMinLen(country, 3, nameof(Country), "País deve ter no mínimo 3 caracteres.")
                .HasMaxLen(country, 50, nameof(Country), "País deve ter no máximo 50 caracteres.")

                .IsNotNull(state, nameof(State), "Estado é obrigatório.")
                .HasMinLen(state, 3, nameof(State), "Estado deve ter no mínimo 3 caracteres.")
                .HasMaxLen(state, 50, nameof(State), "Estado deve ter no máximo 50 caracteres.")

                .IsNotNull(city, nameof(City), "Cidade é obrigatória.")
                .HasMinLen(city, 3, nameof(City), "Cidade deve ter no mínimo 3 caracteres.")
                .HasMaxLen(city, 50, nameof(City), "Cidade deve ter no máximo 50 caracteres.")
            );

            if(Valid)
            {
                Country = country;
                State = state;
                City = city;
                ZipCode = zipCode;
                Street = street;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
        }
    }
}
