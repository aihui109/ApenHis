using ApenHis.AppIServices;
using ApenHis.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;
using ApenHis.Entities;
using System;

namespace ApenHis.AppServices
{
    [Authorize,Route("api/[controller]/[action]")]
    public class TestAppService : ApenHisAppService, ITestAppService
    {
        // public IRepository<Feature,Guid> FeatureRepository { get; set; }    
        [HttpPost]
        public async Task<TestDto> GetTestDto(TestInput input)
        {
            // ObjectMapper.Map<Feature,Object>(await FeatureRepository.FindAsync(null));
            return await Task.FromResult(new TestDto { Password = input.Password1, PhoneNumber = input.PhoneNumber1, UserName = input.UserName1 });
        }
    }
}
