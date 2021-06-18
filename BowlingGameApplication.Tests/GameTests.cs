using BowlingGameApplication.Library;
using NUnit.Framework;

namespace BowlingGameApplication.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Game game;

        private const int GUTTERBALL = 0;

        [SetUp]
        public void Setup()
        {
            game = new Game();
        }

        [Test]
        public void CanRoll()
        {
            game.Roll(3);
            Assert.AreEqual(3, game.Score);
        }

        [Test]
        public void GutterGame()
        {
            rollMany(20, GUTTERBALL);
            Assert.AreEqual(0, game.Score);
        }

        [Test]
        public void OnePinEveryRoll()
        {
            rollMany(20, 1);
            Assert.AreEqual(20, game.Score);
        }

        [Test]
        public void Roll_PerfectGame()
        {
            rollMany(12, 10);
            Assert.AreEqual(300, game.Score);
        }

        private void rollMany(int numRolls, int numPins)
        {
            for (int rollIteration = 1; rollIteration <= numRolls; rollIteration++)
            {
                game.Roll(numPins);
            }
        }
    }
}