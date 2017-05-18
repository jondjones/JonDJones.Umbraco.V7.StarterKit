using System.Configuration;

namespace JonDJones.Core.Resources
{
    public static class ConfigSettings
    {
        public static bool UmbracoDebugMode => GetBool("umbracoDebugMode");
        
        public static bool EnablePageCaching => GetBool("EnablePageCaching");

        public static string UmbracoConnectionString => ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString;



        public static class Redis
        {
            public static bool UseRedis => GetBool("EnablePageCaching");

            public static string RedisHost => GetAppSetting("RedisHost");

            public static string RedisPassword => GetAppSetting("RedisPassword");

            public static int RedisPort => GetInt("RedisPort");

            public static bool RedisUseSSl => GetBool("RedisUseSSl");

            public static bool EnableRedisLogging => GetBool("EnableRedisLogging");
        }
        private static bool GetBool(string boolToConvert)
        {
            if (string.IsNullOrEmpty(boolToConvert))
                return false;

           var appSetting = GetAppSetting(boolToConvert);

            bool returnValue;
            return bool.TryParse(appSetting, out returnValue) && returnValue;
        }

        private static int GetInt(string intToConvert)
        {
            if (string.IsNullOrEmpty(intToConvert))
                return default(int);

            var appSetting = GetAppSetting(intToConvert);

            int returnValue;
            return int.TryParse(appSetting, out returnValue) ? returnValue : default(int);
        }

        private static string GetAppSetting(string appSettingName)
        {
            var appSettings = ConfigurationManager.AppSettings;
            return appSettings[appSettingName] ?? string.Empty;
        }
    }
}