using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;

namespace DiceGame.Repository.Static
{
    public class CryptoCalculate
    {
        public static byte[] HMAC (byte[] key, int number)
        {
            byte[] numberByte = BitConverter.GetBytes(number);
            HMac hmac = new HMac(new Sha3Digest(256));
            hmac.Init(new KeyParameter(key));
            hmac.BlockUpdate(numberByte, 0, numberByte.Length);
            byte[] result = new byte[hmac.GetMacSize()];
            hmac.DoFinal(result, 0);
            return result;           
        }
    }
}
