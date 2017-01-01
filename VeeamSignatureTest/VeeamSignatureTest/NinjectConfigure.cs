using Ninject.Modules;
using VeeamSignatureTest.BL;
using VeeamSignatureTest.Encryptors.Implementators;
using VeeamSignatureTest.Encryptors.Interfaces;

namespace VeeamSignatureTest
{
    public class NinjectConfigure : NinjectModule
    {
        IEncryptor encryptor;
        public override void Load()
        {
            Bind<IEncryptor>().To<SHA256Encryptor>();
            Bind<IAppRunner>().To<AppRunner>().WithConstructorArgument("encryptor", encryptor);
        }
    }
}
