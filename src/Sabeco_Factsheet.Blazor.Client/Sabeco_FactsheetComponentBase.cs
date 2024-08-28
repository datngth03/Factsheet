using Sabeco_Factsheet.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Sabeco_Factsheet.Blazor.Client;

public abstract class Sabeco_FactsheetComponentBase : AbpComponentBase
{
    protected Sabeco_FactsheetComponentBase()
    {
        LocalizationResource = typeof(Sabeco_FactsheetResource);
    }
}
