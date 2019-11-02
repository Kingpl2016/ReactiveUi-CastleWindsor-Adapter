// // ********************************************************************************************************
// //
// // Solution: ReactiveUiCastleWindsorAdapter
// // Project:  ReactiveUiCastleWindsorAdapter
// // Filename: UiInstaller.cs
// //
// // Author:   Gehrke, Patrick
// // Created:  02.11.2019 12:00
// // Updated:  02.11.2019 12:00
// //
// // See the file LICENSE for redistribution information.
// // ********************************************************************************************************

namespace ReactiveUiCastleWindsorAdapter.Installer
{
    using System.Reflection;

    using ReactiveUI;
    using Castle.Core;
    using Castle.Windsor;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using MahApps.Metro.Controls.Dialogs;

    public class UiInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDialogCoordinator>()
                                        .ImplementedBy<DialogCoordinator>()
                                        .LifeStyle.Is(LifestyleType.Singleton));

            container.Register(Classes.FromAssembly(Assembly.GetExecutingAssembly())
                                      .BasedOn(typeof(IViewFor<>))
                                      .WithServiceSelf()
                                      .ConfigureIf(whenView => whenView.Implementation.Name == "ShellView", 
                                                   set => set.LifeStyle.Is(LifestyleType.Singleton), 
                                                   otherwise => otherwise.LifeStyle.Is(LifestyleType.Transient)));

            container.Register(Classes.FromAssembly(Assembly.GetExecutingAssembly())
                                      .InNamespace("ReactiveUiCastleWindsorAdapter.ViewModels")
                                      .WithServiceSelf()
                                      .ConfigureIf(whenViewModel => whenViewModel.Implementation.Name == "ShellViewModel",
                                                   set => set.LifeStyle.Is(LifestyleType.Singleton),
                                                   otherwise => otherwise.LifeStyle.Is(LifestyleType.Transient)));
        }
    }
}