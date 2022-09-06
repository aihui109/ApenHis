using Volo.Abp.Account.Web.Pages.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using Volo.Abp.Account.Web;

namespace ApenHis.Pages.Account
{
    public class CustomLoginModel : LoginModel
    {
        public CustomLoginModel(
            IAuthenticationSchemeProvider schemeProvider,
            IOptions<AbpAccountOptions> accountOptions,
            IOptions<IdentityOptions> identityOptions)
            : base(schemeProvider: schemeProvider, accountOptions: accountOptions, identityOptions: identityOptions)
        {
        }
    }
}
