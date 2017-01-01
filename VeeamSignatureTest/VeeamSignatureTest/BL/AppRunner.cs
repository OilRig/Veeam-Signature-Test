using System;
using System.IO;
using VeeamSignatureTest.Encryptors.Interfaces;
using VeeamSignatureTest.Helpers;

namespace VeeamSignatureTest.BL
{
    public class AppRunner : IAppRunner
    {
        private readonly IEncryptor _encryptor;
        private int BlockSize { get; set; }
        private object Locker { get; set; }
        public int BlockNum { get; set; }
        public long FileSize { get; set; }
        public AppRunner(IEncryptor encryptor)
        {
            _encryptor = encryptor;
            BlockNum = 0;
        }
        public void Run(string filePath, int blockSize, byte[] buffer)
        {
            using (var inputFile = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                FileSize = inputFile.Length / 1048576;
                while (inputFile.Length != inputFile.Position)
                {
                    inputFile.Read(buffer, 0, blockSize);
                    BlockNum++;
                    using (var encryptionStream = new MemoryStream(buffer))
                    {
                        byte[] resultEncryption = _encryptor.Encrypt(encryptionStream);

                        Console.WriteLine("In fileblock #{0} signature is {1}", BlockNum, ByteToStringConverter.BytesToString(resultEncryption));
                    }
                }
            }
        }


    }
}
