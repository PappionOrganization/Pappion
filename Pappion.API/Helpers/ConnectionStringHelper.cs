using Pappion.API.Configurations;

namespace Pappion.API.Helpers
{
    public static class ConnectionStringHelper
    {
        public static string GetMySlqConnectionString(DatabaseConfiguration configuration)
        {
            return $"Server={configuration.Host};Password={configuration.Password};User={configuration.User};Database={configuration.Database};";
        }
    }
}
