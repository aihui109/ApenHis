using ApenHis.EntityExtensions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

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
            MapEfCoreProperty<UserExt, IdentityUser>(ObjectExtensionManager.Instance);
        });
    }

     private static void MapEfCoreProperty<T, TEntity>(ObjectExtensionManager manager) where T : class where TEntity : IHasExtraProperties, IEntity
    {
        var typeT = typeof(T);
        var typeTEntity = typeof(TEntity);
        MapEfCoreProperty(typeT.GetProperties(), 0, manager);

        void MapEfCoreProperty(PropertyInfo[] properties, int index, ObjectExtensionManager manager)
        {
            if (index < properties.Length)
            {
                var item = properties[index];
                MapEfCoreProperty(properties, ++index, manager.MapEfCoreProperty(typeTEntity, item.PropertyType, item.Name, (entityBuilder, propertyBuilder) =>
                {
                    var title = item.GetSingleAttributeOrNull<DisplayAttribute>()?.Name;
                    if (!title.IsNullOrWhiteSpace()) propertyBuilder.HasComment(title);
                    if (item.GetSingleAttributeOrNull<ColumnAttribute>() is not null and ColumnAttribute attr)
                    {
                        if (!attr.TypeName.IsNullOrWhiteSpace()) propertyBuilder.HasColumnType(attr.TypeName);
                    }
                    if (item.GetSingleAttributeOrNull<DatabaseGeneratedAttribute>() is not null and DatabaseGeneratedAttribute gAttr)
                    { 
                        switch (gAttr.DatabaseGeneratedOption) 
                        {
                            case DatabaseGeneratedOption.Identity:
                                propertyBuilder.ValueGeneratedOnAdd().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
                                break;
                            case DatabaseGeneratedOption.Computed:
                                propertyBuilder.ValueGeneratedOnAddOrUpdate().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
                                break;
                        }
                    }
                    if (index == properties.Length - 1 && typeT.GetCustomAttributes<IndexAttribute>() is not null and IEnumerable<IndexAttribute> idxs)
                    {
                        foreach (var idx in idxs)
                        {
                            entityBuilder.HasIndex(idx.PropertyNames.ToArray()).IsUnique(idx.IsUnique);
                        }
                    }
                }));
            }
        }
    }
}
