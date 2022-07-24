using Volo.Abp.Settings;

namespace ApenHis.Settings;

public class ApenHisSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ApenHisSettings.MySetting1));
    }
}
