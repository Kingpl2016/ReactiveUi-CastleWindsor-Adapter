// // ********************************************************************************************************
// //
// // Solution: ReactiveUiCastleWindsorAdapter
// // Project:  ReactiveUiCastleWindsorAdapter
// // Filename: StatusBarView.xaml.cs
// //
// // Author:   Gehrke, Patrick
// // Created:  02.11.2019 12:36
// // Updated:  02.11.2019 12:37
// //
// // See the file LICENSE for redistribution information.
// // ********************************************************************************************************

namespace ReactiveUiCastleWindsorAdapter.Views
{
    using ReactiveUI;
    using ViewModels;
    using System.Reactive.Disposables;

    /// <summary>
    ///     Interaction logic for StatusBarView.xaml
    /// </summary>
    public class StatusBarViewControl : ReactiveUserControl<StatusBarViewModel> { }
    public partial class StatusBarView : StatusBarViewControl
    {
        public StatusBarView()
        {
            this.InitializeComponent();

            this.WhenActivated(d =>
            {
                this.OneWayBind(this.ViewModel, vm => vm.AppVersion, view => view.AppVersion.Text).DisposeWith(d);
            });
        }
    }
}