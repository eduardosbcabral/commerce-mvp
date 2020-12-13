using Flunt.Notifications;
using Flunt.Validations;

namespace ProjetoMvp.Api.Models
{
    public class Email : Notifiable
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
