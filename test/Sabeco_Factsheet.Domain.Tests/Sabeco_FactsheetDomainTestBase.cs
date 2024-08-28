using Volo.Abp.Modularity;

namespace Sabeco_Factsheet;

/* Inherit from this class for your domain layer tests. */
public abstract class Sabeco_FactsheetDomainTestBase<TStartupModule> : Sabeco_FactsheetTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
