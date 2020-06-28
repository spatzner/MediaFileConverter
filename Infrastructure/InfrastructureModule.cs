using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Illustrator;
using Infrastructure.Providers;
using Infrastructure.Wrappers;
using Ninject.Modules;

namespace Infrastructure
{
    public class InfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISVGWrapper>().To<SVGWrapper>();
            Bind<IDateTimeProvider>().To<DateTimeProvider>();
            Bind<IFileSystemProvider>().To<FileSystemProvider>();
            Bind<IBitmapWrapper>().To<BitmapWrapper>();
        }
    }
}
