using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sabeco_Factsheet.Data;
using Volo.Abp.DependencyInjection;

namespace Sabeco_Factsheet.EntityFrameworkCore;

public class EntityFrameworkCoreSabeco_FactsheetDbSchemaMigrator
    : ISabeco_FactsheetDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSabeco_FactsheetDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the Sabeco_FactsheetDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<Sabeco_FactsheetDbContext>()
            .Database
            .MigrateAsync();
    }
}
