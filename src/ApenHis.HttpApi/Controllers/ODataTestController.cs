using Microsoft.AspNetCore.OData.Query;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace ApenHis.Controllers
{
    [ODataAttributeRouting]
    [Route("odata")]
    public class ODataTestController : ApenHisController
    {
        private readonly IRepository<IdentityUser, Guid> _userRepository;

        public ODataTestController(IRepository<IdentityUser, Guid> userRepository)
        {
            _userRepository = userRepository;
        }

        // GET
        [EnableQuery]
        [HttpGet("users")]
        public virtual async Task<IQueryable<IdentityUser>> GetAsync()
        {
            return await _userRepository.GetQueryableAsync();
        }
    }
}
