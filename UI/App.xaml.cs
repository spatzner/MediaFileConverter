using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Ninject;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            _container = new StandardKernel
            (
                new UIModule()
            );
            
            Current.MainWindow = _container.Get<MainWindow>();
            Current.MainWindow.Show();
        }
    }
}
