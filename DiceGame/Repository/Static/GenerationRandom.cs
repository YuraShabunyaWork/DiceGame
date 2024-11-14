using System.Security.Cryptography;

namespace DiceGame.Repository.Static
{
    public class GenerationRandom
    {
        public static byte[] GenerationSecureRandomKey()
        {
            var key = GetNumber(32);
            return key;
        }

        public static int GenerationSecureRandomNumber(int maxNumber)
        {
            var number = GetNumber(4);
            int intNumber = BitConverter.ToInt32(number);
            return Math.Abs(intNumber) % (maxNumber + 1);
        }

        protected static byte[] GetNumber(int size)
        {
            using (var random = RandomNumberGenerator.Create())
            {
                byte[] number = new byte[size];
                random.GetBytes(number);
                return number;
            }
        }
    }
}
