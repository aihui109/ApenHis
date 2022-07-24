using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ApenHis;

[Dependency(ReplaceServices = true)]
public class ApenHisBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ApenHis";
}
