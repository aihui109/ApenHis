using ApenHis.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ApenHis;

[DependsOn(
    typeof(ApenHisEntityFrameworkCoreTestModule)
    )]
public class ApenHisDomainTestModule : AbpModule
{

}
