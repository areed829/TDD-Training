using System.Collections.Generic;
using AccountLibrary.Exceptions;
using AccountLibraryCore;

namespace AccountLibrary
{
    public class CustomerAccount
    {
        public IPaymentService paymentService;
        public double Balance { get; private set; }
        public int id;
        
        public CustomerAccount(double openingBalance)
        {
            if (openingBalance > 0)
            {
                throw new InvalidOpeningBalanceException();
            }
            Balance = openingBalance;
        }

        public IReadOnlyList<IPayment> GetPaymentHistory()
        {
            return (IReadOnlyList<IPayment>)paymentService.GetPaymentsByCustomerAccountId(id);
        }

        public void MakePayment(IPayment payment)
        {
            paymentService.MakePayment(payment);
        }

        public void MakeMultiplePayments(List<IPayment> payments)
        {
            paymentService.MakeMultiplePayments(payments);
        }

        public void SetupPayment(IPayment payment)
        {
            paymentService.MakePayment(payment);
        }
    }
}