using ApenHis.EntityExtensions;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace ApenHis;

public static class ApenHisDtoExtensions
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        OneTimeRunner.Run(() =>
        {
            /* You can add extension properties to DTOs
             * defined in the depended modules.
             *
             * Example:
             *
             * ObjectExtensionManager.Instance
             *   .AddOrUpdateProperty<IdentityRoleDto, string>("Title");
             *
             * See the documentation for more:
             * https://docs.abp.io/en/abp/latest/Object-Extensions
             */
            //AddOrUpdateProperty<UserExt>(ObjectExtensionManager.Instance, new[]
            //{
            //            typeof(IdentityUserDto),
            //            typeof(IdentityUserCreateDto),
            //            typeof(IdentityUserUpdateDto),
            //            typeof(ProfileDto),
            //            typeof(UpdateProfileDto)
            //});
        });
    }

    //private static void AddOrUpdateProperty<T>(ObjectExtensionManager manager, Type[] types) where T : class
    //{
    //    AddOrUpdateProperty(typeof(T).GetProperties(), 0, manager, types);

    //    void AddOrUpdateProperty(PropertyInfo[] properties, int index, ObjectExtensionManager manager, Type[] types)
    //    {
    //        if (index < properties.Length)
    //        {
    //            var item = properties[index];
    //            AddOrUpdateProperty(properties, ++index, manager.AddOrUpdateProperty(types, item.PropertyType, item.Name, options =>
    //            {
    //                var attrs = item.GetCustomAttributes()?.Where(m => m is not ColumnAttribute);
    //                if (attrs != null) options.Attributes.AddRange(attrs);
    //            }), types);
    //        }
    //    }
    //}
}
