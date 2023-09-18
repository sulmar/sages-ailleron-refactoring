using System;

namespace SingletonPattern
{
    public class LazySingleton<T>
        where T : class, new()
    {
        private static Lazy<T> instance => new Lazy<T>(() => new T());
        public static T Instance => instance.Value; 
    }
}
