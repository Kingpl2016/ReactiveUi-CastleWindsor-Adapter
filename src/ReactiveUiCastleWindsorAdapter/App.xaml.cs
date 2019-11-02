// // ********************************************************************************************************
// //
// // Solution: ReactiveUiCastleWindsorAdapter
// // Project:  ReactiveUiCastleWindsorAdapter
// // Filename: App.xaml.cs
// //
// // Author:   Gehrke, Patrick
// // Created:  02.11.2019 10:51
// // Updated:  02.11.2019 11:57
// //
// // See the file LICENSE for redistribution information.
// // ********************************************************************************************************

namespace ReactiveUiCastleWindsorAdapter
{
    using Common;
    using System.Windows;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App 
    {
        private readonly Bootstrapper bootstrapper;

        public App()
        {
            this.bootstrapper = new Bootstrapper().Setup();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.bootstrapper.DisplayRootView();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            this.bootstrapper.Dispose();
        }
    }
}