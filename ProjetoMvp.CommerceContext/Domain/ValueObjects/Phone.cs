using Flunt.Validations;
using ProjetoMvp.Shared.Domain.ValueObjects;

namespace ProjetoMvp.CommerceContext.Domain.ValueObjects
{
    public class Phone : ValueObject
    {
        public string Ddd { get; private set; }
        public string Number { get; private set; }

        public Phone(string ddd, string number)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasLen(ddd, 3, "Phone.Ddd", "DDD deve ter 3 dígitos.")
                .HasMinLen(number, 8, "Phone.Number", "Número deve ter no mínimo 8 dígitos.")
                .HasMaxLen(number, 9, "Phone.Number", "Número deve ter no mínimo 9 dígitos.")
            );

            if(Valid)
            {
                Ddd = ddd;
                Number = number;
            }
        }
    }
}
