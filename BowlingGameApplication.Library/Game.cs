using System.Linq;

namespace BowlingGameApplication.Library
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int rollNumber = 0;
        private bool newFrame = true;
        /*
         * List<int[]> rolls
         * roll => if rolls.last.length == 2 then list.add(new [2])
         */

        public int Score
        {
            get
            {
                int score = 0;
                foreach (var roll in rolls)
                {
                    score += roll;
                }

                return score;
            }
        }

        public int getScore() {
            int score = 0;
            int nextBall = 0;
            for (int i = 0; i < rolls.Length; i++)
            {
                if (rolls[i] == 10)
                {
                    score += rolls[i];
                    score += rolls[i+1];
                    score += rolls[i+2];
                    nextBall++;
                }
                else if (rolls[i] + rolls[i+1] == 10)
                {
                    score += 10 + rolls[i + 2];
                    nextBall += 2;
                }
                else
                {
                    score += rolls[i] + rolls[i + 1];
                    nextBall += 2;
                }

            }

            return score;
        }

        public void Roll(int numPins)
        {
            rolls[rollNumber++] = numPins;
        }
    }
}

//[
//    10,     20
//    0,
//    10      35
//    5
//    4       44
//]


//[
//    [1: x,2: null],
//    [1: 5,2: /],
//    [1: 3, 2: 4]
//]