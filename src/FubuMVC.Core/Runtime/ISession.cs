using System;
using FubuCore.Util;

namespace FubuMVC.Core.Runtime
{
    public interface ISession
    {
        T Get<T>();
        void Set<T>(T value);
    }

    public class BasicSession : ISession
    {
        private readonly Cache<Type, object> _objects = new Cache<Type,object>();

        public T Get<T>()
        {
            return (T) _objects[typeof(T)];
        }

        public void Set<T>(T value)
        {
            _objects[typeof (T)] = value;
        }
    }
}