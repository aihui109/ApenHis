using Volo.Abp.Modularity;

namespace ApenHis;

[DependsOn(
    typeof(ApenHisApplicationModule),
    typeof(ApenHisDomainTestModule)
    )]
public class ApenHisApplicationTestModule : AbpModule
{

}
