using Illustrator;
using Infrastructure.Providers;
using Infrastructure.Wrappers;

namespace Infrastructure.Factories
{
    public class IllustratorProviderFactory : IIllustratorProviderFactory
    {
        public IIllustratorWrapper Create()
        {
            return new IllustratorWrapper();
        }
    }
}
