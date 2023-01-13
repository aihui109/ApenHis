using IdentityModel.OidcClient;
using Microsoft.Extensions.Options;
using Polly;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace ApenHis.Maui.Client
{
    [DependsOn(
    typeof(AbpAutofacModule),
    typeof(ApenHisHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
    public class ApenHisMauiClientModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<AbpHttpClientBuilderOptions>(options =>
            {
                options.ProxyClientBuildActions.Add((remoteServiceName, clientBuilder) =>
                {
                    clientBuilder.AddTransientHttpErrorPolicy(
                        policyBuilder => policyBuilder.WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(Math.Pow(2, i)))
                    );
                });
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            Configure<OidcClientOptions>(configuration.GetSection("IdentityClients:Default"));

            context.Services.AddTransient<OidcClient>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<OidcClientOptions>>().Value;
                options.Browser = sp.GetRequiredService<WebAuthenticatorBrowser>();
                return new OidcClient(options);
            });
        }
    }
}
