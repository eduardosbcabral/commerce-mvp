using Flunt.Validations;
using ProjetoMvp.Shared.Domain.ValueObjects;
using System.Collections.Generic;

namespace ProjetoMvp.CommerceContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; private set; }

        protected Email() { }

        public Email(string address)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(address, "Email.Address", "E-mail inválido.")
            );

            if (Valid)
            {
                Address = address;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address;
        }
    }
}
