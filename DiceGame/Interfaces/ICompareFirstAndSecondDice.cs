using DiceGame.Models;

namespace DiceGame.Interfaces
{
    public interface ICompareFirstAndSecondDice
    {
        double FindProbability(Dice first, Dice second);
    }
}
