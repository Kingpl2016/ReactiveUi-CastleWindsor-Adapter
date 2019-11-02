// // ********************************************************************************************************
// //
// // Solution: ReactiveUiCastleWindsorAdapter
// // Project:  ReactiveUiCastleWindsorAdapter
// // Filename: StatusBarViewModel.cs
// //
// // Author:   Gehrke, Patrick
// // Created:  02.11.2019 12:37
// // Updated:  02.11.2019 12:38
// //
// // See the file LICENSE for redistribution information.
// // ********************************************************************************************************

namespace ReactiveUiCastleWindsorAdapter.ViewModels
{
    using ReactiveUI;

    public class StatusBarViewModel : ReactiveObject
    {
        public StatusBarViewModel()
        {
            this.AppVersion = "Version 1.0 | DEBUG";
        }

        private string appVersion;
        public string AppVersion
        {
            get => this.appVersion;
            private set => this.RaiseAndSetIfChanged(ref this.appVersion, value);
        }
    }
}