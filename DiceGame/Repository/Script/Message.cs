using DiceGame.Models;
using DiceGame.Repository.Static;

namespace DiceGame.Repository.Script
{
    public class Message
    {
        protected static List<Dice> _helpDices;
        public static void LogicGame(bool UserIsWin, List<Dice> dices)
        {
            _helpDices = dices.ToArray().ToList();
            int step = 2;
            int countUser = 0;
            int countPC = 0;
            Dice diceUser;
            Dice dicePC;
            Сonfirm confStep;
            if (UserIsWin)
            {
                diceUser = ChooseUser(dices);
                dicePC = ChoosePS(dices, false);
            }
            else
            {
                dicePC = ChoosePS(dices, true);
                diceUser = ChooseUser(dices);
            }
            while (step > 0)
            {
                int stepUser, stepPC;
                confStep = new Сonfirm(5);
                if (UserIsWin)
                {
                    stepUser = StepUser(dices);
                    StepPCStart(confStep);
                    stepPC = StepPCFinish(confStep);
                }
                else
                {
                    StepPCStart(confStep);
                    stepUser = StepUser(dices);
                    stepPC = StepPCFinish(confStep);
                }

                Console.WriteLine($"The result is {stepPC} + {stepUser} = {(stepPC + stepUser) % 6} (mod 6).");

                int newCountUser = diceUser.Edge[stepUser];
                int newCountPC = dicePC.Edge[stepPC];

                Console.WriteLine("My throw is " + newCountPC);
                Console.WriteLine("Your throw is " + newCountUser);

                countUser = countUser < newCountUser ? newCountUser : countUser;
                countPC = countPC < newCountPC ? newCountPC : countPC;
                step--;
            }

            if (countUser > countPC)
            {
                Console.WriteLine($"You win ({countUser} > {countPC})");
            }
            else if (countUser < countPC)
            {
                Console.WriteLine($"I win ({countPC} > {countUser})");
            }
            else
            {
                Console.WriteLine($"Draw ({countPC} = {countUser})");
            }

            Console.WriteLine("Enter - return main meny");
            Console.ReadLine();
            Console.Clear();
        }

        protected static int StepUser(List<Dice> dices)
        {
            Console.WriteLine("It's time for your throw.");
            Console.WriteLine("Add your number modul 6.");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"{i} - {i}");
            }
            Console.WriteLine("X - exit");
            Console.WriteLine("? - help");
            while (true)
            {
                Console.Write("Your selection: ");
                switch (Console.ReadLine())
                {
                    case "0": return 0;
                    case "1": return 1;
                    case "2": return 2;
                    case "3": return 3;
                    case "4": return 4;
                    case "5": return 5;
                    case "?": HelpTable.PrintTable(_helpDices); break;
                    case "X": Environment.Exit(0); break;
                }
            }
        }
        protected static void StepPCStart(Сonfirm confStep)
        {
            Console.WriteLine("It's time for my throw.");
            Console.WriteLine($"I selected a random value in the range 0..5 (HMAC={confStep.HMAC}).");
        }

        protected static int StepPCFinish(Сonfirm confStep)
        {
            Console.WriteLine($"My number is {confStep.Number} (KEY={confStep.Key}).");
            return confStep.Number;
        }

        protected static void PrintDices(List<Dice> dices)
        {
            Console.WriteLine("Choose your dice:");
            for(int i = 0; i < dices.Count; i++)
            {
                Console.WriteLine($"{i} - {dices[i].ToString()}");
            }
        }

        protected static Dice ChooseUser(List<Dice> dices)
        {
            Dice diceUser;
                PrintDices(dices);
                Console.WriteLine("X - exit");
                Console.WriteLine("? - help");
            while (true)
            {
                Console.Write("Your selection: ");
                string choose = Console.ReadLine();
                switch (choose)
                {
                    case "?": HelpTable.PrintTable(_helpDices); break;
                    case "X": Environment.Exit(0); break;
                    default:
                        int a;
                        if(int.TryParse(choose, out a))
                            if (a < dices.Count())
                            {
                                diceUser = dices[int.Parse(choose)];
                                dices.Remove(dices[int.Parse(choose)]);
                                return diceUser;
                            }
                        if (int.Parse(choose) < dices.Count())
                        {
                            diceUser = dices[int.Parse(choose)];
                            dices.Remove(dices[int.Parse(choose)]);
                            return diceUser;
                        }
                        break;
                }
            }
        }

        protected static Dice ChoosePS(List<Dice> dices, bool win)
        {
            string isWin = win ? "the first" : "the second";
            var rnd = GenerationRandom.GenerationSecureRandomNumber(dices.Count() - 1);
            Dice dicePC = dices[rnd];
            dices.Remove(dicePC);
            Console.WriteLine($"I make {isWin} move and choose the [{dicePC.ToString()}] dice.");
            return dicePC;
        }

    }
}
