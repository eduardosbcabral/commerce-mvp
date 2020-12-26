using Flunt.Validations;
using ProjetoMvp.CommerceContext.Domain.ValueObjects;
using ProjetoMvp.Shared.Domain.Entities;

namespace ProjetoMvp.CommerceContext.Domain.Entities
{
    public class Contact : Entity
    {
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        public Phone WhatsApp { get; private set; }
        public string Facebook { get; private set; }
        public string Twitter { get; private set; }
        public string Instagram { get; private set; }

        protected Contact() { }

        public Contact(Email email, Phone phone)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(email, nameof(Email), "E-mail não pode ser nulo.")
                .IsNotNull(phone, nameof(Phone), "Telefone não pode ser nulo.")
            );

            if (Valid)
            {
                Email = email;
                Phone = phone;
            }
        }
    }
}
