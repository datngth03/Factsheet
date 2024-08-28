using Sabeco_Factsheet.Samples;
using Xunit;

namespace Sabeco_Factsheet.EntityFrameworkCore.Applications;

[Collection(Sabeco_FactsheetTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<Sabeco_FactsheetEntityFrameworkCoreTestModule>
{

}
