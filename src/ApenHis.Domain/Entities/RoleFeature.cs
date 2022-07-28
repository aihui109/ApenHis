using System;
using Volo.Abp.Domain.Entities;

namespace ApenHis.Entities
{
    public class RoleFeature : Entity<Guid>
    {
        public Guid RoleGuid { get; set; }
        public Guid FeatureGuid { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid CreatorId { get; set; }
    }
}
