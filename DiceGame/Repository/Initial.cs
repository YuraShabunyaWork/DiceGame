using DiceGame.Models;

namespace DiceGame.Repository
{
    public class Initial
    {
        public List<Dice> Dices = new List<Dice>();
        public Initial(string[] args)
        {
            if(args.Length < 3)
            {
                Console.WriteLine("Incorrect number of dice.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            foreach (var arg in args)
            {
                if (arg.Split(',').Length == 6)
                {
                    Dices.Add(new Dice(arg));
                }
                else
                {
                    Console.WriteLine("Incorrect number of edge.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
        }
    }
}
