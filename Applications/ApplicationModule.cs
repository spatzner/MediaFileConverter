using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Ninject.Modules;

namespace Applications
{
    public class ApplicationModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Load(new []{new DomainModule()});

            Bind<IFileConverter>().To<FileConverter>();
        }
    }
}
