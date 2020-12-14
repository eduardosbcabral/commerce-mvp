using ProjetoMvp.Shared.Domain.Entities;

namespace ProjetoMvp.CommerceContext.Domain.Entities
{
    public class Site : Entity
    {
        public string Domain { get; private set; }
        public Commerce Commerce { get; private set; }
        public bool Active { get; private set; }
    }
}
