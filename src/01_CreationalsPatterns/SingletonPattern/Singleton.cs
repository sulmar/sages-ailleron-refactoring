using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class Singleton<T>
        where T : class, new()
    {
        private static object _syncLock = new object();

        private static T _instance;
        public static T Instance
        {
            get
            {
                lock (_syncLock)                // Monitor.Enter(object);
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                }                               // Monitor.Exit(object);

                return _instance;

            }
        }
    }
}
