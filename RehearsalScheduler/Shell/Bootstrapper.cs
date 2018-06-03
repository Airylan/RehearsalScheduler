using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Shell.Views;

namespace Shell
{
    internal class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell() => Container.Resolve<MainWindowView>();

        protected override void InitializeShell() => Application.Current.MainWindow.Show();

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType<MainWindowView>();
        }
    }
}