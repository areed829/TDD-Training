using System;
using System.Security.Cryptography;
using AccountLibrary.Exceptions;
using AccountLibraryCore;

namespace AccountLibrary
{
    public class Payment : IPayment
    {
        public double Amount { get; private set; }
        public DateTime? Date { get; private set; }
        public string Description { get; private set; }

        public Payment()
        {
        }

        public Payment(double amount, DateTime date, string description)
        {
            ValidateAmount(amount);
            Amount = amount;
            Date = date;
            Description = description;
        }

        public IPayment Setup(double amount, string description)
        {
            ValidateAmount(amount);
            Amount = amount;
            Description = description;
            return this;
        }

        private void ValidateAmount(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidPaymentAmountException();
            }
        }
    }
}