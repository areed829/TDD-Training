using System;

namespace AccountLibraryCore
{
    public interface IPayment
    {
        double Amount { get; }
        DateTime? Date { get; }
        string Description { get; }
        IPayment Setup(double amount, string description);
    }
}