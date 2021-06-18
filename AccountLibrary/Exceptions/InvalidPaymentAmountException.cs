using System;

namespace AccountLibrary.Exceptions
{
    public class InvalidPaymentAmountException : Exception
    {
        public InvalidPaymentAmountException()
            : base("Payment amount must be greater than Zero")
        {
            
        }
    }
}