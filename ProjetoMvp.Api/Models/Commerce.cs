using System;
using System.Net.Sockets;

namespace ProjetoMvp.Api.Models
{
    public class Commerce
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Site Site { get; private set; }
        public Address Address { get; private set; }
        public bool Active { get; private set; }
    }
}
