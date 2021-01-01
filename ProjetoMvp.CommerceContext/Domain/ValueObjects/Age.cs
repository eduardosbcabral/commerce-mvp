using Flunt.Validations;
using ProjetoMvp.Shared.Domain.ValueObjects;
using System.Collections.Generic;

namespace ProjetoMvp.CommerceContext.Domain.ValueObjects
{
    public class Age : ValueObject
    {
        public int Value { get; private set; }

        protected Age() { }

        public Age(int age)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterOrEqualsThan(age, 18, "Age.Value", "A idade deve ser igual ou maior que 18 anos."));

            if (Valid)
                Value = age;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
