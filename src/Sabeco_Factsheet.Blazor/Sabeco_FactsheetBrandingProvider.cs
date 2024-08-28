using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Sabeco_Factsheet.Blazor;

[Dependency(ReplaceServices = true)]
public class Sabeco_FactsheetBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "";
}
