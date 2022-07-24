using ApenHis.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace ApenHis.Permissions;

public class ApenHisPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ApenHisPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ApenHisPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ApenHisResource>(name);
    }
}
