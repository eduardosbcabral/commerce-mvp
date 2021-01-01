using Flunt.Notifications;
using Flunt.Validations;
using ProjetoMvp.Shared.Domain.Commands;

namespace ProjetoMvp.CommerceContext.Domain.Commands
{
    public class CreateAccountCommand : Notifiable, ICommand
    {
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterOrEqualsThan(Age, 18, nameof(Age), "A idade deve ser igual ou maior que 18 anos.")
                .IsEmail(Email, nameof(Email), "E-mail inválido.")
                .IsNotNullOrEmpty(Password, nameof(Password), "Senha é obrigatória.")
                .HasMinLengthIfNotNullOrEmpty(Password, 4, nameof(Password), "Senha deve possuir mais de 4 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(Password, 128, nameof(Password), "Senha não deve possuir mais de 128 caracteres")
            );
        }
    }
}
