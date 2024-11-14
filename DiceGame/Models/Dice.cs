namespace DiceGame.Models
{
    public class Dice
    {
        protected int[] _edge = new int[6];
        protected string _str;
        public int[] Edge { get => _edge; }


        public Dice(string str)
        {
            var a = str.Split(",");
            for (int i = 0; i < a.Length; i++)
            {
                if (!int.TryParse(a[i], out _edge[i]))
                {
                    Console.WriteLine("A non-integer value in the cube configuration.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
            }
            _str = str;
        }

        public override string ToString()
        {
            return _str;
        }
    }
}
