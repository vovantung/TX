using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TX.Data.EF
{
    public class TXDbContextFactory : IDesignTimeDbContextFactory<TXDbContext>
    {
        public TXDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectString = configuration.GetConnectionString("TXConnectionString");
            var optionBuilder = new DbContextOptionsBuilder<TXDbContext>();
            optionBuilder.UseSqlServer(connectString);
            return new TXDbContext(optionBuilder.Options);
        }
    }
}