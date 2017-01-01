using System.IO;

namespace VeeamSignatureTest.Encryptors.Interfaces
{
    public interface IEncryptor
    {
        byte[] Encrypt(Stream inputStream);
    }
}
