using System;
using System.Collections.Generic;
using System.Text;
using ApenHis.Localization;
using Volo.Abp.Application.Services;

namespace ApenHis;

/* Inherit your application services from this class.
 */
public abstract class ApenHisAppService : ApplicationService
{
    protected ApenHisAppService()
    {
        LocalizationResource = typeof(ApenHisResource);
    }
}
