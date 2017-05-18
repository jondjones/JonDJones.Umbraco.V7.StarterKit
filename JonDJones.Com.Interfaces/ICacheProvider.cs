using System;

namespace JonDJones.Com.Interfaces
{
    public interface ICacheProvider
    {
        void DeleteValue(string key);

        object GetValue(string key);

        bool Contains(string key);

        void StoreString(string key, string value);

        void StoreString(string key, string value, TimeSpan timeInterval);

        string GetStringValue(string key);
    }
}
