namespace StellantisSupportAPI.Services
{
    public class ConfigManager
    {
        private static readonly Lazy<ConfigManager> instance = new Lazy<ConfigManager>(() => new ConfigManager());
        public static ConfigManager Instance => instance.Value;

        private ConfigManager() { }

        public string GetConfig(string key)
        {
            return "Valor de configuração";
        }

    }
}
