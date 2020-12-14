using ProjetoMvp.Shared.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoMvp.CommerceContext.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public List<ProductImage> Images { get; private set; }
        public bool Active { get; private set; }

    }
}
