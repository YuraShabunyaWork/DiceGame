using DiceGame.Interfaces;
using DiceGame.Models;

namespace DiceGame.Repository
{
    public class CompareFirstAndSecondDice : ICompareFirstAndSecondDice
    {       
        public double FindProbability(Dice first, Dice second)
        {
            int firstWins = 0;
            int secondWins = 0;
            for (int i = 0; i < first.Edge.Length; i++)
            {
                for (int j = 0; j < second.Edge.Length; j++)
                {
                    if (first.Edge[i] > second.Edge[j])
                        firstWins++;
                    else if (first.Edge[i] < second.Edge[j])
                        secondWins++;
                }
            }

            if(firstWins == secondWins)
                return 0.5;

            int totalOutcomes = first.Edge.Length * second.Edge.Length;
            double firstWinProbability = (double)firstWins / totalOutcomes;
            return Math.Round(firstWinProbability, 2);
        }
    }
}
