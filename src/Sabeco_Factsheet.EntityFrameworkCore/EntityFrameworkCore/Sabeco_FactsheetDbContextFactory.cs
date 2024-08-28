using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Sabeco_Factsheet.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class Sabeco_FactsheetDbContextFactory : IDesignTimeDbContextFactory<Sabeco_FactsheetDbContext>
{
    public Sabeco_FactsheetDbContext CreateDbContext(string[] args)
    {
        Sabeco_FactsheetEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<Sabeco_FactsheetDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new Sabeco_FactsheetDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Sabeco_Factsheet.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
