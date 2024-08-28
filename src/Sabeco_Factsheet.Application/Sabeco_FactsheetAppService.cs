using Sabeco_Factsheet.Localization;
using Volo.Abp.Application.Services;

namespace Sabeco_Factsheet;

/* Inherit your application services from this class.
 */
public abstract class Sabeco_FactsheetAppService : ApplicationService
{
    protected Sabeco_FactsheetAppService()
    {
        LocalizationResource = typeof(Sabeco_FactsheetResource);
    }
}
