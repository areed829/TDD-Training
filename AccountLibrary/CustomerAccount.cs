using System.Collections.Generic;

namespace AccountLibrary
{
    public class CustomerAccount
    {
        public double Balance { get; private set; }
        private List<Payment> Payments = new List<Payment>();

        public CustomerAccount()
        {
        }

        public CustomerAccount(double openingBalance)
        {
            if (openingBalance > 0)
            {
                throw new InvalidOpeningBalanceException();
            }
            Balance = openingBalance;
        }

        public IReadOnlyList<Payment> GetPaymentHistory()
        {
            return Payments;
        }

        public void MakePayment(Payment payment)
        {
            this.Payments.Add(payment);
        }

        public void MakeMultiplePayments(List<Payment> payments)
        {
            Payments.AddRange(payments);
        }

        public void SetupPayment(double amount, string description)
        {
            Payments.Add(new Payment().Setup(amount, description));
        }
    }
}