namespace AccountLibrary.Exceptions
{
    public class InvalidOpeningBalanceException : System.Exception
    {
        public InvalidOpeningBalanceException()
            : base("Opening Balance can't be zero.")
        {

        }
    }
}