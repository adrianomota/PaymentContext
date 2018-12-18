using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {
        private IList<Payment> _payments;
        private Subscription()
        {
            _payments = new List<Payment>();
        }

        public Subscription(DateTime? expireDate)
        {
            ExpireDate = expireDate;
        }

        public DateTime CreateDate { get; private set; }

        public DateTime LastUpdateDate { get; private set; }

        public DateTime? ExpireDate { get; private set; }

        public bool Active { get; private set; }

        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }

        public void AddPayment(Payment payment)
        {

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(DateTime.Now, payment.PaidDate,
                               "Subscription.Payments",
                               "A data do pagamento deve ser futura!")
            );
            _payments.Add(payment);
        }

        public void MakeActive()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }


        public void InaActived()
        {
            Active = false;
            LastUpdateDate = DateTime.Now;
        }


    }
}