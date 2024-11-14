using DiceGame.Interfaces;
using DiceGame.Models;
using ConsoleTables;

namespace DiceGame.Repository.Script
{
    public class HelpTable
    {
        public static void PrintTable(List<Dice> dices)
        {
            ICompareFirstAndSecondDice compare = new CompareFirstAndSecondDice();
            var table = new ConsoleTable("User dice v");
            table.AddColumn(dices.Select(s => s.ToString()).ToList());
            foreach (var dice in dices)
            {
                List<string> row = new List<string>();
                row.Add(dice.ToString());
                foreach (var item in dices)
                {
                    row.Add(compare.FindProbability(item, dice).ToString());
                }
                table.AddRow(row.ToArray());
            }
            Console.WriteLine("Probability of the win for the user:");
            table.Write(Format.Minimal);
        }
    }
}
