using System;
using System.Collections.Generic;
using System.Linq;
using AccountLibrary;
using AutoFixture.NUnit3;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Shouldly;

namespace AccountLibraryTests
{
    [TestFixture]
    public class CustomerAccountTests
    {
        private CustomerAccount account;
        private const double PRECISION = .01;
        private const double DEFAULT_OPENING_BALANCE = -100;

        [SetUp]
        public void Setup()
        {
            account = new CustomerAccount(DEFAULT_OPENING_BALANCE);
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
            Assert.That(history is IReadOnlyList<Payment>);
        }

        [Test]
        [AutoData]
        public void Account_Should_Make_Payment(double amount, string description)
        {
            Payment payment = new Payment(amount, DateTime.Today, description);
            account.MakePayment(payment);
            account.GetPaymentHistory().ShouldContain(payment);
        }

        [Test]
        [AutoData]
        public void Account_Should_Make_Multiple_Payment(List<Payment> payments)
        {
            account.MakeMultiplePayments(payments);
            account.GetPaymentHistory().Count.ShouldBe(payments.Count);
        }

        [Test]
        [AutoData]
        public void Account_Should_Make_Payment_Only_With_Amount_and_Description(double amount, string description)
        {
            var payment = new Payment().Setup(amount, description);
            account.SetupPayment(amount, description);
            var history = account.GetPaymentHistory();
            history.First().ShouldBeEquivalentTo(payment);
        }
    }
}