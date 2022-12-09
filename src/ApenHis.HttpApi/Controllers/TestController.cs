using ApenHis.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApenHis.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController, Authorize]
    public class TestController : ApenHisController
    {
        [HttpPost]
        public async Task<TestDto> GetTestDto(TestInput input)
        {
            return await Task.FromResult(new TestDto { Password = input.Password1, PhoneNumber = input.PhoneNumber1, UserName = input.UserName1 });
        }
    }
}
