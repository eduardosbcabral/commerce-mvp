using System;

namespace ProjetoMvp.Api.Models
{
    public class Contact
    {
        public Guid Id { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        public Phone WhatsApp { get; private set; }
        public string Facebook { get; private set; }
        public string Twitter { get; private set; }
        public string Instagram { get; private set; }
    }
}
