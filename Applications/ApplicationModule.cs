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
            // ReSharper disable once PossibleNullReferenceException - Not null if wired correctly
            Kernel.Load(new []{new DomainModule()});

            //TODO: put in config file
            var suppliedResolutions = new List<Resolution>
            {
                new Resolution(4,6, 300),
                new Resolution(8,10, 300),
                new Resolution(11,14, 300)
            };

            Bind<IFileConverter>().To<FileConverter>()
                .WithConstructorArgument(typeof(string), Environment.GetFolderPath(Environment.SpecialFolder.Desktop))
                .WithConstructorArgument(typeof(List<Resolution>), suppliedResolutions);
        }
    }
}
