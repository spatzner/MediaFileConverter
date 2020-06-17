using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Converters;
using Illustrator;
using Infrastructure;
using Ninject.Modules;

namespace Domain
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            // ReSharper disable once PossibleNullReferenceException - Not null if wired correctly
            Kernel.Load(new INinjectModule[] {new InfrastructureModule(), new IllustratorModule()});

            Bind<IAIConverter>().To<AIConverter>();
            Bind<ISVGConverter>().To<SVGConverter>();
            Bind<IFileProcessor>().To<FileProcessor>();
        }
    }
}
