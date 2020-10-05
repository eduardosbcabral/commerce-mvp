using System;
using System.Collections.Generic;

namespace ProjetoMvp.Api.Models
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public List<ProductImage> Images { get; private set; }
        public bool Active { get; private set; }

    }
}
