using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace ApenHis.Controllers
{
    public class OdataTestController : ODataController
    {
        private readonly IRepository<IdentityUser, Guid> _userRepository;

        public OdataTestController(IRepository<IdentityUser, Guid> userRepository)
        {
            _userRepository = userRepository;
        }

        // GET
        [EnableQuery]
        public virtual async Task<IQueryable<IdentityUser>> GetAsync()
        {
            return await _userRepository.GetQueryableAsync();
        }
    }
}
