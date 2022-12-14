using System;
using System.Net.Http;
using IdentityModel;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ApenHis.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.BasicTheme.Themes.Basic;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.Autofac.WebAssembly;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.AspNetCore.Components.WebAssembly.BasicTheme;
using Volo.Abp.Identity.Blazor.WebAssembly;
using Volo.Abp.SettingManagement.Blazor.WebAssembly;
using Volo.Abp.TenantManagement.Blazor.WebAssembly;
using AntDesign.ProLayout;

namespace ApenHis.Blazor;

[DependsOn(
    typeof(AbpAutofacWebAssemblyModule),
    typeof(ApenHisHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyBasicThemeModule),
    typeof(AbpIdentityBlazorWebAssemblyModule),
    typeof(AbpTenantManagementBlazorWebAssemblyModule),
    typeof(AbpSettingManagementBlazorWebAssemblyModule)
)]
public class ApenHisBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var environment = context.Services.GetSingletonInstance<IWebAssemblyHostEnvironment>();
        var builder = context.Services.GetSingletonInstance<WebAssemblyHostBuilder>();

        ConfigureAuthentication(builder);
        ConfigureHttpClient(context, environment);
        ConfigureAntDesign(context);
        ConfigureRouter(context);
        ConfigureUI(builder);
        ConfigureMenu(context);
        ConfigureAutoMapper(context);
    }

    private void ConfigureRouter(ServiceConfigurationContext context)
    {
        Configure<AbpRouterOptions>(options =>
        {
            options.AppAssembly = typeof(ApenHisBlazorModule).Assembly;
        });
    }

    private void ConfigureMenu(ServiceConfigurationContext context)
    {
        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new ApenHisMenuContributor(context.Services.GetConfiguration()));
        });
    }

    private void ConfigureAntDesign(ServiceConfigurationContext context)
    {
        context.Services.AddAntDesign();
        var configuration = context.Services.GetConfiguration();
        context.Services.Configure<ProSettings>(configuration.GetSection("ProSettings"));
    }

    private static void ConfigureAuthentication(WebAssemblyHostBuilder builder)
    {
        builder.Services.AddOidcAuthentication(options =>
        {
            builder.Configuration.Bind("AuthServer", options.ProviderOptions);
            options.UserOptions.RoleClaim = JwtClaimTypes.Role;
            options.ProviderOptions.DefaultScopes.Add("ApenHis");
            options.ProviderOptions.DefaultScopes.Add("roles");
            options.ProviderOptions.DefaultScopes.Add("email");
            options.ProviderOptions.DefaultScopes.Add("phone");
        });
    }

    private static void ConfigureUI(WebAssemblyHostBuilder builder)
    {
        builder.RootComponents.Add<App>("#app");
    }

    private static void ConfigureHttpClient(ServiceConfigurationContext context, IWebAssemblyHostEnvironment environment)
    {
        context.Services.AddTransient(sp => new HttpClient
        {
            BaseAddress = new Uri(environment.BaseAddress)
        });
    }

    private void ConfigureAutoMapper(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ApenHisBlazorModule>();
        });
    }
}
