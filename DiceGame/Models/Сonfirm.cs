using DiceGame.Repository.Static;

namespace DiceGame.Models
{
    public class Сonfirm
    {
        protected readonly byte[] _key;
        protected readonly int _numder;
        protected readonly byte[] _hmac;
        public string Key
        {
            get
            {
                return BitConverter.ToString(_key).Replace("-","").ToUpper();
            }
        }

        public string HMAC
        {
            get { return BitConverter.ToString(_hmac).Replace("-", "").ToUpper(); }
        }

        public int Number
        {
            get { return _numder; }
        }

        public Сonfirm(int maxRange)
        {
            _numder = GenerationRandom.GenerationSecureRandomNumber(maxRange);
            _key = GenerationRandom.GenerationSecureRandomKey();
            _hmac = CryptoCalculate.HMAC(_key, _numder);
        }
    }
}
