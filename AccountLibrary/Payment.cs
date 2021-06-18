using System;
using System.Security.Cryptography;

namespace AccountLibrary
{
    public class Payment
    {
        public double Amount { get; private set; }
        public DateTime? Date { get; private set; }
        public string Description { get; private set; }

        public Payment()
        {
        }

        public Payment(double amount, DateTime date, string description)
        {
            Amount = amount;
            Date = date;
            Description = description;
        }

        public Payment Setup(double amount, string description)
        {
            Amount = amount;
            Description = description;
            return this;
        }
    }
}