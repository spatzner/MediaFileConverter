using Illustrator;
using Infrastructure.Providers;
using Infrastructure.Wrappers;

namespace Infrastructure.Factories
{
    public interface IIllustratorProviderFactory
    {
        IIllustratorWrapper Create();
    }
}