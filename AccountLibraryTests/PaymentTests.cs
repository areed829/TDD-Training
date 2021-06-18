using System;
using AccountLibrary;
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
    }
}