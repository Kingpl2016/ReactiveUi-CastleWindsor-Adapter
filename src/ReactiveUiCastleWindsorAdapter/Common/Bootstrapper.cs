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
    using Splat;
    using System;
    using ReactiveUI;

    public class Bootstrapper : IDisposable
    {
        public void Setup()
        {
            Locator.CurrentMutable.InitializeSplat();
            Locator.CurrentMutable.InitializeReactiveUI();
        }

        public void Dispose()
        {
        }
    }
}