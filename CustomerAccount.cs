namespace AccountLibrary
{
    public class CustomerAccount
    {
        public double Balance {get; internal set;}
        public CustomerAccount()
        {
        }

        public CustomerAccount(double openingBalance)
        {
            if (openingBalance > 0) {
                throw new InvalidOpeningBalanceException();
            } 
            Balance = openingBalance;
        }
    }
}