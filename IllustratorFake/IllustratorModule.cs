﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

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
