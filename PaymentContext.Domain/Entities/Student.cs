using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;
        private Student()
        {
            _subscriptions = new List<Subscription>();
        }

        public Student(Name name, Document document, Email email, Address address)
        {
            Name = name;
            Document = document;
            Email = email;
            Address = address;

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }

        public Email Email { get; set; }
        public Document Document { get; private set; }

        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }


        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;
            foreach (var sub in _subscriptions)
            {
                if (sub.Active)
                {
                    hasSubscriptionActive = true;
                }

                AddNotifications(new Contract()
                    .Requires()
                    .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Voce já possui uma assinatura ativa!")
                );
            }

            foreach (var sub in Subscriptions)
            {
                sub.MakeActive();
            }

            _subscriptions.Add(subscription);
        }
    }
}