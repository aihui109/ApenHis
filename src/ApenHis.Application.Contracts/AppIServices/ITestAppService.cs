using ApenHis.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace ApenHis.AppIServices
{
    public interface ITestAppService : IApplicationService
    {
        Task<TestDto> GetTestDto(TestInput input);
    }
}
