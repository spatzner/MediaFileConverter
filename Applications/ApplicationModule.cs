using System;
using System.Collections.Generic;
using Domain;
using Ninject.Modules;

namespace Applications
{
    public class ApplicationModule : NinjectModule
    {
        private readonly string defaultLocation;

        public ApplicationModule(string defaultLocation)
        {
            this.defaultLocation = defaultLocation;
        }

        public override void Load()
        {
            // ReSharper disable once PossibleNullReferenceException - Not null if wired correctly
            Kernel.Load(new[] {new DomainModule()});

            //TODO: put in persistent location
            var suppliedResolutions = new List<Resolution>
            {
                new Resolution(4, 6, 300),
                new Resolution(8, 10, 300),
                new Resolution(11, 14, 300)
            };

            Bind<IFileConverter>().To<FileConverter>()
                .WithConstructorArgument(typeof(string), defaultLocation)
                .WithConstructorArgument(typeof(List<Resolution>), suppliedResolutions);
        }
    }
}