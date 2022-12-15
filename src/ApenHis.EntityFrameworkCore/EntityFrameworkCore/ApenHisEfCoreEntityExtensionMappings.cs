using ApenHis.EntityExtensions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace ApenHis.EntityFrameworkCore;

public static class ApenHisEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        ApenHisGlobalFeatureConfigurator.Configure();
        ApenHisModuleExtensionConfigurator.Configure();

        OneTimeRunner.Run(() =>
        {
            /* You can configure extra properties for the
             * entities defined in the modules used by your application.
             *
             * This class can be used to map these extra properties to table fields in the database.
             *
             * USE THIS CLASS ONLY TO CONFIGURE EF CORE RELATED MAPPING.
             * USE ApenHisModuleExtensionConfigurator CLASS (in the Domain.Shared project)
             * FOR A HIGH LEVEL API TO DEFINE EXTRA PROPERTIES TO ENTITIES OF THE USED MODULES
             *
             * Example: Map a property to a table field:

                 ObjectExtensionManager.Instance
                     .MapEfCoreProperty<IdentityUser, string>(
                         "MyProperty",
                         (entityBuilder, propertyBuilder) =>
                         {
                             propertyBuilder.HasMaxLength(128);
                         }
                     );

             * See the documentation for more:
             * https://docs.abp.io/en/abp/latest/Customizing-Application-Modules-Extending-Entities
             */
            ObjectExtensionManager.Instance
                    .MapEfCoreProperty<IdentityUser, string>(nameof(Operator.InputCode),
                         (entityBuilder, propertyBuilder) =>
                         {
                             propertyBuilder.HasColumnType("nvarchar").HasMaxLength(50).HasComment("输入码");
                         })
                    //.MapEfCoreProperty<IdentityUser, Guid?>(nameof(Operator.DepartmentId))
                    //.MapEfCoreProperty<IdentityUser, DateTime?>(nameof(Operator.CreateTime))
                    //.MapEfCoreProperty<IdentityUser, DateTime?>(nameof(Operator.UpdateTime))
                    //.MapEfCoreProperty<IdentityUser, byte[]>(nameof(Operator.TimeStamp))
                    //.MapEfCoreProperty<IdentityUser, string>(nameof(Operator.IDCard))
                    //.MapEfCoreProperty<IdentityUser, string>(nameof(Operator.Sex))
                    //.MapEfCoreProperty<IdentityUser, DateTime?>(nameof(Operator.Birthday))
                    //.MapEfCoreProperty<IdentityUser, string>(nameof(Operator.Nation))
                    //.MapEfCoreProperty<IdentityUser, string>(nameof(Operator.Title))
                    //.MapEfCoreProperty<IdentityUser, bool>(nameof(Operator.IsAdmin))
                    ;
        });
    }
}
