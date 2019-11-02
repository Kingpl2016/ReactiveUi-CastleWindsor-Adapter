using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ReactiveUiCastleWindsorAdapter
{
    using Common;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Bootstrapper bootstrapper;

        public App()
        {
            this.bootstrapper = new Bootstrapper();
            this.bootstrapper.Setup();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            this.bootstrapper.Dispose();
        }
    }
}
