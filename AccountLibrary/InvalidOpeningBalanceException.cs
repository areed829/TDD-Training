namespace AccountLibrary
{
    public class InvalidOpeningBalanceException : System.Exception
    {
        public InvalidOpeningBalanceException() 
            : base("Opening Balance can't be zero.")
        {

        }
    }
}