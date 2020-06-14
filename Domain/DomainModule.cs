using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Converters;
using Infrastructure;
using Ninject.Modules;

namespace Domain
{
    public class DomainModule : NinjectModule
    {
        public override void Load()
        {
            // ReSharper disable once PossibleNullReferenceException
            Kernel.Load(new []{new InfrastructureModule()});

            Bind<IAIConverter>().To<AIConverter>();
            Bind<ISVGConverter>().To<SVGConverter>();
            Bind<IFileProcessor>().To<FileProcessor>();
        }
    }
}
