using System.IO;
using System.Security.Cryptography;
using VeeamSignatureTest.Encryptors.Interfaces;

namespace VeeamSignatureTest.Encryptors.Implementators
{
    public class SHA256Encryptor : IEncryptor
    {
        private readonly SHA256Managed _encriptonEngine;
        private readonly Stream _encryptionData;
        public SHA256Encryptor()
        {
            _encriptonEngine = new SHA256Managed();

        }
        public byte[] Encrypt(Stream encryptionStream)
        {
            var resultEncrypton = _encriptonEngine.ComputeHash(encryptionStream);
            return resultEncrypton;
        }
    }
}
