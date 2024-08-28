using Sabeco_Factsheet.Samples;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Domains;

[Collection(Sabeco_FactsheetTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<Sabeco_FactsheetEntityFrameworkCoreTestModule>
{

}
