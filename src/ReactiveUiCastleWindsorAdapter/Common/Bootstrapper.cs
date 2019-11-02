// // ********************************************************************************************************
// //
// // Solution: ReactiveUiCastleWindsorAdapter
// // Project:  ReactiveUiCastleWindsorAdapter
// // Filename: Bootstrapper.cs
// //
// // Author:   Gehrke, Patrick
// // Created:  02.11.2019 11:02
// // Updated:  02.11.2019 11:03
// //
// // See the file LICENSE for redistribution information.
// // ********************************************************************************************************

namespace ReactiveUiCastleWindsorAdapter.Common
{
    using System;

    using Splat;
    using Views;
    using ReactiveUI;
    using Castle.Windsor;
    using Castle.Windsor.Installer;

    public class Bootstrapper : IDisposable
    {
        private readonly IWindsorContainer container;

        public Bootstrapper()
        {
            this.container = new WindsorContainer();
        }

        public void Setup()
        {
            Locator.SetLocator(new CastleWindsorDependencyResolver(this.container));
            Locator.CurrentMutable.InitializeSplat();
            Locator.CurrentMutable.InitializeReactiveUI();
            this.container.Install(FromAssembly.Named("ReactiveUiCastleWindsorAdapter"));
        }

        public void DisplayRootView()
        {
            var shellView = this.container.Resolve<ShellView>();
            shellView.Show();
        }

        public void Dispose()
        {
            this.container?.Dispose();
        }
    }
}