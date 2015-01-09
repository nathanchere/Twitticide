using System;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Twitticide
{
    public static class IOC
    {
        private static WindsorContainer _windsorContainer;

        #region Initialise
        public static void Initialize()
        {
            if (_windsorContainer != null) throw new InvalidOperationException("IOC container is already initialised");
            Initialize(new WindsorContainer());
        }

        private static void Initialize(WindsorContainer container)
        {
            if (_windsorContainer != null) throw new InvalidOperationException("IOC container is already initialised");
            _windsorContainer = container;
        }

        public static void ForceInitialize()
        {
            ForceInitialize(new WindsorContainer());
        }

        public static void ForceInitialize(WindsorContainer container)
        {
            if (_windsorContainer != null) _windsorContainer.Dispose();
            _windsorContainer = null;

            Initialize(container);
        }
        #endregion

        #region Main usage

        public static void Release(object obj)
        {
            _windsorContainer.Release(obj);
        }

        public static T Resolve<T>()
        {
            return _windsorContainer.Resolve<T>();
        }

        public static T SafeResolve<T>()
        {
            return _windsorContainer.Resolve<T>();
        }
        #endregion

        #region Binding
        public static BindingContext Bind<T>()
        {
            return new BindingContext(Component.For(typeof(T)));
        }

        public static BindingContext Bind(Type abstractType)
        {
            return new BindingContext(Component.For(abstractType));
        }

        public class BindingContext
        {
            private ComponentRegistration _binding;

            public BindingContext(ComponentRegistration binding)
            {
                _binding = binding;
            }

            public BindingTarget To(Type concreteType)
            {
                return new BindingTarget(_binding.ImplementedBy(concreteType));
            }

            public BindingTarget ToInstance(object instance)
            {
                return new BindingTarget(_binding.Instance(instance));
            }
        }

        public class BindingTarget
        {
            private ComponentRegistration<object> _binding;

            public BindingTarget(ComponentRegistration<object> binding)
            {
                _binding = binding;
                _windsorContainer.Register(_binding);
            }

            public void ScopeAsInstance()
            {
                _binding.LifeStyle.Is(LifestyleType.Scoped);
            }

            public void ScopeAsSingleton()
            {
                _binding.LifeStyle.Is(LifestyleType.Singleton);
            }

            public void ScopeAsTransient()
            {
                _binding.LifeStyle.Is(LifestyleType.Transient);
            }

            public void ScopeAsThread()
            {
                _binding.LifeStyle.Is(LifestyleType.Thread);
            }
        }
        #endregion

    }
}
