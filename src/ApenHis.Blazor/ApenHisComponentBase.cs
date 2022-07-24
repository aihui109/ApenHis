using ApenHis.Localization;
using Volo.Abp.AspNetCore.Components;

namespace ApenHis.Blazor;

public abstract class ApenHisComponentBase : AbpComponentBase
{
    protected ApenHisComponentBase()
    {
        LocalizationResource = typeof(ApenHisResource);
    }
}
