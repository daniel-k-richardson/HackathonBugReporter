using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.HostedService;
internal class DatabaseMigrationService : IHostedService
{
    private readonly IServiceScopeFactory _context;
    private readonly ILogger _logger;

    public DatabaseMigrationService(
        IServiceScopeFactory context,
        ILogger<DatabaseMigrationService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _context.CreateScope())
        {
            try
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                if (context.Database.EnsureCreated())
                {
                    context.Database.Migrate();
                }

                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
            catch (Exception expection)
            {
                _logger.LogError(default, expection);
                throw;
            }
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
