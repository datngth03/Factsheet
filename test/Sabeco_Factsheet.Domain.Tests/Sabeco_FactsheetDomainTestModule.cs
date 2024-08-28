using Volo.Abp.Modularity;

namespace Sabeco_Factsheet;

[DependsOn(
    typeof(Sabeco_FactsheetDomainModule),
    typeof(Sabeco_FactsheetTestBaseModule)
)]
public class Sabeco_FactsheetDomainTestModule : AbpModule
{

}
