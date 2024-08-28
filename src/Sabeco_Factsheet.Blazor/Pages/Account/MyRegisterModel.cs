using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sabeco_Factsheet.Blazor.Client.Pages;
using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.Account.ExternalProviders;
using Volo.Abp.Account.Public.Web.Pages.Account;
using Volo.Abp.Account.Public.Web;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;
using Volo.Abp;
using Volo.Abp.Account.Settings;
using Volo.Abp.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;

namespace Sabeco_Factsheet.Blazor.Pages.Account
{
    [ExposeServices(typeof(RegisterModel))]
    public class MyRegisterModel : RegisterModel
    {
        public MyRegisterModel(IAuthenticationSchemeProvider schemeProvider, IOptions<AbpAccountOptions> accountOptions, IAccountExternalProviderAppService accountExternalProviderAppService, ICurrentPrincipalAccessor currentPrincipalAccessor, IHttpClientFactory httpClientFactory)
            : base(schemeProvider, accountOptions, accountExternalProviderAppService, currentPrincipalAccessor, httpClientFactory)
        {
        }
        public override async Task<IActionResult> OnGetAsync()
        {
            ExternalProviders = await GetExternalProviders();
            if (!await CheckSelfRegistrationAsync())
            { 
                Alerts.Warning(L["SelfRegistrationDisabledMessage"]);
                return Page();
            }

            await TrySetEmailAsync();

            return Page();
        }

        protected override async Task<bool> CheckSelfRegistrationAsync()
        {
            EnableLocalRegister = await SettingProvider.IsTrueAsync(AccountSettingNames.EnableLocalLogin) &&
                                  await SettingProvider.IsTrueAsync(AccountSettingNames.IsSelfRegistrationEnabled);
             
            if (!EnableLocalRegister)
            {
                return false;
            }

            return true;
        }
    }
}