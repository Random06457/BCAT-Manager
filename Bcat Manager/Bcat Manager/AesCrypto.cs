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
        public static byte[] EncryptAesBlock(byte[] Block, byte[] key)
        {
            byte[] decryptedBuffer = new byte[0x10];

            Aes aes = Aes.Create();
            aes.Mode = CipherMode.ECB;
            aes.BlockSize = 128;
            aes.KeySize = key.Length * 8;
            aes.Key = key;

            int transed = 0;
            using (var transform = aes.CreateEncryptor())
            {
                for (int i = 0; i < 0x10; i += transed)
                {
                    transed = transform.TransformBlock(Block, i, 0x10, decryptedBuffer, i);
                }
            }

            return decryptedBuffer;
        }
        //todo : remove or update
        public static void EncryptAesBlock(Stream inStream, Stream ouStream, byte[] key)
        {
            BinaryReader br = new BinaryReader(inStream);
            BinaryWriter bw = new BinaryWriter(ouStream);

            byte[] decryptedBuffer = new byte[0x10];

            Aes aes = Aes.Create();
            aes.Mode = CipherMode.ECB;
            aes.BlockSize = 128;
            aes.KeySize = key.Length * 8;
            aes.Key = key;

            int transed = 0;
            using (var transform = aes.CreateEncryptor())
            {
                byte[] inBlock = br.ReadBytes(0x10);
                byte[] outBlock = new byte[0x10];

                for (int i = 0; i < 0x10; i += transed)
                {
                    transed = transform.TransformBlock(inBlock, i, 0x10, outBlock, i);
                }

                bw.Write(outBlock);
            }
        }

        //todo : optimise the code to be faster
        public static void PerformAesCtr(Stream inStream, Stream ouStream, int Size, byte[] key, byte[] iv)
        {
            BinaryReader br = new BinaryReader(inStream);
            BinaryWriter bw = new BinaryWriter(ouStream);

            for (var i = inStream.Position; i < Size; i += 0x10)
            {
                byte[] encCounter = EncryptAesBlock(iv, key);

                var rest = Size - i;
                if (rest > 0x10) rest = 0x10;

                //xor encrypted counter with ciphertext
                for (int j = 0; j < rest; j++)
                {
                    bw.BaseStream.Position = i + j;
                    br.BaseStream.Position = i + j;
                    bw.Write(br.ReadByte() ^ encCounter[j]);
                }

                //increment counter
                for (var j = iv.Length - 1; j >= 0; j--)
                {
                    if (++iv[j] != 0)
                        break;
                }
            }
        }
        public static byte[] PerformAesCTR(byte[] SourceBuffer, int Offset, int Size, byte[] key, byte[] iv)
        {
            byte[] decryptedBuffer = new byte[Size];

            byte[] counter = iv;

            for (int i = Offset; i < Size; i += 0x10)
            {
                byte[] encCounter = EncryptAesBlock(counter, key);

                int rest = Size - i;
                if (rest > 0x10) rest = 0x10;

                //xor encrypted counter with ciphertext
                for (int j = 0; j < rest; j++)
                {
                    decryptedBuffer[i + j] = (byte)(encCounter[j] ^ SourceBuffer[i + j]);
                }

                //increment counter
                for (var j = counter.Length - 1; j >= 0; j--)
                {
                    if (++counter[j] != 0)
                        break;
                }
            }

            return decryptedBuffer;
        }
    }
}
