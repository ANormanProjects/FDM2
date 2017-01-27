using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
    public class Game
    {
        //PROPERTIES
        private int[] rolls = new int[21];

        private int currentRoll;

        //Bonus & Bool Methods
        private int BonusStrike(int roll)
        {
            return rolls[roll + 1] + rolls[roll + 2];
        }

        private int BonusSpare(int roll)
        {
            return rolls[roll + 2];
        }

        private int SumOfAllInFrame(int roll)
        {
            return rolls[roll] + rolls[roll + 1];
        }

        private bool IsStrike(int roll)
        {
            return rolls[roll] == 10;
        }

        private bool IsSpare(int roll)
        {
            return rolls[roll] + rolls[roll] == 10;
        }

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        //BOWLING SCORE CALCULATION

        public int Score()
        {
            int score = 0;
            int roll = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(roll))
                {
                    score += 10 + BonusStrike(roll);
                    roll++;
                }
                else if (IsSpare(roll))
                {
                    score += 10 + BonusSpare(roll);
                    roll += 2;
                }
                else
                {
                    score += SumOfAllInFrame(roll);
                    roll += 2;
                }
            }
            return score;
        }
    }
}
