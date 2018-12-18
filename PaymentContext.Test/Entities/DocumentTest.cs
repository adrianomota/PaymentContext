using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.PaymentContext.Domain.Enums;

namespace PaymentContext.Test
{
    [TestClass]
    public class DocumentTest
    {
        [TestMethod]
        public void DeveRetornarErroQuandoCNPJForInvalido()
        {
            var doc = new Document("234", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }
        [TestMethod]
        public void DeveRetornarSucessoQuandoCNPJForValido()
        {
            var doc = new Document("45537429000150", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void DeveRetornarErroQuandoCPFForInvalido()
        {
            var doc = new Document("234", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("31352500833")]
        [DataRow("42051455007")]
        [DataRow("93243427037")]
        public void DeveRetornarSucessoQuandoCPFForValido(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}
