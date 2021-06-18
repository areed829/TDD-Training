using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AccountLibrary.Tests
{
    [TestFixture]
    public class AccountTests
    {
        private CustomerAccount account;
        private const double PRECISION = .01;
        private const double DEFAULT_OPENING_BALANCE = -100;

        [SetUp]
        public void Setup()
        {
            account = new CustomerAccount(DEFAULT_OPENING_BALANCE);
        }

        [Test]
        public void BasicConstructorTest()
        {
            var account = new CustomerAccount();
        }

        [Test]
        public void BasicBalanceMatchTestUsingConstraint()
        {
            Constraint matchesOpeningBalanceWithinTolerance = 
                Is.EqualTo(DEFAULT_OPENING_BALANCE).Within(PRECISION);
                Assert.That(account.Balance, matchesOpeningBalanceWithinTolerance);
        }

        [Test]
        public void NewAccountsMustThrowOnPositiveOpeningBalance() {
            const double INVALID_OPENING_BALANCE = 100.0;
            TestDelegate act = () => new CustomerAccount(INVALID_OPENING_BALANCE);
            Assert.Throws<AccountLibrary.InvalidOpeningBalanceException>(act);
        }
    }
}