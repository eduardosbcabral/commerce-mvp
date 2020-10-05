using System;

namespace ProjetoMvp.Api.Models
{
    public class Site
    {
        public Guid Id { get; private set; }
        public string Domain { get; private set; }
        public Commerce Commerce { get; private set; }
        public bool Active { get; private set; }
    }
}
