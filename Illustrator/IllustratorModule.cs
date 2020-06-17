using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illustrator
{
    public class IllustratorModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IIllustratorProvider>().To<IllustratorProvider>();
        }
    }
}
