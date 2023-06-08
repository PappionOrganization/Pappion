using Microsoft.Extensions.Options;

namespace Pappion.API.Configurations
{
    public class DatabaseConfiguration : IOptions<DatabaseConfiguration>
    {
        public string Host { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string User { get; set; } = null!;

        public string Database { get; set; } = null!;

        public bool IsAutoMigrationEnabled { get; set; }

        public DatabaseConfiguration Value => this;
    }
}
