using Sabeco_Factsheet.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Sabeco_Factsheet.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class Sabeco_FactsheetController : AbpControllerBase
{
    protected Sabeco_FactsheetController()
    {
        LocalizationResource = typeof(Sabeco_FactsheetResource);
    }
}
