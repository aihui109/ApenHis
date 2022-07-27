using ApenHis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApenHis.EntityCfgs
{
    internal class FeatureCfg : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasIndex(q => new { q.TenantId, q.Title }, "UIDXFeatureTenantIdTitle").IsUnique();
        }
    }
}
