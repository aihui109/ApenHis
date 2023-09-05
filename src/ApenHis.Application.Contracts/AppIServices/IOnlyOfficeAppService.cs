using ApenHis.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace ApenHis.AppIServices
{
    public interface IOnlyOfficeAppService : IApplicationService
    {
        Task<OnlyofficeCallback> CallBack(OnlyofficeCallbackInput input);
        Task<OnlyofficeCallback> CallBack2(OnlyofficeCallbackInput input);
    }
}
