using Sabeco_Factsheet.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Sabeco_Factsheet.Blazor;

public abstract class Sabeco_FactsheetComponentBase : AbpComponentBase
{
    protected Sabeco_FactsheetComponentBase()
    {
        LocalizationResource = typeof(Sabeco_FactsheetResource);
    }
}
