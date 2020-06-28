using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            Bind<IImageConverter>().To<AIToSVGConverter>().Named(ConverterType.AIToSVG);
            Bind<IImageConverter>().To<SVGToPNGConverter>().Named(ConverterType.SVGToPNG);
            Bind<IFileProcessor>().To<FileProcessor>();
        }
    }
}
