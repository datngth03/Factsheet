using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Sabeco_Factsheet.Localization;
using Sabeco_Factsheet.Permissions;
using Volo.Abp.Account.Localization;
using Volo.Abp.AuditLogging.Blazor.Menus;
using Volo.Abp.Identity.Pro.Blazor.Navigation;
using Volo.Abp.LanguageManagement.Blazor.Menus;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TextTemplateManagement.Blazor.Menus;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.OpenIddict.Pro.Blazor.Menus;
using Volo.Saas.Host.Blazor.Navigation;
using System.Drawing;

namespace Sabeco_Factsheet.Blazor.Client.Navigation;

public class Sabeco_FactsheetMenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;

    public Sabeco_FactsheetMenuContributor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
            await ConfigureWebMenuAsync(context);
        }
        else if (context.Menu.Name == StandardMenus.User)
        {
            await ConfigureUserMenuAsync(context);
        }
    }

    private static Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<Sabeco_FactsheetResource>();

        context.Menu.AddItem(new ApplicationMenuItem(
            Sabeco_FactsheetMenus.Home,
            l["Menu:Home"],
            "/",
            icon: "fas fa-home",
            order: 1
        ));

        return Task.CompletedTask;
    }

    private static Task ConfigureWebMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<Sabeco_FactsheetResource>();

        context.Menu.AddItem(
            new ApplicationMenuItem(
                Sabeco_FactsheetMenus.TbCompanies,
                l["Menu:TbCompanies"],
                url: "/companies",
                icon: "fa fa-building",
                requiredPermissionName: Sabeco_FactsheetPermissions.TbCompanies.Default)
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                Sabeco_FactsheetMenus.TbAdditionInfos,
                l["Menu:TbPersons"],
                url: "/persons",
                icon: "fa fa-user-tie",
                requiredPermissionName: Sabeco_FactsheetPermissions.TbAdditionInfos.Default)
        );

        context.Menu.AddItem(
            new ApplicationMenuItem(
                Sabeco_FactsheetMenus.TbAdditionInfos,
                l["Menu:TbBreweries"],
                url: "/breweries", 
                icon: "fa fa-industry",
                requiredPermissionName: Sabeco_FactsheetPermissions.TbAdditionInfos.Default)
        );

        return Task.CompletedTask;
    }

    private async Task ConfigureUserMenuAsync(MenuConfigurationContext context)
    {
        if (OperatingSystem.IsBrowser())
        {
            //Blazor wasm menu items

            var authServerUrl = _configuration["AuthServer:Authority"] ?? "";
            var accountResource = context.GetLocalizer<AccountResource>();

            context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", accountResource["MyAccount"], $"{authServerUrl.EnsureEndsWith('/')}Account/Manage", icon: "fa fa-cog", order: 900, target: "_blank").RequireAuthenticated());
            context.Menu.AddItem(new ApplicationMenuItem("Account.SecurityLogs", accountResource["MySecurityLogs"], $"{authServerUrl.EnsureEndsWith('/')}Account/SecurityLogs", icon: "fa fa-user-shield", order: 901, target: "_blank").RequireAuthenticated());
            context.Menu.AddItem(new ApplicationMenuItem("Account.Sessions", accountResource["Sessions"], url: $"{authServerUrl.EnsureEndsWith('/')}Account/Sessions", icon: "fa fa-clock", order: 902, target: "_blank").RequireAuthenticated());
        }
        else
        {
            //Blazor server menu items

        }

        await Task.CompletedTask;
    }
}