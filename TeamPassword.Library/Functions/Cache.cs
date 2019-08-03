using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamPassword.Library.Functions
{
    public class Cache
    {
        private Dictionary<string, object> CacheEntries = new Dictionary<string, object>();
        private static Cache _Instance = null;

        private Cache() { }

        public static Cache Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Cache();

                return _Instance;
            }
        }

        /// <summary>
        /// needs to be called first to register a cache entry!
        /// (only registers if there is none at the moment!)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        public void Register<T>(string name)
        {
            if (CacheEntries.ContainsKey(name.ToLower()))
                return;

            CacheEntries.Add(name.ToLower(), (T)Activator.CreateInstance<T>());
        }

        /// <summary>
        /// returns a registered cache entry (call Retgister first!)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T GetCache<T>(string name)
        {
            return (T)CacheEntries[name.ToLower()];
        }

        /// <summary>
        /// updates one registered cache entry
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Update(string name, object value)
        {
            CacheEntries[name.ToLower()] = value;
        }

        /// <summary>
        /// removes a registered cache entry
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {
            CacheEntries.Remove(name.ToLower());
        }
    }
}
