using Flunt.Notifications;
using System;

namespace ProjetoMvp.Shared.Domain.Entities
{
    public class Entity : Notifiable
    {
        public Guid Id { get; private set; }
        public bool Active { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            Active = true;
        }
    }
}
