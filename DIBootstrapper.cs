using System;
using Autofac;
using Autofac.Core;
namespace sallybot {
    /// <summary>
    /// Bootstrapper for AutoFac, sets up and handles Dependency Injection
    /// </summary>
    public static class DI {
        private static ILifetimeScope _rootScope;

        /// <summary>
        /// Initialises the root scope with provided builder
        /// </summary>
        /// <param name="action">A Lambda that builds the Container</param>
        /// <returns></returns>
        public static ILifetimeScope Init(Action<ContainerBuilder> action) {
            if (_rootScope != null) {
                return _rootScope;
            }
        
            var builder = new ContainerBuilder();
            action(builder);
            _rootScope = builder.Build();
            return _rootScope;
        }

        /// <summary>
        /// Determines if the bootstrapper has already been initialised
        /// </summary>
        /// <returns></returns>
        public static bool IsInitialised() {
            return _rootScope != null;
        }

        /// <summary>
        /// Disposes the bootstrapper
        /// </summary>
        public static void Stop() {
            _rootScope.Dispose();
        }

        /// <summary>
        /// Resolves a specific type registered with the bootstrapper in Init
        /// </summary>
        /// <typeparam name="T">The Type to resolve</typeparam>
        /// <returns>The Resolved Type</returns>
        /// <exception cref="Exception">Thrown if this method is called before the bootstrapper has been started</exception>
        public static T Resolve<T>() {
            if (_rootScope == null) {
                throw new Exception("Bootstrapper hasn't been started!");
            }

            return _rootScope.Resolve<T>(new Parameter[0]);
        }

        /// <summary>
        /// Resolves a specific type registered with the bootstrapper in Init
        /// </summary>
        /// <typeparam name="T">The Type to resolve</typeparam>
        /// <returns>The Resolved Type</returns>
        /// <exception cref="Exception">Thrown if this method is called before the bootstrapper has been started</exception>
        public static T Resolve<T>(Parameter[] parameters) {
            if (_rootScope == null) {
                throw new Exception("Bootstrapper hasn't been started!");
            }

            return _rootScope.Resolve<T>(parameters);
        }
    }
}