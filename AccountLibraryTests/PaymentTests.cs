using System;
using AccountLibrary;
using AccountLibrary.Exceptions;
using AutoFixture.NUnit3;
using NUnit.Framework;
using Shouldly;

namespace AccountLibraryTests
{
    [TestFixture]
    public class PaymentTests
    {
        [Test]
        public void BasicConstructorTest()
        {
            double amount = 50.0;
            DateTime date = new DateTime(2014, 1, 1);
            string description = "N/A";
            Payment payment = new Payment(amount, date, description);
            payment.Amount.ShouldBe(amount, "Amount mismatch");
            payment.Date.ShouldBe(date, "Date mismatch");
            payment.Description.ShouldBe(description, "Description mismatch");
        }

        [Test]
        [AutoData]
        public void Should_Setup_Payment_With_Amount_And_Description(double amount, string description)
        {
            var payment = new Payment().Setup(amount, description);
            payment.Amount.ShouldBe(amount);
            payment.Description.ShouldBe(description);
            payment.Date.ShouldBe(null);
        }

        [Test]
        [AutoData]
        public void Should_Throw_Exception_When_Balance_LessThan_Zero_in_Constructor(DateTime date, string description)
        {
            Should.Throw<InvalidPaymentAmountException>(() => new Payment(-100, date, description));
        }

        [Test]
        [AutoData]
        public void Should_Throw_Exception_When_Balance_LessThan_Zero_in_Setup(string description)
        {
            Should.Throw<InvalidPaymentAmountException>(() => new Payment().Setup(-100, description));
        }
    }
}