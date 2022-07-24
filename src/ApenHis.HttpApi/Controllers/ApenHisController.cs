using ApenHis.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ApenHis.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ApenHisController : AbpControllerBase
{
    protected ApenHisController()
    {
        LocalizationResource = typeof(ApenHisResource);
    }
}
