using Flunt.Validations;
using ProjetoMvp.Shared.Domain.ValueObjects;

namespace ProjetoMvp.CommerceContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; private set; }

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
    }
}
