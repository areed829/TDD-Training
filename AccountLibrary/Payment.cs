using System;
using System.Security.Cryptography;

namespace AccountLibrary
{
    public class Payment
    {
        public readonly double Amount;
        public readonly DateTime Date;
        public readonly string Description;

        public Payment(double amount, DateTime date, string description)
        {
            this.Amount = amount;
            this.Date = date;
            this.Description = description;
        }

        public Payment(double amount, string description)
        {
            Amount = amount;
            Description = description;
        }
    }
}