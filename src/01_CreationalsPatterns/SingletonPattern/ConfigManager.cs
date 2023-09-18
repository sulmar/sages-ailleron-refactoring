using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class ConfigManager
    {
        private readonly Dictionary<string, object> settings = new Dictionary<string, object>();

        private ConfigManager() 
        { 
        }

        private static ConfigManager _instance;

        public static ConfigManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigManager();
                }

                return _instance;
            }
        }

        public void Set(string key, object value)
        {
            if (settings.ContainsKey(key))
            {
                settings[key] = value;
            }
            else
            {
                settings.Add(key, value);
            }
        }

        public object Get(string key) {
            
            if (settings.ContainsKey(key)) 
            {
                return settings[key];
            }
            else 
                return null;
            
        }
    }
}
