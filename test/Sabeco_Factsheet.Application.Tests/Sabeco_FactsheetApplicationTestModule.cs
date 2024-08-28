using Volo.Abp.Modularity;

namespace Sabeco_Factsheet;

[DependsOn(
    typeof(Sabeco_FactsheetApplicationModule),
    typeof(Sabeco_FactsheetDomainTestModule)
)]
public class Sabeco_FactsheetApplicationTestModule : AbpModule
{

}
