using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications;
using Ninject.Modules;
using UI.ViewModels;

namespace UI
{
    public class UIModule : NinjectModule
    {
        public override void Load()
        {
            string defaultLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // ReSharper disable once PossibleNullReferenceException - Not null if wired correctly
            Kernel.Load(new[] {new ApplicationModule(defaultLocation) });

            Bind<IFileConverterViewModel>().To<FileConverterViewModel>();
            Bind<MainWindow>().To<MainWindow>();
        }
    }
}
