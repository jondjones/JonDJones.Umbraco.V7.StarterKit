using System;
using JonDJones.Com.Interfaces;
using JonDJones.Core.Resources;
using log4net;
using StackExchange.Redis;

namespace JonDJones.Core.Dependencies.Cache
{
    public class RedisCacheProvider : ICacheProvider
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(RedisCacheProvider));

        private IDatabase _database;

        public RedisCacheProvider()
        {
            var redisHost = ConfigSettings.Redis.RedisHost;
            var redisPort = ConfigSettings.Redis.RedisPort;
            var useSsl = ConfigSettings.Redis.RedisUseSSl;

            var connectionString = $"{redisHost}:{redisPort}";

            var redisPassword = ConfigSettings.Redis.RedisPassword;

            if (!string.IsNullOrEmpty(redisPassword))
                connectionString = $"{connectionString},password={redisPassword},ssl={useSsl},abortConnect=false";

            var connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
            _database = connectionMultiplexer.GetDatabase();
        }

        public void DeleteValue(string key)
        {
            try
            {
                key = key.Replace(" ", string.Empty);
                _database.KeyDelete(key);
            }
            catch (Exception ex)
            {
                _logger.Error($"Unable to delete {key} from Redis", ex);
            }
        }

        public object GetValue(string key)
        {
            if (string.IsNullOrEmpty(key))
                return null;

            try
            {
                return _database.StringGet(key);
            }
            catch (Exception ex)
            {
                _logger.Error($"Unable to read {key} from Redis", ex);
            }

            return null;
        }

        public bool Contains(string key)
        {
            try
            {
                return _database.KeyExists(key);
            }
            catch (Exception ex)
            {
                _logger.Error($"Unable to KeyExists {key} from Redis", ex);
            }

            return false;
        }

        public void StoreString(string key, string value)
        {
            try
            {
                _database.StringSet(key, value);
            }
            catch (Exception ex)
            {
                _logger.Error($"Unable to StoreString {key} from Redis", ex);
            }
        }

        public void StoreString(string key, string value, TimeSpan timeInterval)
        {
            try
            {
                _database.StringSet(key, value, timeInterval);
            }
            catch (Exception ex)
            {
                _logger.Error($"Unable to StoreString {key} from Redis", ex);
            }
        }

        public string GetStringValue(string key)
        {
            if (string.IsNullOrEmpty(key))
                return null;

            try
            {
                string valueAsString = _database.StringGet(key);

                return !string.IsNullOrEmpty(valueAsString)
                    ? valueAsString.Trim()
                    : string.Empty;
            }
            catch (Exception ex)
            {
                _logger.Error($"Unable to read {key} from Redis", ex);
            }

            return string.Empty;
        }
    }
}