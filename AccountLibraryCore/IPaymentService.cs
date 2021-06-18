using System.Collections.Generic;

namespace AccountLibraryCore
{
    public interface IPaymentService
    {
        IList<IPayment> GetPaymentsByCustomerAccountId(int isAny);
        void MakePayment(IPayment payment);
        void MakeMultiplePayments(List<IPayment> payments);
    }
}