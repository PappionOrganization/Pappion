using Microsoft.EntityFrameworkCore;
using Pappion.Infrastructure;

namespace Pappion.API.Helpers
{
    public static class MigrationHelper
    {
        public static void ApplyMigrations(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<PappionDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
