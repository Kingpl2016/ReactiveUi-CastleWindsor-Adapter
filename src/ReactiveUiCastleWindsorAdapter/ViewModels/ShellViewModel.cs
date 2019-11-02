// // ********************************************************************************************************
// //
// // Solution: ReactiveUiCastleWindsorAdapter
// // Project:  ReactiveUiCastleWindsorAdapter
// // Filename: ShellViewModel.cs
// //
// // Author:   Gehrke, Patrick
// // Created:  02.11.2019 11:00
// // Updated:  02.11.2019 11:00
// //
// // See the file LICENSE for redistribution information.
// // ********************************************************************************************************

namespace ReactiveUiCastleWindsorAdapter.ViewModels
{
    using ReactiveUI;

    public class ShellViewModel : ReactiveObject
    {
        public ShellViewModel(StatusBarViewModel statusBarViewModel)
        {
            this.StatusBar = statusBarViewModel;
            this.HelloWorld = "ReactiveUi is working :)";
        }

        private string helloWorld;
        public string HelloWorld
        {
            get => this.helloWorld;
            private set => this.RaiseAndSetIfChanged(ref this.helloWorld, value);
        }

        private StatusBarViewModel statusBar;
        public StatusBarViewModel StatusBar
        {
            get => this.statusBar;
            set => this.RaiseAndSetIfChanged(ref this.statusBar, value);
        }
    }
}