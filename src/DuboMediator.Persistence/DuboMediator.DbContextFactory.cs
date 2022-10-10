using DuboMediator.Application.Consts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DuboMediator.Persistence
{
    public class DuboMediatorDbContextFactory : IDesignTimeDbContextFactory<DuboMediatorDbContext>
    {
        public DuboMediatorDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../API"))
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DuboMediatorDbContext>();
            var connectionString = configuration.GetConnectionString(AppConsts.DbConnectionName);

            builder.UseSqlServer(connectionString);

            return new DuboMediatorDbContext(builder.Options);
        }
    }
}