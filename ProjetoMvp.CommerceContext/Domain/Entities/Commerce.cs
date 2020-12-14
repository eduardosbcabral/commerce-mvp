using ProjetoMvp.CommerceContext.Domain.ValueObjects;
using ProjetoMvp.Shared.Domain.Entities;

namespace ProjetoMvp.CommerceContext.Domain.Entities
{
    public class Commerce : Entity
    {
        public string Name { get; private set; }
        public Site Site { get; private set; }
        public Address Address { get; private set; }
        public bool Active { get; private set; }
    }
}
