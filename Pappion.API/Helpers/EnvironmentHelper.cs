namespace Pappion.API.Helpers
{
    public static class EnvironmentHelper
    {
        public static string? GetCurrentEnvironment()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        }
    }
}
