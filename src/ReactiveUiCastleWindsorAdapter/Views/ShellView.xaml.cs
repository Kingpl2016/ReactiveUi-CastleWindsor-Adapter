﻿// // ********************************************************************************************************
// //
// // Solution: ReactiveUiCastleWindsorAdapter
// // Project:  ReactiveUiCastleWindsorAdapter
// // Filename: ShellView.xaml.cs
// //
// // Author:   Gehrke, Patrick
// // Created:  02.11.2019 10:59
// // Updated:  02.11.2019 11:00
// //
// // See the file LICENSE for redistribution information.
// // ********************************************************************************************************

namespace ReactiveUiCastleWindsorAdapter.Views
{
    using System.Windows;
    using System.Reactive.Disposables;
    
    using ReactiveUI;
    using ViewModels;
    using MahApps.Metro.Controls;

    /// <summary>
    ///     Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : MetroWindow, IViewFor<ShellViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel",
            typeof(ShellViewModel), typeof(ShellView), new PropertyMetadata(null));

        public ShellView(ShellViewModel viewModel)
        {
            this.InitializeComponent();
            this.ViewModel = viewModel;

            this.WhenActivated(d =>
            {
                this.OneWayBind(this.ViewModel, vm => vm.HelloWorld, view => view.TestLabel.Content).DisposeWith(d);
                this.OneWayBind(this.ViewModel, vm => vm.StatusBar, view => view.StatusBarHost.ViewModel).DisposeWith(d);
            });
        }

        /// <summary>
        ///     Gets or sets the View Model associated with the View.
        /// </summary>
        object IViewFor.ViewModel
        {
            get => this.ViewModel;
            set => this.ViewModel = (ShellViewModel)value;
        }

        /// <summary>
        ///     Gets or sets the ViewModel corresponding to this specific View. This should be
        ///     a DependencyProperty if you're using XAML.
        /// </summary>
        public ShellViewModel ViewModel
        {
            get => (ShellViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
    }
}