using System;
using System.Collections.Generic;

namespace Game.Scripts.Root.Services
{
    public class ServiceLocator
    {
        private static ServiceLocator _instance;

        public static ServiceLocator Instance => _instance ??= new ServiceLocator();

        private readonly Dictionary<Type, object> _services = new();

        public void RegisterSingle<T>(T service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));
            
            Type type = typeof(T);
            if (_services.TryAdd(type, service) == false)
                throw new ArgumentException("Service already registered");
        }

        public T Resolve<T>()
        {
            Type type = typeof(T);
            if (_services.TryGetValue(type, out object service) == false)
                throw new ArgumentException("Service not registered");
            
            return (T) service;
        }
    }
}