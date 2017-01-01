namespace VeeamSignatureTest.BL
{
    public interface IAppRunner
    {
        void Run(string filePath, int blockSize, byte[] buffer);
    }
}