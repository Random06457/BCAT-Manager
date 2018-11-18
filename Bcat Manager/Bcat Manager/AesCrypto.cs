using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bcat_Manager
{
    public class AesCrypto
    {
        public static byte[] PerformAesCTR(byte[] SourceBuffer, int Offset, int Size, byte[] key, byte[] iv)
        {
            byte[] encCounter = new byte[0x10];
            byte[] decryptedBuffer = new byte[Size];
            byte[] ctr = iv;

            Aes aes = Aes.Create();
            aes.Mode = CipherMode.ECB;
            aes.BlockSize = 128;
            aes.KeySize = key.Length * 8;
            aes.Key = key;

            for (int i = Offset; i < Size; i += 0x10)
            {
                using (var transform = aes.CreateEncryptor())
                {

                    int transed = 0;
                    for (int j = 0; j < 0x10; j += transed)
                    {
                        transed = transform.TransformBlock(ctr, j, 0x10, encCounter, j);
                    }

                    int rest = Size - i;
                    if (rest > 0x10) rest = 0x10;

                    //xor encrypted counter with ciphertext
                    for (int j = 0; j < rest; j++)
                    {
                        decryptedBuffer[i + j] = (byte)(encCounter[j] ^ SourceBuffer[i + j]);
                    }
                    //increment counter
                    for (var j = ctr.Length - 1; j >= 0; j--)
                    {
                        if (++ctr[j] != 0)
                            break;
                    }
                }
            }

            return decryptedBuffer;
        }
    }
}
