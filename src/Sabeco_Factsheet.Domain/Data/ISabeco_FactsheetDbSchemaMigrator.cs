using System.Threading.Tasks;

namespace Sabeco_Factsheet.Data;

public interface ISabeco_FactsheetDbSchemaMigrator
{
    Task MigrateAsync();
}
