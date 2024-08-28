using Sabeco_Factsheet.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Sabeco_Factsheet.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(Sabeco_FactsheetEntityFrameworkCoreModule),
    typeof(Sabeco_FactsheetApplicationContractsModule)
)]
public class Sabeco_FactsheetDbMigratorModule : AbpModule
{
}
