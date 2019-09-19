using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using messaging.Contracts;

namespace messaging
{
    public class HandlerRegistry : IHandlerRegistry
    {
        private readonly Dictionary<Type, List<Type>> _handlers;

        public HandlerRegistry()
        {
            _handlers = new Dictionary<Type, List<Type>>();
        }

        public void Register(Assembly assembly)
        {
            var registry = from t in assembly.GetTypes()
                           let handlerOf = t.GetInterfaces()
                               .SingleOrDefault(i => i.IsGenericType && (i.GetGenericTypeDefinition() == typeof(IHandleCommand<>) ||
                                                        (i.GetGenericTypeDefinition() == typeof(IHandleCommand<,>))))
                           where handlerOf != null
                           select new
                           {
                               CommandType = handlerOf.GetGenericArguments()[0],
                               HandlerType = t
                           };

            foreach (var registration in registry)
            {
                if (_handlers.ContainsKey(registration.CommandType))
                {
                    _handlers[registration.CommandType].Add(registration.HandlerType);
                }
                else
                {
                    _handlers.Add(registration.CommandType, new List<Type> { registration.HandlerType });
                }
            }
        }

        public IEnumerable<Type> GetHandlerTypesFor<TCommand>()
        {
            if (_handlers.ContainsKey(typeof(TCommand)))
            {
                return _handlers[typeof(TCommand)];
            }

            throw new Exception($"No handler is registered for {typeof(TCommand).Name}");
        }

        public IEnumerable<Type> GetHandlerTypesFor<TCommand, TResult>()
        {
            if (_handlers.ContainsKey(typeof(TCommand)))
            {
                return _handlers[typeof(TCommand)];
            }

            throw new Exception(
                $"No handler is registered for {typeof(TCommand).Name} with result type {typeof(TResult).Name}");
        }
    }

}