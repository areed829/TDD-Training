using System;
using System.Collections.Generic;
using System.Linq;
using AccountLibrary;
using AccountLibrary.Exceptions;
using AccountLibraryCore;
using AutoFixture.NUnit3;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Shouldly;

namespace AccountLibraryTests
{
    [TestFixture]
    public class CustomerAccountTests
    {
        private CustomerAccount account;
        private Mock<IPaymentService> paymentService;
        private const double PRECISION = .01;
        private const double DEFAULT_OPENING_BALANCE = -100;

        [SetUp]
        public void Setup()
        {
            paymentService = new Mock<IPaymentService>();
            paymentService.Setup(m => m.GetPaymentsByCustomerAccountId(
                It.IsAny<int>())).Returns(new List<IPayment>());
            account = new CustomerAccount(DEFAULT_OPENING_BALANCE);
            account.paymentService = paymentService.Object;
        }

        [Test]
        public void BasicBalanceMatchTestUsingConstraint()
        {
            Constraint matchesOpeningBalanceWithinTolerance =
                Is.EqualTo(DEFAULT_OPENING_BALANCE).Within(PRECISION);
            Assert.That(account.Balance, matchesOpeningBalanceWithinTolerance);
        }

        [Test]
        public void NewAccountsMustThrowOnPositiveOpeningBalance()
        {
            const double INVALID_OPENING_BALANCE = 100.0;
            TestDelegate act = () => new CustomerAccount(INVALID_OPENING_BALANCE);
            Assert.Throws<InvalidOpeningBalanceException>(act);
        }

        [Test]
        public void GetPaymentHistory_InitiallyEmpty()
        {
            account.GetPaymentHistory().Count.ShouldBeEquivalentTo(0, "Expected empty (and non-null) payment history");
        }

        [Test]
        public void PaymentHistory_Should_Be_Readonly()
        {
            var history = account.GetPaymentHistory();
            Assert.That(history is IReadOnlyList<IPayment>);
        }

        [Test]
        [AutoData]
        public void Account_Should_Make_Payment(double amount, string description)
        {
            IPayment payment = new Payment(amount, DateTime.Today, description);
            paymentService.Setup(m => m.GetPaymentsByCustomerAccountId(It.IsAny<int>()))
                .Returns(new List<IPayment> { payment });
            account.MakePayment(payment);
            account.GetPaymentHistory().ShouldContain(payment);
        }

        [Test]
        [AutoData]
        public void Account_Should_Make_Multiple_Payment(Payment firstPayment, Payment secondPayment)
        {
            List<IPayment> payments = new List<IPayment> {firstPayment, secondPayment};
            paymentService.Setup(m => m.GetPaymentsByCustomerAccountId(It.IsAny<int>()))
                .Returns(payments);
            account.MakeMultiplePayments(payments);
            account.GetPaymentHistory().Count.ShouldBe(payments.Count);
        }

        [Test]
        [AutoData]
        public void Account_Should_Make_Payment_Only_With_Amount_and_Description(double amount, string description)
        {
            IPayment payment = new Payment().Setup(amount, description);
            paymentService.Setup(m => m.GetPaymentsByCustomerAccountId(It.IsAny<int>()))
                .Returns(new List<IPayment> {payment});
            account.SetupPayment(payment);
            var history = account.GetPaymentHistory();
            history.First().ShouldBeEquivalentTo(payment);
        }
    }
}