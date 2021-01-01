using Flunt.Validations;
using ProjetoMvp.CommerceContext.Domain.ValueObjects;
using ProjetoMvp.Shared.Domain.Entities;

namespace ProjetoMvp.CommerceContext.Domain.Entities
{
    public class Account : Entity
    {
        public Age Age { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }

        protected Account() { }

        public Account(Age age, Email email, Password password)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(age, nameof(Age), "Idade não pode ser nula.")
                .IfNotNull(age, contract => contract.Join(age))
                .IsNotNull(email, nameof(Email), "E-mail não pode ser nulo.")
                .IfNotNull(email, contract => contract.Join(email))
                .IsNotNull(password, nameof(Password), "Senha não pode ser nula.")
                .IfNotNull(password, contract => contract.Join(password)));

            if (Valid)
            {
                Age = age;
                Email = email;
                Password = password;
            }
        }
    }
}
