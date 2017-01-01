using Ninject;
using System;
using VeeamSignatureTest.BL;

namespace VeeamSignatureTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            byte[] buffer;
            int blockSize;
            Console.Write("Enter block size:");
            blockSize = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Enter file path:");
            //var path = Console.ReadLine();
            buffer = new byte[blockSize];
            var kernel = new StandardKernel();
            kernel.Load(new NinjectConfigure());
            var runner = kernel.Get<AppRunner>();
            runner.Run(@"C:\Users\Игорь\Downloads\1vieyra_robert_programmirovanie_baz_dannykh_ms_sql_server_200.pdf", blockSize, buffer);
            Console.WriteLine("\n Completed. \n Block size chosen:{0} bytes \n Total blocks amount: {1} \n Total file size: {2} Mb \n Press any key to exit.",
                blockSize, runner.BlockNum, runner.FileSize);
            Console.ReadKey();
        }
    }
}
