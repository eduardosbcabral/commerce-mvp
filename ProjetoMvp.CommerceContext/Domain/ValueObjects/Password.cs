using Flunt.Validations;
using ProjetoMvp.Shared.Domain.ValueObjects;

namespace ProjetoMvp.CommerceContext.Domain.ValueObjects
{
    public class Password : ValueObject
    {
        public string Value { get; private set; }

        protected Password() { }

        public Password(string password)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(password, "Password.Value", "Senha é obrigatória.")
                .HasMinLengthIfNotNullOrEmpty(password, 4, "Password", "Senha deve possuir mais de 4 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(password, 128, "Password", "Senha não deve possuir mais de 128 caracteres")
            );

            if (Valid)
            {
                Value = HashPassword(password);
            }
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(string passwordToCompare)
        {
            return BCrypt.Net.BCrypt.Verify(passwordToCompare, Value);
        }
    }
}
