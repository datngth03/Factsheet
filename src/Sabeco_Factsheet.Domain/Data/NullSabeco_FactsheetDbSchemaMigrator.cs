using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Sabeco_Factsheet.Data;

/* This is used if database provider does't define
 * ISabeco_FactsheetDbSchemaMigrator implementation.
 */
public class NullSabeco_FactsheetDbSchemaMigrator : ISabeco_FactsheetDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
