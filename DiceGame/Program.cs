using DiceGame.Models;
using DiceGame.Repository;
using DiceGame.Repository.Script;

public class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Initial initialArg = new Initial(args);
            Сonfirm confStep = new Сonfirm(1);
            Console.WriteLine("Let's determine who make the first move.");
            Console.Write("I selected a random value in the range 0..1 ");
            Console.WriteLine($"(HMAC={confStep.HMAC}).");
            Console.WriteLine("Try to guess my selection.");
            Console.WriteLine("0 - 0");
            Console.WriteLine("1 - 1");
            Console.WriteLine("X - exit");
            Console.WriteLine("? - help");
            Console.Write("Your selection: ");
            switch (Console.ReadLine())
            {
                case "0":
                    Console.WriteLine($"My selection: {confStep.Number} (KEY={confStep.Key})");
                    if (0 == confStep.Number) Message.LogicGame(true, initialArg.Dices);
                    else Message.LogicGame(false, initialArg.Dices);
                    break;
                case "1":
                    Console.WriteLine($"My selection: {confStep.Number} (KEY={confStep.Key})");
                    if (1 == confStep.Number) Message.LogicGame(true, initialArg.Dices);
                    else Message.LogicGame(false, initialArg.Dices);
                    break;
                case "?":
                    HelpTable.PrintTable(initialArg.Dices);
                    break;
                case "X": return;
            }
        }
    }
}