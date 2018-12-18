using System;
using Flunt.Notifications;

namespace PaymentContext.shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            CreadtedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime CreadtedOn { get; private set; }
        public DateTime ModifiedOn { get; private set; }
    }
}