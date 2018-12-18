using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.PaymentContext.Domain.Enums;

namespace PaymentContext.Test
{
    [TestClass]
    public class StudentTest
    {
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;

        public StudentTest()
        {
            _name = new Name("Adriano", "Mota");
            _document = new Document("41452500833", EDocumentType.CPF);
            _email = new Email("adrianowsh@hotmail.com");
            _address = new Address("Rua AAA", "11", "Vila Sao Joao", "Barueri", "SP", "Brasil", "06401160");
            _student = new Student(_name, _document, _email, _address);
            _subscription = new Subscription(null);

        }

        [TestMethod]
        public void DeveRetornarErroQuandoASubscriptionEstiverAtiva()
        {
            var payment = new PayoalPayment("1234567",
                                            DateTime.Now,
                                            DateTime.Now.AddDays(5),
                                            10,
                                            10,
                                            _document,
                                            "Onwer",
                                            _address,
                                            _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }



        [TestMethod]
        public void DeveRetornarErroQuandoASubscriptionEstiverSemPagamento()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void DeveRetornarSuccessoQuandoNaoTemSubscriptionAtiva()
        {
            var payment = new PayoalPayment("1234567",
                                              DateTime.Now,
                                              DateTime.Now.AddDays(5),
                                              10,
                                              10,
                                              _document,
                                              "Onwer",
                                              _address,
                                              _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
        }
    }
}
