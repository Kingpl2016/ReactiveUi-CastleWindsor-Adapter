// // ********************************************************************************************************
// //
// // Solution: ReactiveUiCastleWindsorAdapter
// // Project:  ReactiveUiCastleWindsorAdapter
// // Filename: CastleWindsorDependencyResolver.cs
// //
// // Author:   Gehrke, Patrick
// // Created:  02.11.2019 11:57
// // Updated:  02.11.2019 11:58
// //
// // See the file LICENSE for redistribution information.
// // ********************************************************************************************************

// ReSharper disable SuspiciousTypeConversion.Global

namespace ReactiveUiCastleWindsorAdapter.Common
{
    using System;
    using System.Collections.Generic;
    
    using Splat;
    using Castle.Windsor;
    using Castle.MicroKernel.Registration;

    public class CastleWindsorDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer windsorContainer;

        public CastleWindsorDependencyResolver(IWindsorContainer windsorContainer)
        {
            this.windsorContainer = windsorContainer;
        }

        public object GetService(Type serviceType, string contract = null)
        {
            return string.IsNullOrEmpty(contract) ? this.windsorContainer.Resolve(serviceType) : this.windsorContainer.Resolve(contract, serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType, string contract = null)
        {
            return (IEnumerable<object>) this.windsorContainer.ResolveAll(serviceType);
        }

        public bool HasRegistration(Type serviceType, string contract = null)
        {
            return this.windsorContainer.Kernel.HasComponent(serviceType);
        }

        public void Register(Func<object> factory, Type serviceType, string contract = null)
        {
            this.windsorContainer.Register(Component.For(serviceType)
                .Instance(factory())
                .IsDefault()
                .Named(Guid.NewGuid().ToString()));
        }

        #region not needed

        public void UnregisterCurrent(Type serviceType, string contract = null)
        {
            throw new NotImplementedException();
        }

        public void UnregisterAll(Type serviceType, string contract = null)
        {
            throw new NotImplementedException();
        }

        public IDisposable ServiceRegistrationCallback(Type serviceType, string contract, Action<IDisposable> callback)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        #endregion
    }
}