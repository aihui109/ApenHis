using ApenHis.AppIServices;
using ApenHis.Dtos;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApenHis.AppServices
{
    [Authorize]
    public class TestAppService : ApenHisAppService, ITestAppService 
    {
        [HttpPost]
        public async Task<TestDto> GetTestDto(TestInput input)
        {
            return await Task.FromResult(new TestDto { Password = input.Password1, PhoneNumber = input.PhoneNumber1, UserName = input.UserName1 });
        }
    }
}
